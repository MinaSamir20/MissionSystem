using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using MissionSystem.Application.Contracts;
using MissionSystem.Application.Features.Schools.Queries.Models;
using MissionSystem.Application.Features.Schools.Queries.Response;
using MissionSystem.Domain.Entity;
using MissionSystem.Helpers;

namespace MissionSystem.Application.Features.Schools.Queries.Handler
{
    public class SchoolHandler : IRequestHandler<GetSchoolListQuery, IEnumerable<GetSchoolListResponse>>, IRequestHandler<GetSchoolDetailQuery, GetSchoolListResponse>
    {
        private readonly ISchoolRepository _schoolRepository;
        private readonly IGenericRepository<Coordinator> _cooRepository;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public SchoolHandler(ISchoolRepository schoolRepository, IMapper mapper, IHttpContextAccessor httpContextAccessor, IGenericRepository<Coordinator> cooRepository)
        {
            _schoolRepository = schoolRepository;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _cooRepository = cooRepository;
        }
        public string GetHostUrl()
        {
            var request = _httpContextAccessor.HttpContext!.Request;
            var hostUrl = $"{request.Scheme}://{request.Host}";
            return hostUrl;
        }
        public async Task<IEnumerable<GetSchoolListResponse>> Handle(GetSchoolListQuery request, CancellationToken cancellationToken)
        {
            var school = await _schoolRepository.GetAllSchoolsAsync(request.CoordinatorId!, new[] { "Address" });
            foreach (var item in school)
            {
                item.ImageUrl = Helper.Image(GetHostUrl().ToString(), "School", item.ImageUrl!);
                item.Coordinator = await _cooRepository.GetById(a => a.Id == item.CoordinatorId, new[] { "User" });
            }
            return _mapper.Map<IEnumerable<GetSchoolListResponse>>(school);
        }
        public async Task<GetSchoolListResponse> Handle(GetSchoolDetailQuery request, CancellationToken cancellationToken)
        {
            var school = await _schoolRepository.GetById(a => a.Id == request.SchoolId);
            return _mapper.Map<GetSchoolListResponse>(school);
        }
    }
}
