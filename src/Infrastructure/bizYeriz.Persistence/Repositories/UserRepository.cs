using AutoMapper;
using bizyeriz.Application.Features.Users.AddFavoriteCompany;
using bizyeriz.Application.Interfaces.Repositories;
using bizYeriz.Domain.Entities.AuthEntities;
using bizYeriz.Domain.Entities.CompanyEntities;

namespace bizYeriz.Persistence.Repositories;

public class UserRepository : AsyncGenericRepository<User, Guid>, IUserRepository
{
    public UserRepository(AppDbContext context, IMapper mapper) : base(context, mapper)
    {
    }

    public async Task<bool> AddFovoriteCompanyAsync(FavoriteCompany favoriteCompany, CancellationToken cancellationToken = default)
    {
        if (favoriteCompany == null) return false;
        await _context.FavoriteCompanies.AddAsync(favoriteCompany, cancellationToken);
        return true;
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