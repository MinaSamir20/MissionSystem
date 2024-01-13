using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MissionSystem.Application.Features.Governments.Queries.Models;
using MissionSystem.Application.IServices;
using MissionSystem.Application.Services;
using MissionSystem.Domain.Entity;
using MissionSystem.Infrastructure.Database;

namespace MissionSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GovernmentsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly GovernmentService _governmentService;

        public GovernmentsController(IMediator mediator, GovernmentService governmentService)
        {
            _mediator = mediator;
            _governmentService = governmentService;
        }

        [HttpPost]
        [Route("SeedAllGovernments")]
        public async Task<IActionResult> SeedGovernments()
        {
            var seedGovernment = await _governmentService.SeedGovernmentAsync();

            return Ok(seedGovernment);
        }
        [Authorize]
        [HttpGet("GetAllGovernments")]
        public async Task<IActionResult> GetAllGovernments()
        {
            var result = await _mediator.Send(new GetGovernmentListQuery());
            return Ok(result);
        }
    }
}
