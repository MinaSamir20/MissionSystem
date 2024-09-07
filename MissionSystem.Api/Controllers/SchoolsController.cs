using MediatR;
using Microsoft.AspNetCore.Mvc;
using MissionSystem.Application.Features.Schools.Commands.Models;
using MissionSystem.Application.Features.Schools.Queries.Models;

namespace MissionSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchoolsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SchoolsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("AllSchools")]
        public async Task<IActionResult> GetAllSchools(Guid? CoordinatorId = null)
        {
            var result = await _mediator.Send(new GetSchoolListQuery(CoordinatorId));
            return Ok(result);
        }


        [HttpGet("SchoolById")]
        public async Task<IActionResult> GetSchoolById([FromQuery] GetSchoolDetailQuery query)
        {
            var result = await _mediator.Send(query);
            return result == null ? NotFound() : Ok(result);
        }

        [HttpPost("CreateSchool")]
        public async Task<IActionResult> CreateSchool([FromForm]CreateSchoolCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut("UpdateSchool")]
        public async Task<IActionResult> UpdateSchool(UpdateSchoolCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("RemoveSchool")]
        public async Task<IActionResult> RemoveSchool(DeleteSchoolCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
