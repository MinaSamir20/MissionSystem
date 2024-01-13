using MissionSystem.Application.DTOs.Dtos;
using MissionSystem.Application.Features.Schools.Queries.Models;
using MissionSystem.Domain.Entity;

namespace MissionSystem.Application.Features.Schools.Queries.Response
{
    public class GetSchoolListResponse
    {
        public Guid Id { get; set; }
        public string? SchoolName { get; set; }
        public string? ImageUrl { get; set; }
        public Address? Address { get; set; }
        public CoordinatorDto? Coordinator { get; set; }
        public bool Status { get; set; }

    }
}
