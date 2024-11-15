using AutoMapper;
using bizyeriz.Application.Features.Companies.Queries.GetNearbyCompanies;
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

    public async Task<List<GetNearbyCompaniesQueryResponse>> GetNearbyCompaniesAsync(double latitude, double longitude, double distance, CancellationToken cancellationToken)
    {
        Point point = new Point(latitude ,longitude) { SRID = 4326 };

        var companies = await _dbContext.Companies
            .Where(x => x.Location.Distance(point) < distance)
            .ToListAsync(cancellationToken);

        // Distance hesaplamasını GetNearbyCompaniesQueryResponse modelinde yapıyoruz
        var result = companies.Select(company => new GetNearbyCompaniesQueryResponse
        {
            Id = company.Id,
            Name = company.Name,
            Lat = company.Location.X,
            Long = company.Location.Y,
            Distance = Math.Round(company.Location.Distance(point)), // Distance burada hesaplanıyor
            ImageUrl = company.ImageUrl,
            StarRating = company.StarRating,
            RatingCount = company.RatingCount,
            CompanyTypeName = company.CompanyTypeName,
            EnvironmentallyFriendly = company.EnvironmentallyFriendly,
            IsTrustworthy = company.IsTrustworthy,
            CreatedDate = company.CreatedDate,
            UpdatedDate = company.UpdatedDate,
            DeletedDate = company.DeletedDate,
            IsActive = company.IsActive,
            IsDelete = company.IsDelete
        }).ToList();

        return result;
    }
}
