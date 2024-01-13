using System.ComponentModel.DataAnnotations;

namespace MissionSystem.Infrastructure
{
    public class UpdatePermissionDto
    {
        [Required(ErrorMessage = "UserName is required")]
        public string? UserName { get; set; }

    }
}
