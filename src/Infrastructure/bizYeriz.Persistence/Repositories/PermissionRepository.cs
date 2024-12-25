using AutoMapper;
using bizyeriz.Application.Interfaces.Repositories;
using bizYeriz.Domain.Entities.AuthEntities;

namespace bizYeriz.Persistence.Repositories;

public class PermissionRepository : AsyncGenericRepository<Permission, Guid>, IPermissionRepository
{
    public PermissionRepository(AppDbContext context, IMapper mapper) : base(context, mapper)
    {
    }

    public async Task<IList<Permission>> GetPermissionsByRoleIdAsync(Guid roleId, CancellationToken cancellationToken)
    {
        var permissions = await _context.RolePermissions
            .Where(rp => rp.RoleId == roleId) // RoleId eşleşen kayıtları filtreliyoruz
            .Select(rp => rp.Permission) // İlgili Permission nesnelerini seçiyoruz
            .ToListAsync(cancellationToken); // Liste olarak alıyoruz

        return permissions;
    }

}
