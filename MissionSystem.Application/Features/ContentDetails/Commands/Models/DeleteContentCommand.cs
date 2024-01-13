using MediatR;

namespace MissionSystem.Application.Features.ContentDetails.Commands.Models
{
    public class DeleteContentCommand : IRequest<string>
    {
        public Guid ContentId { get; set; }
    }
}
