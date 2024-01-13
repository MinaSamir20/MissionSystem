namespace MissionSystem.Application.DTOs.Dtos
{
    public class AddressDto
    {
        public string? CityName { get; set; }
        public string? Street { get; set; }

        public Guid? GovernmentId { get; set; }
    }
}