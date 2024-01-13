using MediatR;

namespace MissionSystem.Application.Features.Categories.Commands.Models
{
    public class DeleteCategoryCommand : IRequest<string>
    {
        public Guid CategoryId { get; set; }
    }
}
