using bizyeriz.Application.Features.Auths.BusinessRules;
using bizyeriz.Application.Interfaces.Repositories;
using bizyeriz.Application.Interfaces.UnitOfWork;
using bizyeriz.Application.Services.AuthService;
using bizYeriz.Domain.Entities.AuthEntities;
using bizYeriz.Shared.Responses;
using bizYeriz.Shared.Security.Hashing;
using FluentValidation;

namespace bizyeriz.Application.Features.Auths.Commands.RegisterUser;

public class RegisterCustomerCommandHandlers : IRequestHandler<RegisterCustomerCommand, IDataResponse<RegisterCustomerCommandResponse>>
{
    
    private readonly IUserRepository _userRepository;
    private readonly IRoleRepository _roleRepository;
    private readonly IAuthService _authService;    
    private readonly IUnitOfWork _unitOfWork;
    private readonly AuthBusinessRules _authBusinessRules;
    private readonly IValidator<RegisterCustomerCommand> _validator;
    public RegisterCustomerCommandHandlers(
        IUserRepository userRepository, 
        IRoleRepository roleRepository, 
        IAuthService authService, 
        IUnitOfWork unitOfWork, 
        AuthBusinessRules authBusinessRules, 
        IValidator<RegisterCustomerCommand> validator)
    {
        _userRepository = userRepository;
        _roleRepository = roleRepository;
        _authService = authService;        
        _unitOfWork = unitOfWork;
        _authBusinessRules = authBusinessRules;
        _validator = validator;

    }
    public async Task<IDataResponse<RegisterCustomerCommandResponse>> Handle(RegisterCustomerCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
            return DataResponse<RegisterCustomerCommandResponse>.FailureResponse(string.Join(" - ", validationResult.Errors.Select(e => e.ErrorMessage)));
        
        if (!string.IsNullOrEmpty(request.Email))
            await _authBusinessRules.UserEmailShouldBeNotExists(request.Email, cancellationToken);

        if (!string.IsNullOrEmpty(request.Gsm))
            await _authBusinessRules.UserGsmShouldBeNotExists(request.Gsm, cancellationToken);

        HashingHelper.CreatePasswordHash(request.Password,passwordHash: out string passwordHash);

        Guid customerRolId = Guid.Parse("98f4236e-da0e-4f3e-950c-09d111408083");
        string customerRolName = "Customer";
        User newUser = new()
        {
            Email = request.Email,
            Gsm = request.Gsm,
            PasswordHash = passwordHash,
            RoleId = customerRolId,
            UserTypes = bizYeriz.Domain.Enums.UserTypes.Customer,
            IsActive = true,
            IsDelete = false,  
            CreatedDate = DateTime.UtcNow
        };

        User createdUser = await _userRepository.AddAsync(newUser,cancellationToken);
        AccessToken createdAccessToken = await _authService.CreateAccessToken(createdUser,cancellationToken);
        RefreshToken createdRefreshToken = await _authService.CreateRefreshToken(createdUser,request.IpAddress,cancellationToken);

        createdRefreshToken.CreatedDate = DateTime.UtcNow;
        RefreshToken addedRefreshToken = await _authService.AddRefreshToken(createdRefreshToken , cancellationToken);
        RefreshTokenModel refreshTokenModel = new RefreshTokenModel{UserId = addedRefreshToken.UserId,Token = addedRefreshToken.Token,ExpirationDate = addedRefreshToken.ExpirationDate};        
        RoleModel roleModel = new RoleModel{Id = customerRolId, Name = customerRolName };

        await _unitOfWork.CommitAsync();

        var response = new RegisterCustomerCommandResponse{ AccessToken = createdAccessToken, RefreshTokenModel = refreshTokenModel, RoleModel = roleModel,};
        return DataResponse<RegisterCustomerCommandResponse>.SuccessResponse(response, "Başarıyla Kayıt Oldunuz!"); ;
    }
}