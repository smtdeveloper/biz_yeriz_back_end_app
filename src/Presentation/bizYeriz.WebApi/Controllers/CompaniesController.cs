using bizyeriz.Application.Features.Companies.Commands.AddCompany;
using bizyeriz.Application.Features.Companies.Commands.DeleteCompany;
using bizyeriz.Application.Features.Companies.Commands.UpdateCompany;
using bizyeriz.Application.Features.Companies.Queries.GetAllCompanies;
using bizyeriz.Application.Features.Companies.Queries.GetAllFilters;
using bizyeriz.Application.Features.Companies.Queries.GetCompanyById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace bizYeriz.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CompaniesController(IMediator mediator)
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

        [HttpGet("detail/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var query = new GetCompanyByIdQuery(id);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("list")]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllCompaniesQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPost("filter-companies")]
        public async Task<IActionResult> GetFilterNearbyCompanies([FromBody] GetFilterNearbyCompaniesQuery getNearbyCompaniesQuery)
        {
            var result = await _mediator.Send(getNearbyCompaniesQuery);
            return Ok(result);
        }

        [HttpGet("GetAllFilters")]
        public async Task<IActionResult> GetAllFilters()
        {
            var query = new GetAllFiltersQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

    }

}