using MediatR;
using Microsoft.AspNetCore.Http;

namespace MissionSystem.Application.Features.Schools.Commands.Models
{
    public class CreateSchoolCommand : IRequest<string>
    {
        public string? SchoolName { get; set; }
        public IFormFile? ImageUrl { get; set; }
        public Guid AddressId { get; set; }
        public Guid CoordinatorId { get; set; }
    }
}
