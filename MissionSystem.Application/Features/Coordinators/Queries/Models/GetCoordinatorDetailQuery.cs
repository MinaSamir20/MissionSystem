using MediatR;
using MissionSystem.Application.Features.Coordinators.Queries.Response;

namespace MissionSystem.Application.Features.Coordinators.Queries.Models
{
    public class GetCoordinatorDetailQuery : IRequest<GetCoordinatorListResponse>
    {
        public Guid CoordinatorId { get; set; }
    }
}
