using System.ComponentModel.DataAnnotations.Schema;

namespace MissionSystem.Domain.Entity
{
    public class Address : BaseEntity
    {
        public string? CityName { get; set; }
        public string? Street { get; set; }

        /*----- Relations -----*/

        // Address has one Government
        [ForeignKey(nameof(Government))]
        public Guid? GovernmentId { get; set; }
        public Government? Government { get; set; }
    }
}
