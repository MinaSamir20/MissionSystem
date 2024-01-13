using MediatR;
using Microsoft.AspNetCore.Http;
using MissionSystem.Application.DTOs.Dtos;
using MissionSystem.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace MissionSystem.Application.Features.Missions.Commands.Models
{
    public class CreateMissionCommand : IRequest<string>
    {
        [Required]
        public string? Title { get; set; }
        public IFormFile? AttachmentUrl { get; set; }
        public DateTime? DateLine { get; set; }
        [Required]
        public string? Suggestion { get; set; }
        [Required]
        public string? Satisfaction { get; set; }
        [Required]
        public Status Status { get; set; }
        [Required]
        public Guid CategoryId { get; set; }
        public ICollection<string>? Question { get; set; }
        public ICollection<string>? Answer { get; set; }
        public ICollection<Guid>? SchoolIds { get; set; }
        public ICollection<Guid>? CoordinatorIds { get; set; }
    }
}
