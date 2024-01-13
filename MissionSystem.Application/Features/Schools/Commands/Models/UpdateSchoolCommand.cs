using MediatR;
using Microsoft.AspNetCore.Http;
using MissionSystem.Domain.Entity;

namespace MissionSystem.Application.Features.Schools.Commands.Models
{
    public class UpdateSchoolCommand : IRequest<School>
    {
        public string? SchoolName { get; set; }
        public FormFile? ImageUrl { get; set; }
        public Guid AddressId { get; set; }
        public Guid CoordinatorId { get; set; }
        public Guid MissionId { get; set; }
    }
}
