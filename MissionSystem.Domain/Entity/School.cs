using System.ComponentModel.DataAnnotations.Schema;

namespace MissionSystem.Domain.Entity
{
    public class School : BaseEntity
    {
        public string? SchoolName { get; set; }
        public string? ImageUrl { get; set; }

        /*----- Relations -----*/

        // School has one Coordinator
        [ForeignKey(nameof(Coordinator))]
        public Guid CoordinatorId { get; set; }
        public Coordinator? Coordinator { get; set; }

        // School has one Address
        [ForeignKey(nameof(Address))]
        public Guid AddressId { get; set; }
        public Address? Address { get; set; }

        // School has many Missions
        [ForeignKey("SchoolId")]
        public ICollection<Mission>? Missions { get; set; } = null;

    }
}
