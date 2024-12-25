using bizYeriz.Domain.Entities.AuthEntities;

namespace bizyeriz.Application.Interfaces.Repositories;

public interface IPermissionRepository : IAsyncGenericRepository<Permission, Guid>
{
    Task<IList<Permission>> GetPermissionsByRoleIdAsync(Guid rolId, CancellationToken cancellationToken);
}