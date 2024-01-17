using MediatR;
using Microsoft.AspNetCore.Mvc;
using MissionSystem.Application.Features.Coordinators.Commands.Models;
using MissionSystem.Application.Features.Coordinators.Queries.Models;

namespace MissionSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoordinatorsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CoordinatorsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("AllCoordinators")]
        public async Task<IActionResult> GetAllCoordinators()
        {
            var result = await _mediator.Send(new GetCoordinatorListQuery());
            return Ok(result);
        }


        [HttpGet("CoordinatorById")]
        public async Task<IActionResult> GetCoordinatorById([FromQuery] GetCoordinatorDetailQuery query)
        {
            var result = await _mediator.Send(query);
            return result == null ? NotFound() : Ok(result);
        }

        [HttpPost("CreateCoordinator")]
        public async Task<IActionResult> CreateCoordinator(CreateCoordinatorCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut("UpdateCoordinator")]
        public async Task<IActionResult> UpdateCoordinator(UpdateCoordinatorCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("RemoveCoordinator")]
        public async Task<IActionResult> RemoveCoordinator(DeleteCoordinatorCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
