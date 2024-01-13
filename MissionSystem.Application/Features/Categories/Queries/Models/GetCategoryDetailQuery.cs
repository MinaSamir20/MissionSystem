using MediatR;
using MissionSystem.Application.Features.Categories.Queries.Response;

namespace MissionSystem.Application.Features.Categories.Queries.Models
{
    public class GetCategoryDetailQuery : IRequest<GetCategoryListResponse>
    {
        public Guid CategoryId { get; set; }
    }
}
