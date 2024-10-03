using AutoMapper;
using bizyeriz.Application.Interfaces.Repositories;
using bizYeriz.Domain.Entities.CompanyEntities;

namespace bizYeriz.Persistence.Repositories;

public class CompanyRepository : AsyncGenericRepository<Company,Guid>, ICompanyRepository
{
    public CompanyRepository(AppDbContext context, IMapper mapper) : base(context, mapper)
    {
    }
}
