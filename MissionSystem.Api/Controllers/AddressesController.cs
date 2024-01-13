using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MissionSystem.Application.Features.Addresses.Commands.Models;
using MissionSystem.Application.Features.Addresses.Queries.Models;

namespace MissionSystem.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AddressesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AddressesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetAllAddresses")]
        public async Task<IActionResult> GetAllAddresses()
        {
            var result = await _mediator.Send(new GetAddressListQuery());
            return Ok(result);
        }


        [HttpGet("GetAddressById")]
        public async Task<IActionResult> GetAddressById([FromQuery] GetAddressDetailQuery query)
        {
            var result = await _mediator.Send(query);
            return result == null ? NotFound() : Ok(result);
        }

        [HttpPost("CreateAddress")]
        public async Task<IActionResult> CreateSchool(CreateAddressCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut("UpdateAddress")]
        public async Task<IActionResult> UpdateAddress(UpdateAddressCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("RemoveAddress")]
        public async Task<IActionResult> RemoveAddress(DeleteAddressCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
