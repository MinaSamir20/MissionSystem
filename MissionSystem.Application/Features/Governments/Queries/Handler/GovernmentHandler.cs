using AutoMapper;
using MediatR;
using MissionSystem.Application.Contracts;
using MissionSystem.Application.Features.Governments.Queries.Models;
using MissionSystem.Application.Features.Governments.Queries.Response;
using MissionSystem.Domain.Entity;

namespace MissionSystem.Application.Features.Governments.Queries.Handler
{
    public class GovernmentHandler : IRequestHandler<GetGovernmentListQuery, IEnumerable<GetGovernmentListResponse>>
    {
        private readonly IGenericRepository<Government> _genericRepository;
        private readonly IMapper _mapper;

        public GovernmentHandler(IGenericRepository<Government> genericRepository, IMapper mapper)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetGovernmentListResponse>> Handle(GetGovernmentListQuery request, CancellationToken cancellationToken)
        {
            var govrnment = await _genericRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<GetGovernmentListResponse>>(govrnment);
        }
    }
}
