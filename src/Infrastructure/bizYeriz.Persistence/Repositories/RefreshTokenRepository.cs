using AutoMapper;
using bizyeriz.Application.Interfaces.Repositories;
using bizYeriz.Domain.Entities.AuthEntities;

namespace bizYeriz.Persistence.Repositories;

public class RefreshTokenRepository : AsyncGenericRepository<RefreshToken, int>, IRefreshTokenRepository
{
    public RefreshTokenRepository(AppDbContext context, IMapper mapper) : base(context, mapper)
    {
    }

    public async Task<List<RefreshToken>> GetOldRefreshTokensAsync(Guid userId, int refreshTokenTTL)
    {
        List<RefreshToken> tokens = await Query()
             .AsNoTracking()
             .Where(r =>
                 r.UserId == userId
                 && r.RevokedDate == null
                 && r.ExpirationDate >= DateTime.UtcNow
                 && r.CreatedDate.AddDays(refreshTokenTTL) <= DateTime.UtcNow
             )
             .ToListAsync();

        return tokens;
    }
}