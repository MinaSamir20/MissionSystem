using MediatR;
using MissionSystem.Application.Features.Schools.Queries.Response;

namespace MissionSystem.Application.Features.Schools.Queries.Models
{
    public class GetSchoolDetailQuery : IRequest<GetSchoolListResponse>
    {
        public Guid SchoolId { get; set; }
    }
}
