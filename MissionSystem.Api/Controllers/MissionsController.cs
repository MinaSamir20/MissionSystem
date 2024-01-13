using MediatR;
using Microsoft.AspNetCore.Mvc;
using MissionSystem.Application.Features.Missions.Commands.Models;
using MissionSystem.Application.Features.Missions.Queries.Models;
using MissionSystem.Domain.Entity;

namespace MissionSystem.WebApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class MissionsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MissionsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetAllMissions")]
        public async Task<IActionResult> GetAllMissions(Guid? CoordinatorId = null)
        {   
            var result = await _mediator.Send(new GetMissionListQuery(CoordinatorId));

            return Ok(result);
        }


        [HttpGet("GetMissionById")]
        public async Task<IActionResult> GetMissionById(GetMissionDetailQuery query)
        {
            var result = await _mediator.Send(query);
            return result == null ? NotFound() : Ok(result);
        }

        [HttpGet("Contents")]
        public async Task<IActionResult> GetContentsByMission(GetContentListByMissionIdQuery query)
        {
            var result = await _mediator.Send(query);
            return result == null ? NotFound() : Ok(result);
        }

        [HttpPost("CreateMission")]
        public async Task<IActionResult> CreateMission([FromForm] CreateMissionCommand command)
        {
            var result = await _mediator.Send(command);
            return result ==null? BadRequest("Mission creation failed") : Ok(result);
        }

        [HttpPut("UpdateMission")]
        public async Task<IActionResult> UpdateMission(UpdateMissionCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("RemoveMission")]
        public async Task<IActionResult> RemoveMission(DeleteMissionCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
