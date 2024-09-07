using System.ComponentModel.DataAnnotations.Schema;

namespace MissionSystem.Domain.Entity
{
    public class Category : BaseEntity
    {
        public string? Name { get; set; }
        public string? Description { get; set; }

        /*----- Relations -----*/

        // Category has many Missions
        [ForeignKey("CategoryId")]
        public ICollection<Mission>? Missions { get; set; }
    }
}
