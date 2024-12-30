using bizyeriz.Application.Features.Auths.BusinessRules;
using bizyeriz.Application.Features.Auths.Commands.RegisterUser;
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
    public LoginCommandHandlers(IUserRepository userRepository, IRoleRepository roleRepository, IAuthService authService, IUnitOfWork unitOfWork, AuthBusinessRules authBusinessRules)
    {
        _userRepository = userRepository;
        _roleRepository = roleRepository;
        _authService = authService;
        _unitOfWork = unitOfWork;
        _authBusinessRules = authBusinessRules;
    }

    public async Task<IDataResponse<LoginCommandResponse>> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        User? user = null;
       
        if (!string.IsNullOrEmpty(request.Email)) 
            user = await _userRepository.GetUserByEmailAsync(request.Email,cancellationToken: cancellationToken);

        if (!string.IsNullOrEmpty(request.Gsm))
            user = await _userRepository.GetUserByGsmAsync(request.Email,cancellationToken: cancellationToken);

        await _authBusinessRules.UserShouldBeExistsWhenSelected(user);
        await _authBusinessRules.UserPasswordShouldBeMatch(user!, request.Password);



        AccessToken createdAccessToken = await _authService.CreateAccessToken(user, cancellationToken);
        RefreshToken createdRefreshToken = await _authService.CreateRefreshToken(user, request.IpAddress, cancellationToken);

        createdRefreshToken.CreatedDate = DateTime.UtcNow;
        RefreshToken addedRefreshToken = await _authService.AddRefreshToken(createdRefreshToken, cancellationToken);
        RefreshTokenModel refreshTokenModel = new RefreshTokenModel { UserId = addedRefreshToken.UserId, Token = addedRefreshToken.Token, ExpirationDate = addedRefreshToken.ExpirationDate };

        Role userRole = await _roleRepository.GetByIdAsync(user.RoleId, cancellationToken);

        RoleModel roleModel = new RoleModel { Id = userRole.Id, Name = userRole.Name };
  
        await _unitOfWork.CommitAsync();

        var response = new LoginCommandResponse { AccessToken = createdAccessToken, RefreshTokenModel = refreshTokenModel, RoleModel = roleModel, };
        return DataResponse<LoginCommandResponse>.SuccessResponse(response, "Başarıyla Giriş Oldunuz!"); ;

      
    }
}