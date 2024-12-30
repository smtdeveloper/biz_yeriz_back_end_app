using bizyeriz.Application.Interfaces.Repositories;
using bizYeriz.Domain.Entities.AuthEntities;
using bizYeriz.Shared.Exception.Types;
using bizYeriz.Shared.Security.Hashing;
using System.Threading;

namespace bizyeriz.Application.Features.Auths.BusinessRules;

public class AuthBusinessRules
{
    private readonly IUserRepository _userRepository;

    public AuthBusinessRules(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    private async Task throwBusinessException(string message)
    {
        throw new BusinessException(message);
    }

    public async Task UserEmailShouldBeNotExists(string email, CancellationToken cancellationToken)
    {
        bool doesExist = await _userRepository.AnyAsync(u => u.Email == email, cancellationToken);

        if (doesExist)
        {
            await throwBusinessException("Email zaten mevcut!");
        }
    }

    public async Task UserGsmShouldBeNotExists(string gsm, CancellationToken cancellationToken)
    {
        bool doesExist = await _userRepository.AnyAsync(u => u.Gsm == gsm, cancellationToken);

        if (doesExist)
            await throwBusinessException("Telefon numarası zaten mevcut!");        
    }

    public async Task UserShouldBeExistsWhenSelected(User? user)
    {
        if (user == null)
            await throwBusinessException("Böyle bir kayıt bulunamadı!");
    }
    public async Task UserPasswordShouldBeMatch(User user, string password)
    {
        if (!HashingHelper.VerifyPasswordHash(password, user!.PasswordHash))
            await throwBusinessException("Böyle bir kayıt bulunamadı!");
    }


}