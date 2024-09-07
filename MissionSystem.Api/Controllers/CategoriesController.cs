using MediatR;
using Microsoft.AspNetCore.Mvc;
using MissionSystem.Application.Features.Categories.Commands.Models;
using MissionSystem.Application.Features.Categories.Queries.Models;

namespace MissionSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("AllCategories")]
        public async Task<IActionResult> GetAllCategories()
        {
            var result = await _mediator.Send(new GetCategoryListQuery());
            return Ok(result);
        }


        [HttpGet("CategoryById")]
        public async Task<IActionResult> GetCategoryById([FromQuery] GetCategoryDetailQuery query)
        {
            var result = await _mediator.Send(query);
            return result == null ? NotFound() : Ok(result);
        }

        [HttpPost("CreateCategory")]
        public async Task<IActionResult> CreateCategory(CreateCategoryCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut("UpdateCategory")]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("RemoveCategory")]
        public async Task<IActionResult> RemoveCategory(DeleteCategoryCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
