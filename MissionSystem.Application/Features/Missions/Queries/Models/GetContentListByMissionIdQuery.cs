using MediatR;
using MissionSystem.Application.DTOs.Dtos;

namespace MissionSystem.Application.Features.Missions.Queries.Models
{
    public class GetContentListByMissionIdQuery : IRequest<IEnumerable<ContentDto>>
    {
            public Guid MissionId { get; set; }
    }
}
