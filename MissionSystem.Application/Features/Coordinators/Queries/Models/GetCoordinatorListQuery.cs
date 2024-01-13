using MediatR;
using MissionSystem.Application.Features.Coordinators.Queries.Response;

namespace MissionSystem.Application.Features.Coordinators.Queries.Models
{
    public class GetCoordinatorListQuery : IRequest<IEnumerable<GetCoordinatorListResponse>>
    {

    }
}
