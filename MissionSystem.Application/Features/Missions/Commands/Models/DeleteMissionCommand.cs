using MediatR;
namespace MissionSystem.Application.Features.Missions.Commands.Models
{
    public class DeleteMissionCommand : IRequest<string>
    {
        public Guid MissionId { get; set; }
    }
}
