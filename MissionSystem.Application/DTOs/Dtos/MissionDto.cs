using MissionSystem.Domain.Enums;

namespace MissionSystem.Application.DTOs.Dtos
{
    public class MissionDto
    {
        public string? Title { get; set; }
        public DateTime? DateLine { get; set; }
        public Status Status { get; set; }
    }
}