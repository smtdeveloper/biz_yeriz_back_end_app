using MediatR;
using Microsoft.AspNetCore.Mvc;
using bizyeriz.Application.Features.Companies.Commands.AddCompany;
using bizyeriz.Application.Features.Companies.Commands.UpdateCompany;
using bizyeriz.Application.Features.Companies.Commands.DeleteCompany;
using bizyeriz.Application.Features.Companies.Queries.GetCompanyById;
using bizyeriz.Application.Features.Companies.Queries.GetAllCompanies;

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
        public async Task<IActionResult> Add([FromBody] AddCompanyQuery addCompanyQuery)
        {
            if (addCompanyQuery == null)
                return BadRequest("Invalid company data.");

            try
            {
                var result = await _mediator.Send(addCompanyQuery);
                return Ok(result);
            }
            catch (Exception ex) { return StatusCode(500, $"An error occurred: {ex.Message}"); }
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] UpdateCompanyQuery updateCompanyQuery)
        {
            if (updateCompanyQuery.Id == null)
                return BadRequest("Invalid company data.");

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
            if (id == Guid.Empty)
                return BadRequest("Invalid company ID.");

            try
            {
                var deleteCompanyQuery = new DeleteCompanyQuery(id);
                var result = await _mediator.Send(deleteCompanyQuery);

                return Ok(result);
            }
            catch (Exception ex) { return StatusCode(500, $"An error occurred: {ex.Message}"); }
        }

        [HttpGet("getbyid/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            if (id == Guid.Empty)
                return BadRequest("Invalid company ID.");

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

    }
}