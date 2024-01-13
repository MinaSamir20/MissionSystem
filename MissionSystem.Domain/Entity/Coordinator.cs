using System.ComponentModel.DataAnnotations.Schema;
using MissionSystem.Domain.Entity.Identity;

namespace MissionSystem.Domain.Entity
{
    public class Coordinator : BaseEntity
    {
        public string? FacebookAccount { get; set; }
        public string? GmailAccount { get; set; }

        /*----- Relations -----*/

        // Coordinator has one User
        [ForeignKey(nameof(User))]
        public string? UserId { get; set; }
        public User? User { get; set; }

        // Coordinator has many Schools
        public ICollection<School>? Schools { get; set; } = null;

        // Coordinator has many Missions
        [ForeignKey("CoordinatorId")]
        public ICollection<Mission>? Missions { get; set; } = null;

        // Coordinator has one Address
        [ForeignKey(nameof(Address))]
        public Guid AddressId { get; set; }
        public Address? Address { get; set; }
    }
}
