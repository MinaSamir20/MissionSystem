using MediatR;
using MissionSystem.Application.Features.ContentDetails.Queries.Response;

namespace MissionSystem.Application.Features.ContentDetails.Queries.Models
{
    public class GetContentListQuery : IRequest<IEnumerable<GetContentListResponse>>
    {
    }
}
