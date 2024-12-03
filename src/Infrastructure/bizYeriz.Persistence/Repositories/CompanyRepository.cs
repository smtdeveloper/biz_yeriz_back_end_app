using AutoMapper;
using bizyeriz.Application.Features.Companies.Enums;
using bizyeriz.Application.Interfaces.Repositories;
using bizYeriz.Domain.Entities.CompanyEntities;
using NetTopologySuite.Geometries;

namespace bizYeriz.Persistence.Repositories;

public class CompanyRepository : AsyncGenericRepository<Company, Guid>, ICompanyRepository
{
    private readonly AppDbContext _dbContext;
    private readonly IMapper _mapper;

    public CompanyRepository(AppDbContext context, IMapper mapper) : base(context, mapper)
    {
        _dbContext = context;
        _mapper = mapper;
    }

    public async Task<List<Company>> GetFilteredNearbyCompaniesAsync(GetFilterNearbyCompaniesQuery getFilterNearbyCompaniesQuery, CancellationToken cancellationToken)
    {
        Point userLocation = new Point(getFilterNearbyCompaniesQuery.Location.Longitude, getFilterNearbyCompaniesQuery.Location.Latitude) { SRID = 4326 };

        var query = _dbContext.Companies
            .AsNoTracking()
            .Where(company =>
                company.IsActive == true &&
                company.IsDelete == false &&
                company.Location.Distance(userLocation) < getFilterNearbyCompaniesQuery.Location.Distance);

        // Mutfak filtresi
        if (getFilterNearbyCompaniesQuery.Filters.CuisineCategoryIds != null && getFilterNearbyCompaniesQuery.Filters.CuisineCategoryIds.Any())
        {
            query = query
                .Include(c => c.Foods)
                .ThenInclude(f => f.CuisineCategoryAndFoods)
                .Where(company => company.Foods.Any(_food =>
                    _food.CuisineCategoryAndFoods.Any(ccf => getFilterNearbyCompaniesQuery.Filters.CuisineCategoryIds.Contains(ccf.CuisineCategoryId)) &&
                    _food.IsActive == true &&
                    _food.IsDelete == false
                    ));
        }

        // Fiyat filtresi
        if (getFilterNearbyCompaniesQuery.Filters.PriceRangeId.HasValue)
        {
            double maxPrice = GetMaxPriceByPriceRangeId(getFilterNearbyCompaniesQuery.Filters.PriceRangeId.Value);

            query = query
                .Where(company => company.Foods.Any(food =>
                    food.IsActive == true &&
                    food.IsDelete == false &&
                    ((food.DiscountedPrice) <= maxPrice)));
        }

        // Puan filtresi
        if (getFilterNearbyCompaniesQuery.Filters.ByPointId.HasValue)
        {
            double minPoint = GetMinimumPointByPointId(getFilterNearbyCompaniesQuery.Filters.ByPointId.Value);

            query = query
                .Where(company => company.StarRating / company.RatingCount >= minPoint);
        }

        // Ödeme türü filtresi
        if (getFilterNearbyCompaniesQuery.Filters.PaymentIds != null && getFilterNearbyCompaniesQuery.Filters.PaymentIds.Any())
        {
            query = query
                .Where(company => company.CompanyPaymentTypes.Any(cpt =>
                    getFilterNearbyCompaniesQuery.Filters.PaymentIds.Contains(cpt.PaymentTypeId)));
        }


        var companies = await query
         .Select(company => new Company
         {
             Id = company.Id,
             Name = company.Name,
             Email = company.Email,
             MobilePhone = company.MobilePhone,
             CompanyPhone = company.CompanyPhone,
             ImageUrl = company.ImageUrl,
             StarRating = company.StarRating,
             RatingCount = company.RatingCount,
             AverageRating = company.RatingCount > 0 ? company.StarRating / company.RatingCount : 0,
             City = company.City,
             District = company.District,
             Neighborhood = company.Neighborhood,
             Street = company.Street,
             AddressDetail = company.AddressDetail,
             MapUrl = company.MapUrl,
             Location = company.Location,
             CompanyTypeName = company.CompanyTypeName,
             CompanyTypeDescription = company.CompanyTypeDescription,
             CompanyTypeImageUrl = company.CompanyTypeImageUrl,
             EnvironmentallyFriendly = company.EnvironmentallyFriendly,
             IsTrustworthy = company.IsTrustworthy,
             IsActive = company.IsActive,
             IsDelete = company.IsDelete,
             CreatedDate = company.CreatedDate,
             UpdatedDate = company.UpdatedDate,
             DeletedDate = company.DeletedDate,
             Distance = Math.Round(company.Location.Distance(userLocation) / 1000),
         })
         .ToListAsync(cancellationToken);

        return companies;
    }

    private double GetMaxPriceByPriceRangeId(int priceRangeId)
    {
        // PriceRanges listesinden ilgili ID'ye sahip kaydı bul
        var priceRange = StaticFilters.PriceRanges.FirstOrDefault(pr => pr.Id == priceRangeId);
        return priceRange?.Range ?? double.MaxValue; // Eğer ID bulunmazsa varsayılan değer
    }

    private double GetMinimumPointByPointId(int byPointId)
    {
        // ByPoints listesinden ilgili ID'ye sahip kaydı bul
        var byPoint = StaticFilters.ByPoints.FirstOrDefault(bp => bp.Id == byPointId);
        return byPoint?.Point ?? 0; // Eğer ID bulunmazsa varsayılan değer
    }

}