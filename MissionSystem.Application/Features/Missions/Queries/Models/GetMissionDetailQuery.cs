using MediatR;
using MissionSystem.Application.Features.Missions.Queries.Response;

namespace MissionSystem.Application.Features.Missions.Queries.Models
{
    public class GetMissionDetailQuery : IRequest<GetMissionListResponse>
    {
        public Guid MissionId { get; set; }
    }
}
