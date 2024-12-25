using AutoMapper;
using bizyeriz.Application.Interfaces.Repositories;
using bizYeriz.Domain.Entities.AuthEntities;
using bizYeriz.Shared.Security.JWT;
using Microsoft.Extensions.Configuration;
using System.Collections.Immutable;

namespace bizyeriz.Application.Services.AuthService;

public class AuthManager : IAuthService
{
    private readonly IRefreshTokenRepository _refreshTokenRepository;
    private readonly IRoleRepository _roleRepository;
    private readonly IUserRepository _userRepository;
    private readonly IPermissionRepository _permissionRepository;
    private readonly ITokenHelper _tokenHelper;
    private readonly IConfiguration _configuration;
    private readonly IMapper _mapper;

    public AuthManager(
      
        IRefreshTokenRepository refreshTokenRepository,
        IRoleRepository roleRepository,
        IUserRepository userRepository,       
        IPermissionRepository permissionRepository,
        ITokenHelper tokenHelper,
        IConfiguration configuration,
        IMapper mapper
    )
    {
        _refreshTokenRepository = refreshTokenRepository;
        _roleRepository = roleRepository;
        _userRepository = userRepository;
        _permissionRepository = permissionRepository;
        _tokenHelper = tokenHelper;
        _configuration = configuration;
        _mapper = mapper;
    }

    public async Task<RefreshToken> AddRefreshToken(RefreshToken refreshToken, CancellationToken cancellationToken)
    {
        RefreshToken addedRefreshToken = await _refreshTokenRepository.AddAsync(refreshToken, cancellationToken);
        return addedRefreshToken;
    }

    public async Task<AccessToken> CreateAccessToken(User user, CancellationToken cancellationToken)
    {
        Role userRole = await _roleRepository.GetByIdAsync(user.RoleId, cancellationToken);
        IList<Permission> permissions = await _permissionRepository.GetPermissionsByRoleIdAsync(userRole.Id, cancellationToken);

        AccessToken accessToken = _tokenHelper.CreateToken(
            user,
            permissions.ToImmutableList()
        );
        return accessToken;
    }

    public Task<RefreshToken> CreateRefreshToken(User user, string ipAddress, CancellationToken cancellationToken)
    {
        RefreshToken coreRefreshToken = _tokenHelper.CreateRefreshToken(
            user,
            ipAddress
        );
        RefreshToken refreshToken = _mapper.Map<RefreshToken>(coreRefreshToken);
        return Task.FromResult(refreshToken);
    }

    public Task DeleteOldRefreshTokens(Guid userId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<RefreshToken?> GetRefreshTokenByToken(string refreshToken, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task RevokeDescendantRefreshTokens(RefreshToken refreshToken, string ipAddress, string reason, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task RevokeRefreshToken(RefreshToken token, string ipAddress, string? reason = null, string? replacedByToken = null)
    {
        throw new NotImplementedException();
    }

    public Task<RefreshToken> RotateRefreshToken(User user, RefreshToken refreshToken, string ipAddress, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}