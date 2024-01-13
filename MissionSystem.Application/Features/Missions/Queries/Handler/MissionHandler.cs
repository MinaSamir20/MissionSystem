using AutoMapper;
using MediatR;
using MissionSystem.Application.Contracts;
using MissionSystem.Application.DTOs.Dtos;
using MissionSystem.Application.Features.Missions.Queries.Models;
using MissionSystem.Application.Features.Missions.Queries.Response;

namespace MissionSystem.Application.Features.Missions.Queries.Handler
{
    public class MissionHandler : IRequestHandler<GetMissionListQuery, IEnumerable<GetMissionListResponse>>, IRequestHandler<GetMissionDetailQuery, GetMissionListResponse> , IRequestHandler<GetContentListByMissionIdQuery, IEnumerable<ContentDto>>
    {
        private readonly IMissionRepository _missionRepository;
        private readonly IMapper _mapper;
        public MissionHandler(IMissionRepository missionRepository, IMapper mapper)
        {
            _missionRepository = missionRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetMissionListResponse>> Handle(GetMissionListQuery request, CancellationToken cancellationToken)
        {
            var mission = await _missionRepository.GetAllMissionAsync(request.CoordinatorId!);
            //foreach (var item in mission)
            //{
            //    item.Coordinators = await _coordinatorRepository.GetById(a => a.Id == item.CategoryId, new[] { "User" });
            //}
            return _mapper.Map<List<GetMissionListResponse>>(mission);
        }
        public async Task<GetMissionListResponse> Handle(GetMissionDetailQuery request, CancellationToken cancellationToken)
        {
            var mission = await _missionRepository.GetById(a => a.Id == request.MissionId);
            return _mapper.Map<GetMissionListResponse>(mission);
        }

        public async Task<IEnumerable<ContentDto>> Handle(GetContentListByMissionIdQuery request, CancellationToken cancellationToken)
        {
            var contents = await _missionRepository.GetContentsByMissionId(request.MissionId);

            return _mapper.Map<IEnumerable<ContentDto>>(contents);
        }
    }
}
