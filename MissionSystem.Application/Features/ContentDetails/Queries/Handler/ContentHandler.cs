using AutoMapper;
using MediatR;
using MissionSystem.Application.Contracts;
using MissionSystem.Application.Features.ContentDetails.Queries.Models;
using MissionSystem.Application.Features.ContentDetails.Queries.Response;
using MissionSystem.Domain.Entity;

namespace MissionSystem.Application.Features.ContentDetails.Queries.Handler
{
    public class ContentHandler : IRequestHandler<GetContentListQuery, IEnumerable<GetContentListResponse>>, IRequestHandler<GetContentDetailQuery, GetContentListResponse>
    {
        private readonly IGenericRepository<ContentDetail> _genericRepository;

        private readonly IMapper _mapper;
        public ContentHandler(IGenericRepository<ContentDetail> genericRepository, IMapper mapper)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
        }


        public async Task<IEnumerable<GetContentListResponse>> Handle(GetContentListQuery request, CancellationToken cancellationToken)
        {
            var category = await _genericRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<GetContentListResponse>>(category);
        }

        public async Task<GetContentListResponse> Handle(GetContentDetailQuery request, CancellationToken cancellationToken)
        {
            var category = await _genericRepository.GetById(a => a.Id == request.ContentId);
            return _mapper.Map<GetContentListResponse>(category);
        }
    }
}
