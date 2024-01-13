using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using MissionSystem.Application.Contracts;
using MissionSystem.Application.Features.Coordinators.Queries.Models;
using MissionSystem.Application.Features.Coordinators.Queries.Response;
using MissionSystem.Domain.Entity;
using MissionSystem.Helpers;

namespace MissionSystem.Application.Features.Coordinators.Queries.Handler
{
    public class CoordinatorHandler : IRequestHandler<GetCoordinatorListQuery, IEnumerable<GetCoordinatorListResponse>>, IRequestHandler<GetCoordinatorDetailQuery, GetCoordinatorListResponse>
    {
        private readonly IGenericRepository<Coordinator> _coordinatorRepository;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CoordinatorHandler(IGenericRepository<Coordinator> coordinatorRepository, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _coordinatorRepository = coordinatorRepository;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        public string GetHostUrl()
        {
            var request = _httpContextAccessor.HttpContext!.Request;
            var hostUrl = $"{request.Scheme}://{request.Host}";
            return hostUrl;
        }

        public async Task<IEnumerable<GetCoordinatorListResponse>> Handle(GetCoordinatorListQuery request, CancellationToken cancellationToken)
        {
            var coordinator = await _coordinatorRepository.GetAllAsync(new[] {"User", "Address", "Missions", "Schools"});
            foreach (var item in coordinator)
            {
                item.User!.ImageUrl = Helper.Image(GetHostUrl().ToString(), "User", item.User.ImageUrl!);
                break;
            }
            return _mapper.Map<IEnumerable<GetCoordinatorListResponse>>(coordinator);
        }

        public async Task<GetCoordinatorListResponse> Handle(GetCoordinatorDetailQuery request, CancellationToken cancellationToken)
        {
            var coordinator = await _coordinatorRepository.GetById(a => a.Id == request.CoordinatorId);
            return _mapper.Map<GetCoordinatorListResponse>(coordinator);
        }
    }
}
