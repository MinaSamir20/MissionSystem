using MissionSystem.Domain.Entity;

namespace MissionSystem.Application.Features.ContentDetails.Queries.Response
{
    public class GetContentListResponse
    {
        public string? Question { get; set; }
        public string? Answer { get; set; }
        public Mission? Mission { get; set; }
    }
}
