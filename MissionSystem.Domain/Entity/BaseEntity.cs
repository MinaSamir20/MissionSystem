namespace MissionSystem.Domain.Entity
{
    public class BaseEntity
    {
        public Guid Id { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public DateTime DeletedOn { get; set; }
        public DateTime UpdateOn { get; set; }
        public bool IsDeleted { get; set; }
        public bool Status { get; set; } = false;
    }
}
