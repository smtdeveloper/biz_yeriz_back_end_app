using bizyeriz.Application.Features.Foods.Commands.AddCompany;
using bizyeriz.Application.Features.Foods.Commands.DeleteFood;
using bizyeriz.Application.Features.Foods.Commands.UpdateFood;
using bizyeriz.Application.Features.Foods.Queries.GetAllFoods;
using bizyeriz.Application.Features.Foods.Queries.GetFoodById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace bizYeriz.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FoodController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] AddFoodQuery addFoodQuery)
        {
            if (addFoodQuery == null)
                return BadRequest("Invalid company data.");

            try
            {
                var result = await _mediator.Send(addFoodQuery);
                return Ok(result);
            }
            catch (Exception ex) { return StatusCode(500, $"An error occurred: {ex.Message}"); }
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] UpdateFoodQuery updateFoodQuery)
        {
            if (updateFoodQuery.Id == null)
                return BadRequest("Invalid company data.");

            try
            {
                var result = await _mediator.Send(updateFoodQuery);
                return Ok(result);
            }
            catch (Exception ex) { return StatusCode(500, $"An error occurred: {ex.Message}"); }
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
                return BadRequest("Invalid company ID.");

            try
            {
                var deleteCompanyQuery = new DeleteFoodQuery(id);
                var result = await _mediator.Send(deleteCompanyQuery);

                return Ok(result);
            }
            catch (Exception ex) { return StatusCode(500, $"An error occurred: {ex.Message}"); }
        }

        [HttpGet("getbyid/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            if (id == null)
                return BadRequest("Invalid company ID.");

            try  
            {
                var query = new GetFoodByIdQuery(id);
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
                var query = new GetAllFoodsQuery();
                var result = await _mediator.Send(query);
                return Ok(result);
            }
            catch (Exception ex) { return StatusCode(500, $"An error occurred: {ex.Message}"); }
        }

    }
}
