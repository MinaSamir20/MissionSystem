using MissionSystem.Application.DTOs.Dtos;

namespace MissionSystem.Application.Features.Missions.Queries.Response
{
    public class GetMissionListResponse
    {
        public string? Title { get; set; }
        public string? AttachmentUrl { get; set; }
        public CategoryDto? Categories { get; set; } = null;
        public ICollection<ContentDto>? Contents { get; set; } = null;
        public ICollection<CoordinatorDto>? Coordinators { get; set; } = null;
        public ICollection<SchoolDto>? Schools { get; set; }
    }
}
