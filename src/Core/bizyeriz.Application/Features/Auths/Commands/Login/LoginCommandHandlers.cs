using bizyeriz.Application.Features.Auths.BusinessRules;
using bizyeriz.Application.Interfaces.Repositories;
using bizyeriz.Application.Interfaces.UnitOfWork;
using bizyeriz.Application.Services.AuthService;
using bizYeriz.Domain.Entities.AuthEntities;
using bizYeriz.Shared.Responses;

namespace bizyeriz.Application.Features.Auths.Commands.Login;

public class LoginCommandHandlers : IRequestHandler<LoginCommand, IDataResponse<LoginCommandResponse>>
{
    private readonly IUserRepository _userRepository;
    private readonly IRoleRepository _roleRepository;
    private readonly IAuthService _authService;
    private readonly IUnitOfWork _unitOfWork;
    private readonly AuthBusinessRules _authBusinessRules;
    public LoginCommandHandlers(IUserRepository userRepository, IAuthService authService, IUnitOfWork unitOfWork, AuthBusinessRules authBusinessRules)
    {
        _userRepository = userRepository;
        _authService = authService;
        _unitOfWork = unitOfWork;
        _authBusinessRules = authBusinessRules;
    }

    public async Task<IDataResponse<LoginCommandResponse>> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        User? user = null;
       
        if (string.IsNullOrEmpty(request.Email)) 
            user = await _userRepository.GetUserByEmailAsync(request.Email,cancellationToken: cancellationToken);

        if (string.IsNullOrEmpty(request.Gsm))
            user = await _userRepository.GetUserByGsmAsync(request.Email,cancellationToken: cancellationToken);

        await _authBusinessRules.UserShouldBeExistsWhenSelected(user);
        await _authBusinessRules.UserPasswordShouldBeMatch(user!, request.Password);

        LoginCommandResponse loggedResponse = new();

        AccessToken createdAccessToken = await _authService.CreateAccessToken(user, cancellationToken);

        RefreshToken createdRefreshToken = await _authService.CreateRefreshToken(user, request.IpAddress, cancellationToken);
        RefreshToken addedRefreshToken = await _authService.AddRefreshToken(createdRefreshToken, cancellationToken);
        await _authService.DeleteOldRefreshTokens(user.Id, cancellationToken);

       Role userRole = await  _roleRepository.GetByIdAsync(user.RoleId, cancellationToken);

        loggedResponse.AccessToken = createdAccessToken;
        loggedResponse.RefreshToken = addedRefreshToken;
        loggedResponse.Role = userRole;
        
        await _unitOfWork.CommitAsync();

        var result = DataResponse<LoginCommandResponse>.SuccessResponse(loggedResponse, "Başarılı Giriş!");
        return result;
    }
}