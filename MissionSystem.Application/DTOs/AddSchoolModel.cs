using System.ComponentModel.DataAnnotations.Schema;
using MissionSystem.Domain.Entity;

namespace MissionSystem.Application.DTOs
{
    public class AddSchoolModel
    {
        public string? SchoolName { get; set; }
        public string? ImageUrl { get; set; }
        public Guid CordinatorId { get; set; }
        public Guid AddressId { get; set; }
    }
}
