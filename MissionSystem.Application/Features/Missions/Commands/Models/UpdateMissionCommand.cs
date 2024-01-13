using MediatR;
using MissionSystem.Domain.Entity;
using MissionSystem.Domain.Enums;

namespace MissionSystem.Application.Features.Missions.Commands.Models
{
    public class UpdateMissionCommand : IRequest<Mission>
    {
        public string? Title { get; set; }
        public string? Content { get; set; }
        public string? AttachmentUrl { get; set; }
        public DateTime? DateLine { get; set; }
        public Status Status { get; set; }
        public Guid CategoryId { get; set; }
        public Guid SchoolId { get; set; }
    }
}
