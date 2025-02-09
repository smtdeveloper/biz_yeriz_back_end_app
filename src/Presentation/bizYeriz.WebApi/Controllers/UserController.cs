using bizyeriz.Application.Features.Users.AddFavoriteCompany;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace bizYeriz.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseController
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("favorite-company-add")]
        public async Task<IActionResult> AddFavoriteCompany([FromBody] AddFovoriteCompanyCommand command)
        {
            if (command.CompanyId == Guid.Empty)
                return BadRequest("Şirket ID boş olamaz.");

            //command.UserId = getUserIdFromRequest();

            var result = await _mediator.Send(command);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

    }
}