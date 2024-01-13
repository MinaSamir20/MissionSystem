using System.ComponentModel.DataAnnotations.Schema;
using MissionSystem.Domain.Enums;

namespace MissionSystem.Domain.Entity
{
    public class Mission : BaseEntity
    {
        public string? Title { get; set; }
        public string? AttachmentUrl { get; set; }
        public DateTime? DateLine { get; set; }
        public string? Suggestion { get; set; }
        public string? Satisfaction { get; set; }
        public new Status Status { get; set; }

        /*----- Relations -----*/
        // Mission has many Schools
        [ForeignKey("MissionId")]
        public ICollection<School>? Schools { get; set; }

        // Mission has many Contents
        [ForeignKey("MissionId")]
        public ICollection<ContentDetail>? ContentDetails { get; set; }

        // Mission has one Category
        [ForeignKey(nameof(Categories))]
        public Guid CategoryId { get; set; }
        public Category? Categories { get; set; }

        // Mission has many Coordinators
        [ForeignKey("MissionId")]
        public ICollection<Coordinator>? Coordinators { get; set; }
    }
}
