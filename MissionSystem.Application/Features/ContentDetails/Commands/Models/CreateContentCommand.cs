using MediatR;

namespace MissionSystem.Application.Features.ContentDetails.Commands.Models
{
    public class CreateContentCommand : IRequest<string>
    {
        public string? Question { get; set; }
        public string? Answer { get; set; }
        public Guid? MissionId { get; set; } = Guid.Empty;
    }
}
