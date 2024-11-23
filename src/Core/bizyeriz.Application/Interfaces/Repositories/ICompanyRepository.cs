using bizyeriz.Application.Features.Companies.Queries.GetNearbyCompanies;
using bizYeriz.Domain.Entities.CompanyEntities;

namespace bizyeriz.Application.Interfaces.Repositories;

public interface ICompanyRepository : IAsyncGenericRepository<Company, Guid>
{
    Task<List<Company>> GetFilteredNearbyCompaniesAsync(GetFilterNearbyCompaniesQuery getFilterNearbyCompaniesQuery, CancellationToken cancellationToken);

}
