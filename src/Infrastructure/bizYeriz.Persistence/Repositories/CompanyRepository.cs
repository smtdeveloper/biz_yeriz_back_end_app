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
        Point point = new Point(latitude,longitude);

        var result = await _dbContext.Companies
            .Where(x => x.Location.Distance(point) < distance)
            .ToListAsync(cancellationToken);

        return result;
    }

}
