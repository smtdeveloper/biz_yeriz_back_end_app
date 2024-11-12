using bizYeriz.Domain.Entities.CompanyEntities;

namespace bizyeriz.Application.Interfaces.Repositories;

public interface ICompanyRepository : IAsyncGenericRepository<Company, Guid>
{
    Task<List<Company>> GetNearbyCompaniesAsync(double latitude, double longitude, double distance, CancellationToken cancellationToken);

}
