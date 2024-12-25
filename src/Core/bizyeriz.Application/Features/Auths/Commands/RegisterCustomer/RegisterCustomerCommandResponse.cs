using bizYeriz.Domain.Entities.AuthEntities;

namespace bizyeriz.Application.Features.Auths.Commands.RegisterUser;

public class RegisterCustomerCommandResponse
{
    public AccessToken AccessToken { get; set; }
    public RefreshToken RefreshToken { get; set; }
    public Role Role { get; set; }

}