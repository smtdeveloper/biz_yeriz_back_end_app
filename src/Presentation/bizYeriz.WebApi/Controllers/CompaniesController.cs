using bizyeriz.Application.Features.Companies.Commands.AddCompany;
using bizyeriz.Application.Features.Companies.Commands.DeleteCompany;
using bizyeriz.Application.Features.Companies.Commands.UpdateCompany;
using bizyeriz.Application.Features.Companies.Queries.GetAllCompanies;
using bizyeriz.Application.Features.Companies.Queries.GetAllFilters;
using bizyeriz.Application.Features.Companies.Queries.GetCompanyById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace bizYeriz.WebApi.Controllers;

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
    [Authorize(Policy = "AddCompany")]
    public async Task<IActionResult> Add([FromBody] AddCompanyCommand addCompanyQuery, CancellationToken cancellationToken) => Ok(await _mediator.Send(addCompanyQuery,cancellationToken)); 

    [HttpPut("update")]
    [Authorize(Policy = "UpdateCompany")]
    public async Task<IActionResult> Update([FromBody] UpdateCompanyCommand updateCompanyQuery, CancellationToken cancellationToken) => Ok(await _mediator.Send(updateCompanyQuery, cancellationToken));
    
    [HttpDelete("delete/{id}")]
    [Authorize(Policy = "DeleteCompany")]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        var deleteCompanyQuery = new DeleteCompanyCommand(id);
        var result = await _mediator.Send(deleteCompanyQuery,cancellationToken);
        return Ok(result);
    }

    [HttpGet("detail/{id}")]
    public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
    {
        var query = new GetCompanyByIdQuery(id);
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    [HttpGet("list")]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var query = new GetAllCompaniesQuery();
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    [HttpPost("filter-companies")]
    public async Task<IActionResult> GetFilterNearbyCompanies([FromBody] GetFilterNearbyCompaniesQuery getNearbyCompaniesQuery, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(getNearbyCompaniesQuery, cancellationToken);
        return Ok(result);
    }

    [HttpGet("GetAllFilters")]
    public async Task<IActionResult> GetAllFilters(CancellationToken cancellationToken)
    {
        var query = new GetAllFiltersQuery();
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }
}