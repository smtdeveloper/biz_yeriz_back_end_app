using bizYeriz.Shared.Responses;
using System.Text.Json.Serialization;

namespace bizyeriz.Application.Features.Auths.Commands.Login;

public class LoginCommand : IRequest<IDataResponse<LoginCommandResponse>>
{
    public string? Email { get; set; }
    public string? Gsm { get; set; }
    public string Password { get; set; }
    [JsonIgnore]
    public string? IpAddress { get; set; }
}