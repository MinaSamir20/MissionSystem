using MediatR;
using MissionSystem.Domain.Entity;

namespace MissionSystem.Application.Features.ContentDetails.Commands.Models
{
    public class UpdateContentCommand : IRequest<ContentDetail>
    {
        public string? Question { get; set; }
        public string? Answer { get; set; }
        public Guid MissionId { get; set; }
    }
}
