using bizyeriz.Application.Features.CuisineCategories.Queries.GetAllCuisineCategories;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace bizYeriz.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CuisineCategoriesController : ControllerBase
{
    private readonly IMediator _mediator;

    public CuisineCategoriesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("list")]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var query = new GetAllCuisineCategoriesQuery();
        var result = await _mediator.Send(query);
        return Ok(result);
    }

}