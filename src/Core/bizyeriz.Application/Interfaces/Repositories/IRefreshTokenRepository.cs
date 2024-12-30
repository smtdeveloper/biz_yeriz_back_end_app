using bizYeriz.Domain.Entities.AuthEntities;

namespace bizyeriz.Application.Interfaces.Repositories;

public interface IRefreshTokenRepository : IAsyncGenericRepository<RefreshToken, int>
{
    Task<List<RefreshToken>> GetOldRefreshTokensAsync(Guid userId, int refreshTokenTTL);
}