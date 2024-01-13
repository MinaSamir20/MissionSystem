using MediatR;
using MissionSystem.Domain.Entity;

namespace MissionSystem.Application.Features.Addresses.Commands.Models
{
    public class DeleteAddressCommand : IRequest<string>
    {
        public Guid AddressId { get; set; }
    }
}
