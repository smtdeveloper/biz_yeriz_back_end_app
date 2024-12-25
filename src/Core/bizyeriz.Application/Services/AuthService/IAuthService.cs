using bizYeriz.Domain.Entities.AuthEntities;

namespace bizyeriz.Application.Services.AuthService;

public interface IAuthService
{
    public Task<AccessToken> CreateAccessToken(User user, CancellationToken cancellationToken);
    public Task<RefreshToken> CreateRefreshToken(User user, string ipAddress, CancellationToken cancellationToken);
    public Task<RefreshToken?> GetRefreshTokenByToken(string refreshToken, CancellationToken cancellationToken);
    public Task<RefreshToken> AddRefreshToken(RefreshToken refreshToken, CancellationToken cancellationToken);
    public Task DeleteOldRefreshTokens(Guid userId, CancellationToken cancellationToken);
    public Task RevokeDescendantRefreshTokens(RefreshToken refreshToken, string ipAddress, string reason, CancellationToken cancellationToken);
    public Task RevokeRefreshToken(RefreshToken token, string ipAddress, string? reason = null, string? replacedByToken = null);
    public Task<RefreshToken> RotateRefreshToken(User user, RefreshToken refreshToken, string ipAddress, CancellationToken cancellationToken);
}