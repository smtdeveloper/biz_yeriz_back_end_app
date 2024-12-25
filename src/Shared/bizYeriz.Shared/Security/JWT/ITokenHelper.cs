using bizYeriz.Domain.Entities.AuthEntities;

namespace bizYeriz.Shared.Security.JWT;

public interface ITokenHelper
{
    public AccessToken CreateToken(User user, IList<Permission> operationClaims);
    public RefreshToken CreateRefreshToken(User user, string ipAddress);
}