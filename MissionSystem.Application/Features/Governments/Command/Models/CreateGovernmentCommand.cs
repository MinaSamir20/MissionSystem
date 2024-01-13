using MediatR;

namespace MissionSystem.Application.Features.Governments.Command.Models
{
    public class CreateGovernmentCommand : IRequest<string>
    {
        public string? GovernmentNameAr { get; set; }
        public string? GovernmentNameEn { get; set; }
    }
}
