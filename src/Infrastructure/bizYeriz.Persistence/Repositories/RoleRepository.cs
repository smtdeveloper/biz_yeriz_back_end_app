using AutoMapper;
using bizyeriz.Application.Interfaces.Repositories;
using bizYeriz.Domain.Entities.AuthEntities;

namespace bizYeriz.Persistence.Repositories;

public class RoleRepository : AsyncGenericRepository<Role, Guid>, IRoleRepository
{
    public RoleRepository(AppDbContext context, IMapper mapper) : base(context, mapper)
    {
    }

  

}