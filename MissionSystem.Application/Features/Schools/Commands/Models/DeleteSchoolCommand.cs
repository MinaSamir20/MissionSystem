using MediatR;

namespace MissionSystem.Application.Features.Schools.Commands.Models
{
    public class DeleteSchoolCommand : IRequest<string>
    {
        public Guid SchoolId { get; set; }
    }
}
