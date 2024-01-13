using MediatR;
using MissionSystem.Application.Features.Categories.Queries.Response;

namespace MissionSystem.Application.Features.Categories.Queries.Models
{
    public class GetCategoryListQuery : IRequest<IEnumerable<GetCategoryListResponse>>
    {
    }
}
