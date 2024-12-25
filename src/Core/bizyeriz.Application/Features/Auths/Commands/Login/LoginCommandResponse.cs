using bizYeriz.Domain.Entities.AuthEntities;

namespace bizyeriz.Application.Features.Auths.Commands.Login;

public class LoginCommandResponse
{
    public AccessToken AccessToken { get; set; }
    public RefreshToken RefreshToken { get; set; }
    public Role Role { get; set; }
}