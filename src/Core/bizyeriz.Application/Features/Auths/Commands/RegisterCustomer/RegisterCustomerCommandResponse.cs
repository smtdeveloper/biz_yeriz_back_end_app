using bizYeriz.Domain.Entities.AuthEntities;

namespace bizyeriz.Application.Features.Auths.Commands.RegisterUser;

public class RegisterCustomerCommandResponse
{
    public AccessToken AccessToken { get; set; }
    public RefreshTokenModel RefreshTokenModel { get; set; }
    public RoleModel RoleModel { get; set; }

}

public class RoleModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }

}
    public class RefreshTokenModel
{
    public Guid UserId { get; set; }
    public string Token { get; set; }
    public DateTime ExpirationDate { get; set; }    
}