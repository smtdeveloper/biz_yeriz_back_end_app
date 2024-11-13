using AutoMapper;
using bizyeriz.Application.Interfaces.Repositories;
using bizYeriz.Domain.Entities.CompanyEntities;
using NetTopologySuite.Geometries;

namespace bizYeriz.Persistence.Repositories;

public class CompanyRepository : AsyncGenericRepository<Company, Guid>, ICompanyRepository
{
    private readonly AppDbContext _dbContext;

    public CompanyRepository(AppDbContext context, IMapper mapper) : base(context, mapper)
    {
        _dbContext = context;
    }

    public async Task<List<Company>> GetNearbyCompaniesAsync(double latitude, double longitude, double distance, CancellationToken cancellationToken)
    {
        Point point = new Point(latitude, longitude) { SRID = 4326 };

        var result = await _dbContext.Companies
            .Where(x => x.Location.Distance(point) < distance)
            .Select(x => new Company
            {
                Id = x.Id,
                Name = x.Name,
                ImageUrl = x.ImageUrl,
                StarRating = x.StarRating,
                RatingCount = x.RatingCount,
                Location = x.Location,
                Distance = Math.Round(x.Location.Distance(point)),
                CompanyTypeName = x.CompanyTypeName,
                EnvironmentallyFriendly = x.EnvironmentallyFriendly,
                IsTrustworthy = x.IsTrustworthy,
                CreatedDate = x.CreatedDate,
                UpdatedDate = x.UpdatedDate,
                DeletedDate = x.DeletedDate
            })
            .ToListAsync(cancellationToken);

        return result;
    }



}
