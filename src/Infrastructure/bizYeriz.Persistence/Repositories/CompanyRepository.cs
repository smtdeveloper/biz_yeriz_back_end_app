using AutoMapper;
using bizyeriz.Application.Features.Companies.Queries.GetCompanyById;
using bizyeriz.Application.Interfaces.Repositories;
using bizYeriz.Domain.Entities.CompanyEntities;
using bizYeriz.Persistence.Repositories.Extensions;
using NetTopologySuite.Geometries;
using static bizYeriz.Persistence.Repositories.Extensions.CompanyQueryExtensions;

namespace bizYeriz.Persistence.Repositories;

public  class CompanyRepository : AsyncGenericRepository<Company, Guid>, ICompanyRepository
{
    private readonly AppDbContext _dbContext;
    private readonly IMapper _mapper;

    public CompanyRepository(AppDbContext context, IMapper mapper) : base(context, mapper)
    {
        _dbContext = context;
        _mapper = mapper;
    }

    public async Task<List<CuisineCategoryWithFoodsDto>> GetFoodsGroupedByCuisineAsync(Guid companyId, CancellationToken cancellationToken)
    {
        var groupedFoods = await _context.Foods
            .AsNoTracking()
            .Where(f => f.CompanyId == companyId && f.IsActive)
            .SelectMany(f => f.CuisineCategoryAndFoods.Select(ccf => new
            {
                CuisineCategory = ccf.CuisineCategory,
                Food = new CompanyFoodsDto
                {
                    Id = f.Id,
                    CompanyId = f.CompanyId,
                    Name = f.Name,
                    Description = f.Description,
                    OriginalPrice = f.OriginalPrice,
                    DiscountedPrice = f.DiscountedPrice,
                    ImageUrl = f.ImageUrl,
                    AvailableFrom = f.AvailableFrom,
                    AvailableUntil = f.AvailableUntil,
                    Stock = f.Stock,
                    IsActive = f.IsActive
                }
            }))
            .Distinct() // Tekrarları kaldır
            .GroupBy(x => x.CuisineCategory)
            .Select(group => new CuisineCategoryWithFoodsDto
            {
                CategoryName = group.Key.CategoryName,
                Foods = group.Select(x => x.Food).Distinct().ToList() // Yiyeceklerde tekrarları kaldır
            })
            .ToListAsync(cancellationToken);


        if (groupedFoods == null || !groupedFoods.Any())
            return new List<CuisineCategoryWithFoodsDto>();

        return groupedFoods;
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

        query = query.ApplyOrdering(getFilterNearbyCompaniesQuery.Filters.ByOrderId, userLocation);

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
             Distance = DistanceHelper.FormatDistance(company.Location.Distance(userLocation)), // Statik metot ile formatlama
         })
         .ToListAsync(cancellationToken);

        return companies;
    }
}