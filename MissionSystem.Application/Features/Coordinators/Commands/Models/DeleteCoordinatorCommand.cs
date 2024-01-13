using MediatR;

namespace MissionSystem.Application.Features.Coordinators.Commands.Models
{
    public class DeleteCoordinatorCommand : IRequest<string>
    {
        public Guid CoordinatorId { get; set; }
    }
}
