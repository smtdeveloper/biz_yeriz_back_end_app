using bizyeriz.Application.Features.Auths.Commands.Login;
using bizyeriz.Application.Features.Auths.Commands.RegisterUser;
using Microsoft.AspNetCore.Mvc;

namespace bizYeriz.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : BaseController
{
    public AuthController()
    {        
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginCommand loginCommand, CancellationToken cancellationToken)
    {
        loginCommand.IpAddress = getIpAddress();
        var result = await Mediator.Send(loginCommand, cancellationToken);
        return Ok(result);
    }

    [HttpPost("customer-register")]       
    public async Task<IActionResult> CustomerRegister([FromBody] RegisterCustomerCommand registerUserCommand, CancellationToken cancellationToken)
    {
        registerUserCommand.IpAddress = getIpAddress();
        var result = await Mediator.Send(registerUserCommand, cancellationToken);
        return Ok(result);
    }

}