using MediatR;
using MissionSystem.Application.Features.Schools.Queries.Response;

namespace MissionSystem.Application.Features.Schools.Queries.Models
{
    public class GetSchoolListQuery : IRequest<IEnumerable<GetSchoolListResponse>>
    {
        public GetSchoolListQuery(Guid? coordinatorId = null)
        {
            CoordinatorId = coordinatorId;
        }
        public Guid? CoordinatorId { get; set; } = null;
    }
}
