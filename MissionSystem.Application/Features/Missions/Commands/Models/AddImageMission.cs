using Microsoft.AspNetCore.Http;

namespace MissionSystem.Application.Features.Missions.Commands.Models
{
    public class AddImageMission
    {
        public Guid Id { get; set; }
        public IFormFile? AttachmentUrl { get; set; }
    }
}
