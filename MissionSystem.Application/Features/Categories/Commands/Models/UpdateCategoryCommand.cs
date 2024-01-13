using MediatR;
using MissionSystem.Domain.Entity;

namespace MissionSystem.Application.Features.Categories.Commands.Models
{
    public class UpdateCategoryCommand : IRequest<Category>
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
    }
}
