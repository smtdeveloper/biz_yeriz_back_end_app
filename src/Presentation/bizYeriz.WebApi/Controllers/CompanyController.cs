using MediatR;
using Microsoft.AspNetCore.Mvc;
using bizyeriz.Application.Features.Companies.Commands.AddCompany;
using bizyeriz.Application.Features.Companies.Commands.UpdateCompany;
using bizyeriz.Application.Features.Companies.Commands.DeleteCompany;
using bizyeriz.Application.Features.Companies.Queries.GetCompanyById;
using bizyeriz.Application.Features.Companies.Queries.GetAllCompanies;
using bizyeriz.Application.Features.Companies.Queries.GetNearbyCompanies;

namespace bizYeriz.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CompanyController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] AddCompanyCommand addCompanyQuery)
        {
            var result = await _mediator.Send(addCompanyQuery);
            return Ok(result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] UpdateCompanyCommand updateCompanyQuery)
        {
            var result = await _mediator.Send(updateCompanyQuery);
            return Ok(result);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var deleteCompanyQuery = new DeleteCompanyCommand(id);
            var result = await _mediator.Send(deleteCompanyQuery);

            return Ok(result);
        }

        [HttpGet("getbyid/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var query = new GetCompanyByIdQuery(id);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllCompaniesQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPost("get-nearby-companies")]
        public async Task<IActionResult> GetNearbyCompanies([FromQuery] GetNearbyCompaniesQuery getNearbyCompaniesQuery)
        {
            var result = await _mediator.Send(getNearbyCompaniesQuery);
            return Ok(result);
        }

    }

}