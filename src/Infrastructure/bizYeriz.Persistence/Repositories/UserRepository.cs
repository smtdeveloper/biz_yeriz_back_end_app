using AutoMapper;
using bizyeriz.Application.Interfaces.Repositories;
using bizYeriz.Domain.Entities.AuthEntities;

namespace bizYeriz.Persistence.Repositories;

public class UserRepository : AsyncGenericRepository<User, Guid>, IUserRepository
{
    public UserRepository(AppDbContext context, IMapper mapper) : base(context, mapper)
    {
    }

    public async Task<User?> GetUserByEmailAsync(string email, CancellationToken cancellationToken = default)
    {
        return await _context.Set<User>()
            .FirstOrDefaultAsync(u => u.Email == email, cancellationToken);
    }

    public async Task<User?> GetUserByGsmAsync(string gsm, CancellationToken cancellationToken = default)
    {
        return await _context.Set<User>()
            .FirstOrDefaultAsync(u => u.Gsm == gsm, cancellationToken);
    }
}