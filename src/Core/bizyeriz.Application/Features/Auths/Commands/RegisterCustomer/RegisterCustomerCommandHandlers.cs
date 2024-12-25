using bizyeriz.Application.Features.Auths.BusinessRules;
using bizyeriz.Application.Interfaces.Repositories;
using bizyeriz.Application.Interfaces.UnitOfWork;
using bizyeriz.Application.Services.AuthService;
using bizYeriz.Domain.Entities.AuthEntities;
using bizYeriz.Shared.Responses;
using bizYeriz.Shared.Security.Hashing;

namespace bizyeriz.Application.Features.Auths.Commands.RegisterUser;

public class RegisterCustomerCommandHandlers : IRequestHandler<RegisterCustomerCommand, IDataResponse<RegisterCustomerCommandResponse>>
{
    
    private readonly IUserRepository _userRepository;
    private readonly IRoleRepository _roleRepository;
    private readonly IAuthService _authService;    
    private readonly IUnitOfWork _unitOfWork;
    private readonly AuthBusinessRules _authBusinessRules;
    public RegisterCustomerCommandHandlers(IUserRepository userRepository, IRoleRepository roleRepository, IAuthService authService, IUnitOfWork unitOfWork, AuthBusinessRules authBusinessRules )
    {
        _userRepository = userRepository;
        _roleRepository = roleRepository;
        _authService = authService;        
        _unitOfWork = unitOfWork;
        _authBusinessRules = authBusinessRules;
    }

    public async Task<IDataResponse<RegisterCustomerCommandResponse>> Handle(RegisterCustomerCommand request, CancellationToken cancellationToken)
    {
        // Email veya GSM varsa benzersizlik kontrolü
        if (!string.IsNullOrEmpty(request.Email))
            await _authBusinessRules.UserEmailShouldBeNotExists(request.Email, cancellationToken);

        if (!string.IsNullOrEmpty(request.Gsm))
            await _authBusinessRules.UserGsmShouldBeNotExists(request.Gsm, cancellationToken);

        // Şifreyi hash'le
        HashingHelper.CreatePasswordHash(
            request.Password,
            passwordHash: out string passwordHash
        );

        Guid customerRolId = Guid.Parse("ce44286b-9853-4634-2043-08dd0244c40d");

        // Yeni kullanıcı nesnesini oluştur
        User newUser = new()
        {
            Email = request.Email,
            Gsm = request.Gsm,
            PasswordHash = passwordHash,  // Şifre hash'ini string olarak saklıyoruz
            RoleId = customerRolId,   // Customer rolü atanıyor
            IsActive = true,
            IsDelete = false,           
        };

        User createdUser = await _userRepository.AddAsync(newUser,cancellationToken);

        AccessToken createdAccessToken = await _authService.CreateAccessToken(createdUser,cancellationToken);

        RefreshToken createdRefreshToken = await _authService.CreateRefreshToken(
            createdUser,
            request.IpAddress, 
            cancellationToken
        );
        
        RefreshToken addedRefreshToken = await _authService.AddRefreshToken(createdRefreshToken , cancellationToken);

        Role customerRol = await _roleRepository.GetByIdAsync(customerRolId,cancellationToken);

        await _unitOfWork.CommitAsync();

        // Geriye döndürülecek cevabı oluştur
        var response = new RegisterCustomerCommandResponse
        {
            AccessToken = createdAccessToken,
            RefreshToken = createdRefreshToken, 
            Role = customerRol,             
        };

        var result = DataResponse<RegisterCustomerCommandResponse>.SuccessResponse(response, "Başarıyla Kayıt Oldunuz!");
        return result;
    }

}