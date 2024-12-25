using bizyeriz.Application.Features.Companies.Queries.GetCompanyById;
using bizYeriz.Domain.Entities.CompanyEntities;

namespace bizyeriz.Application.Interfaces.Repositories;

public interface ICompanyRepository : IAsyncGenericRepository<Company, Guid>
{
    Task<List<Company>> GetFilteredNearbyCompaniesAsync(GetFilterNearbyCompaniesQuery getFilterNearbyCompaniesQuery, CancellationToken cancellationToken);
    Task<List<CuisineCategoryWithFoodsDto>> GetFoodsGroupedByCuisineAsync(Guid companyId, CancellationToken cancellationToken);
    Task<List<CompanyWorkingHour>> GetWorkingHoursByCompanyIdAsync(Guid companyId, CancellationToken cancellationToken);
}
