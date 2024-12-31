using bizyeriz.Application.Features.Foods.Commands.AddCompany;
using bizyeriz.Application.Features.Foods.Commands.DeleteFood;
using bizyeriz.Application.Features.Foods.Commands.UpdateFood;
using bizyeriz.Application.Features.Foods.Queries.GetAllFoods;
using bizyeriz.Application.Features.Foods.Queries.GetFoodById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace bizYeriz.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FoodsController : ControllerBase
{
    private readonly IMediator _mediator;

    public FoodsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("add")]
    [Authorize(Policy = "AddFood")]
    public async Task<IActionResult> Add([FromBody] AddFoodCommand addFoodQuery, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(addFoodQuery);
        return Ok(result);
    }

    [HttpPut("update")]
    [Authorize(Policy = "UpdateFood")]
    public async Task<IActionResult> Update([FromBody] UpdateFoodCommand updateFoodQuery, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(updateFoodQuery, cancellationToken);
        return Ok(result);
    }

    [HttpDelete("delete/{id}")]
    [Authorize(Policy = "DeleteFood")]
    public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
    {
        var deleteCompanyQuery = new DeleteFoodCommand(id);
        var result = await _mediator.Send(deleteCompanyQuery,cancellationToken);
        return Ok(result);
    }

    [HttpGet("{id}")]   
    public async Task<IActionResult> GetById(int id, CancellationToken cancellationToken)
    {
        var query = new GetFoodByIdQuery(id);
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    [HttpGet("list")]   
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var query = new GetAllFoodsQuery();
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }
}

