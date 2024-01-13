using MissionSystem.Application.DTOs.Dtos;
using MissionSystem.Domain.Entity;
using MissionSystem.Domain.Entity.Identity;

namespace MissionSystem.Application.Features.Coordinators.Queries.Response
{
    public class GetCoordinatorListResponse
    {
        public string? Id { get; set; }
        public string? FacebookAccount { get; set; }
        public string? GmailAccount { get; set; }
        public User? User { get; set; }
        public Address? Address { get; set; }
        public ICollection<SchoolDto>? Schools { get; set; } = null;
        public ICollection<MissionDto>? Missions { get; set; } = null;
    }
}
