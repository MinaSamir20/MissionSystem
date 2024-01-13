using MediatR;
using MissionSystem.Application.Features.Governments.Queries.Response;

namespace MissionSystem.Application.Features.Governments.Queries.Models
{
    public class GetGovernmentListQuery : IRequest<IEnumerable<GetGovernmentListResponse>>
    {
    }
}
