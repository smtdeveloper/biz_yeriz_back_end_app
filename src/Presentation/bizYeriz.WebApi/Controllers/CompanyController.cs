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
            try
            {
                var result = await _mediator.Send(addCompanyQuery);
                return Ok(result);
            }
            catch (Exception ex) { return StatusCode(500, $"An error occurred: {ex.Message}"); }
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] UpdateCompanyCommand updateCompanyQuery)
        {
            try
            {
                var result = await _mediator.Send(updateCompanyQuery);
                return Ok(result);
            }
            catch (Exception ex) { return StatusCode(500, $"An error occurred: {ex.Message}"); }
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                var deleteCompanyQuery = new DeleteCompanyCommand(id);
                var result = await _mediator.Send(deleteCompanyQuery);

                return Ok(result);
            }
            catch (Exception ex) { return StatusCode(500, $"An error occurred: {ex.Message}"); }
        }

        [HttpGet("getbyid/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                var query = new GetCompanyByIdQuery(id);
                var result = await _mediator.Send(query);

                return Ok(result);
            }
            catch (Exception ex) { return StatusCode(500, $"An error occurred: {ex.Message}"); }
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var query = new GetAllCompaniesQuery();
                var result = await _mediator.Send(query);
                return Ok(result);
            }
            catch (Exception ex) { return StatusCode(500, $"An error occurred: {ex.Message}"); }
        }

        [HttpGet("get-nearby-companies")]
        public async Task<IActionResult> GetNearbyCompanies([FromQuery] double latitude, [FromQuery] double longitude, [FromQuery] double distance)
        {
            try
            {
                var query = new GetNearbyCompaniesQuery(latitude, longitude, distance);
                var result = await _mediator.Send(query);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }



    }
}