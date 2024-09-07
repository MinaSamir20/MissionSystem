namespace MissionSystem.Application.Features.Categories.Queries.Response
{
    public class GetCategoryListResponse
    {
        public Guid Id { get; set; }
        public string? Name { get; set; } = null;
        public string? Description { get; set; } = null;
    }
}
