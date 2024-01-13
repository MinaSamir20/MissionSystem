using MediatR;

namespace MissionSystem.Application.Features.Coordinators.Commands.Models
{
    public class CreateCoordinatorCommand : IRequest<string>
    {
        public string? FacebookAccount { get; set; }
        public string? GmailAccount { get; set; }
        public string? UserId { get; set; }
        public Guid AddressId { get; set; }
        public ICollection<Guid>? SchoolIds { get; set; }
        public ICollection<Guid>? MissionIds { get; set; }
    }
}
