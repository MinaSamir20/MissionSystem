using MediatR;

namespace MissionSystem.Application.Features.Categories.Commands.Models
{
    public class CreateCategoryCommand : IRequest<string>
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
    }
}
