using bizyeriz.Application.Features.Auths.Commands.Login;
using bizyeriz.Application.Features.Auths.Commands.RegisterUser;
using Microsoft.AspNetCore.Mvc;

namespace bizYeriz.WebApi.Controllers;

public class AuthsController : BaseController
{
    public AuthsController()
    {        
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginCommand loginCommand)
    {
        var result = await Mediator.Send(loginCommand);
        return Ok(result);
    }

    [HttpPost("customer-register")]       
    public async Task<IActionResult> CustomerRegister([FromBody] RegisterCustomerCommand registerUserCommand)
    {
        var result = await Mediator.Send(registerUserCommand);
        return Ok(result);
    }

}