using System.ComponentModel.DataAnnotations.Schema;

namespace MissionSystem.Domain.Entity
{
    public class ContentDetail : BaseEntity
    {
        public string? Question { get; set; }
        public string? Answer { get; set; }

        [ForeignKey(nameof(Mission))]
        public Guid MissionId { get; set; }
        public Mission? Mission { get; set; }

    }
}
