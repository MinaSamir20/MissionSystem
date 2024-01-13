using MissionSystem.Domain.Enums;

namespace MissionSystem.Application.DTOs.Dtos
{
    public class UserDto
    {
        public string? NameAr { get; set; }
        public string? NameEn { get; set; }
        public Gender Gender { get; set; }
        public string? ImageUrl { get; set; }
    }
}