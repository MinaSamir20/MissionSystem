namespace MissionSystem.Application.Features.Addresses.Queries.Response
{
    public class GetAddressListResponse
    {
        public string? CityName { get; set; }
        public string? Street { get; set; }
        public Guid GovernmentId { get; set; }
    }
}
