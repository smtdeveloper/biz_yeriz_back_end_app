using bizYeriz.Domain.Entities.AuthEntities;

namespace bizyeriz.Application.Interfaces.Repositories;

public interface IRoleRepository : IAsyncGenericRepository<Role, Guid>
{
}