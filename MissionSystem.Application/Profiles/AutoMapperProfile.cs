using AutoMapper;
using MissionSystem.Application.DTOs.Dtos;
using MissionSystem.Application.Features.Addresses.Commands.Models;
using MissionSystem.Application.Features.Addresses.Queries.Response;
using MissionSystem.Application.Features.Categories.Commands.Models;
using MissionSystem.Application.Features.Categories.Queries.Response;
using MissionSystem.Application.Features.ContentDetails.Commands.Models;
using MissionSystem.Application.Features.ContentDetails.Queries.Response;
using MissionSystem.Application.Features.Coordinators.Commands.Models;
using MissionSystem.Application.Features.Coordinators.Queries.Response;
using MissionSystem.Application.Features.Governments.Queries.Response;
using MissionSystem.Application.Features.Missions.Commands.Models;
using MissionSystem.Application.Features.Missions.Queries.Response;
using MissionSystem.Application.Features.Schools.Commands.Models;
using MissionSystem.Application.Features.Schools.Queries.Response;
using MissionSystem.Domain.Entity;
using MissionSystem.Domain.Entity.Identity;

namespace MissionSystem.Application.Profiles
{
    internal class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // Address
            CreateMap<Address, AddressDto>().ReverseMap();
            CreateMap<Address, GetAddressListResponse>().ReverseMap();
            CreateMap<Address, CreateAddressCommand>().ReverseMap();
            CreateMap<Address, UpdateAddressCommand>().ReverseMap();
            CreateMap<Address, DeleteAddressCommand>().ReverseMap();

            // Category
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Category, GetCategoryListResponse>().ReverseMap();
            CreateMap<Category, CreateCategoryCommand>().ReverseMap();
            CreateMap<Category, UpdateCategoryCommand>().ReverseMap();
            CreateMap<Category, DeleteCategoryCommand>().ReverseMap();

            // Coordinator
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<Coordinator, CoordinatorDto>().ReverseMap();
            CreateMap<Coordinator, GetCoordinatorListResponse>().ReverseMap();
            CreateMap<Coordinator, CreateCoordinatorCommand>().ReverseMap();
            CreateMap<Coordinator, UpdateCoordinatorCommand>().ReverseMap();
            CreateMap<Coordinator, DeleteCoordinatorCommand>().ReverseMap();

            // ContentDetail
            CreateMap<ContentDetail, GetContentListResponse>().ReverseMap();
            CreateMap<ContentDto, CreateMissionCommand>().ReverseMap();
            CreateMap<ContentDetail, ContentDto>().ReverseMap();
            CreateMap<ContentDetail, CreateContentCommand>().ReverseMap();
            CreateMap<ContentDetail, UpdateContentCommand>().ReverseMap();
            CreateMap<ContentDetail, DeleteContentCommand>().ReverseMap();

            // Government
            CreateMap<Government, GetGovernmentListResponse>().ReverseMap();

            // Mission
            CreateMap<Mission, MissionDto>().ReverseMap();
            CreateMap<Mission, GetMissionListResponse>().ReverseMap();
            CreateMap<Mission, AddImageMission>().ReverseMap();
            CreateMap<Mission, CreateMissionCommand>().ReverseMap();
            CreateMap<Mission, UpdateMissionCommand>().ReverseMap();
            CreateMap<Mission, DeleteMissionCommand>().ReverseMap();

            // School
            CreateMap<School, SchoolDto>().ReverseMap();
            CreateMap<School, GetSchoolListResponse>().ReverseMap();
            CreateMap<School, CreateSchoolCommand>().ReverseMap();
            CreateMap<School, UpdateSchoolCommand>().ReverseMap();
            CreateMap<School, DeleteSchoolCommand>().ReverseMap();

        }
    }
}
