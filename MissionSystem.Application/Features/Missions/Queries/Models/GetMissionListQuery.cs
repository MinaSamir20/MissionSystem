using MediatR;
using MissionSystem.Application.Features.Missions.Queries.Response;

namespace MissionSystem.Application.Features.Missions.Queries.Models
{
    public class GetMissionListQuery : IRequest<IEnumerable<GetMissionListResponse>>
    {
        public GetMissionListQuery(Guid? coordinatorId = null)
        {
            CoordinatorId = coordinatorId;
        }

        public Guid? CoordinatorId { get; set; } = null;
    }
}
