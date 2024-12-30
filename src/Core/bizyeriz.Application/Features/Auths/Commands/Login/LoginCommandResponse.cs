using bizyeriz.Application.Features.Auths.Commands.RegisterUser;
using bizYeriz.Domain.Entities.AuthEntities;

namespace bizyeriz.Application.Features.Auths.Commands.Login;

public class LoginCommandResponse
{
    public AccessToken AccessToken { get; set; }
    public RefreshTokenModel RefreshTokenModel { get; set; }
    public RoleModel RoleModel { get; set; }
}