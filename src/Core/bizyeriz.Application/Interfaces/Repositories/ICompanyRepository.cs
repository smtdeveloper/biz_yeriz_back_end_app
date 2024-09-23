using bizYeriz.Domain.Entities.CompanyEntities;

namespace bizyeriz.Application.Interfaces.Repositories;

public interface ICompanyRepository : IAsyncGenericRepository<Company, Guid>
{
}
