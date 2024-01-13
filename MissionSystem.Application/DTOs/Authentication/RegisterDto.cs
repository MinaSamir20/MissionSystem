#nullable disable
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using MissionSystem.Domain.Enums;

namespace MissionSystem.Application.DTOs.Authentication
{
    public class RegisterDto
    {
        [Required(ErrorMessage = "FirstName is required")]
        public string NameAr { get; set; }

        [Required(ErrorMessage = "LastName is required")]
        public string NameEn { get; set; }

        [Required(ErrorMessage = "PhoneNumber is required")]
        [Phone]
        public string PhoneNumber { get; set; }
        
        [Required(ErrorMessage = "Gender is required")]
        public Gender Gender { get; set; }

        [Required(ErrorMessage = "ImageUrl is required")]
        public IFormFile ImageUrl { get; set; }

        [Required(ErrorMessage = "UserName is required")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }


    }
}
