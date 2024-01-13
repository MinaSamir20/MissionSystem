using MediatR;
using MissionSystem.Domain.Entity;

namespace MissionSystem.Application.Features.Addresses.Commands.Models
{
    public class UpdateAddressCommand : IRequest<Address>
    {
        public string? CityName { get; set; }
        public string? Street { get; set; }
        public Guid GovermentId { get; set; }
    }
}
