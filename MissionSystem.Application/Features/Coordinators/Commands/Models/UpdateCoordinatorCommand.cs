using MediatR;
using MissionSystem.Domain.Entity;

namespace MissionSystem.Application.Features.Coordinators.Commands.Models
{
    public class UpdateCoordinatorCommand : IRequest<Coordinator>
    {
        public string? FacebookAccount { get; set; }
        public string? GmailAccount { get; set; }
        public Guid UserId { get; set; }
        public Guid AddressId { get; set; }
        public Guid SchoolId { get; set; }
        public Guid MissionId { get; set; }

    }
}
