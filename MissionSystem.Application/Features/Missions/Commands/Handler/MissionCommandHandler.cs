using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using MissionSystem.Application.Contracts;
using MissionSystem.Application.Features.Missions.Commands.Models;
using MissionSystem.Domain.Entity;
using MissionSystem.Helpers;
using MissionSystem.Infrastructure.Repositories.CategoryRepository;

namespace MissionSystem.Application.Features.Missions.Commands.Handler
{
    public class MissionCommandHandler : IRequestHandler<CreateMissionCommand, string>, IRequestHandler<UpdateMissionCommand, Mission>, IRequestHandler<DeleteMissionCommand, string>
    {
        private readonly IWebHostEnvironment _web;
        private readonly IMissionRepository _missionRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly ICoordinatorRepository _coordinatorRepository;
        private readonly ISchoolRepository _schoolRepository;
        private readonly IMapper _mapper;
        public MissionCommandHandler(IMissionRepository missionRepository, ICategoryRepository categoryRepository, ICoordinatorRepository coordinatorRepository, ISchoolRepository schoolRepository, IMapper mapper, IWebHostEnvironment web)
        {
            _missionRepository = missionRepository;
            _categoryRepository = categoryRepository;
            _coordinatorRepository = coordinatorRepository;
            _schoolRepository = schoolRepository;
            _mapper = mapper;
            _web = web;
        }
        public async Task<string> Handle(CreateMissionCommand request, CancellationToken cancellationToken)
        {

            var mission = _mapper.Map<Mission>(request);

            // Add AttachmentFile To Mission
            if (request.AttachmentUrl != null)
            {
                if (request.AttachmentUrl!.Length > 3145728)
                    return "Not Allowed Size Maximum 3 MB";
                mission.AttachmentUrl = Helper.UploadFiles(_web.ContentRootPath, "Files/ContentMission", request.AttachmentUrl!);
            }

            // Add Category To Mission
            var category = await _categoryRepository.GetCategoryByIdAsync(request.CategoryId!);
            if (category == null)
                return "Invalid Category";
            mission.Categories = category;

            // Create and add ContentDetail entities to the mission
            if ((request.Question != null && request.Question!.Any()) && (request.Answer != null && request.Answer!.Any()))
            {
                mission.ContentDetails = new List<ContentDetail>();

                //foreach (var question in request.Question)
                //{
                //    mission.ContentDetails.Add(new ContentDetail { Question = question, Answer = request.Answer });
                //}

                for (int i = 0; i < Math.Min(request.Question.Count, request.Answer!.Count); i++)
                {
                    mission.ContentDetails.Add(new ContentDetail { Question = request.Question.ElementAt(i), Answer = request.Answer.ElementAt(i) });
                }
            }



            // Add Coordinator To Mission
            if (request.CoordinatorIds != null)
            {
                var coordinator = await _coordinatorRepository.GetCoordinatorByIdsAsync(request.CoordinatorIds!);
                if (coordinator == null)
                    return "Invalid Coordinator";
                mission.Coordinators = coordinator;
                
            }

            // Add School To Mission
            if (request.SchoolIds != null)
            {
                var school = await _schoolRepository.GetSchoolsByIdsAsync(request.SchoolIds!);
                if (school == null)
                    return "Invalid School";
                mission.Schools = school;
            }

            return await _missionRepository.CreateAsync(mission);
        }

        public async Task<string> Handle(DeleteMissionCommand request, CancellationToken cancellationToken)
        {
            return await _missionRepository.DeleteAsync(request.MissionId);
        }

        public async Task<Mission> Handle(UpdateMissionCommand request, CancellationToken cancellationToken)
        {
            var mission = _mapper.Map<Mission>(request);
            return await _missionRepository.UpdateAsync(mission);
        }
    }
}
