using MissionSystem.Domain.Entity.Identity;

namespace TablerSystem.Application.Features.Schools.Queries.Models
{
    public class CoordinatorDto
    {
        public string? FacebookAccount { get; set; }
        public string? GmailAccount { get; set; }
        public User? User { get; set; }
    }
}
