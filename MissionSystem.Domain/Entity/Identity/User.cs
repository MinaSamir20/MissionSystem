
using Microsoft.AspNetCore.Identity;
using MissionSystem.Domain.Enums;

namespace MissionSystem.Domain.Entity.Identity
{
    public class User : IdentityUser
    {
        public string? NameAr { get; set; }
        public string? NameEn { get; set; }
        public Gender Gender { get; set; }
        public string? ImageUrl { get; set; }
        public string CreateOn { get; set; }
        public User() => CreateOn = DateTime.Now.ToShortDateString();
    }
}
