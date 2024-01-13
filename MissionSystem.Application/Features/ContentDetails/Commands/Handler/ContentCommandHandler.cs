using AutoMapper;
using MediatR;
using MissionSystem.Application.Contracts;
using MissionSystem.Application.Features.ContentDetails.Commands.Models;
using MissionSystem.Domain.Entity;

namespace MissionSystem.Application.Features.ContentDetails.Commands.Handler
{
    public class ContentCommandHandler : IRequestHandler<CreateContentCommand, string>, IRequestHandler<UpdateContentCommand, ContentDetail>, IRequestHandler<DeleteContentCommand, string>
    {
        private readonly IGenericRepository<ContentDetail> _genericRepository;
        private readonly IMissionRepository _missionRepository;
        private readonly IMapper _mapper;
        public ContentCommandHandler(IGenericRepository<ContentDetail> genericRepository, IMapper mapper, IMissionRepository missionRepository)
        {
            _genericRepository = genericRepository;
            _missionRepository = missionRepository;
            _mapper = mapper;
        }
        public async Task<string> Handle(DeleteContentCommand request, CancellationToken cancellationToken)
        {
            return await _genericRepository.DeleteAsync(request.ContentId);
        }

        public async Task<string> Handle(CreateContentCommand request, CancellationToken cancellationToken)
        {
            var content = _mapper.Map<ContentDetail>(request);
            if (request.MissionId != null)
            {
                content.Mission = await _missionRepository.GetById(a => a.Id == request.MissionId);
            }
            return await _genericRepository.CreateAsync(content);
        }

        public async Task<ContentDetail> Handle(UpdateContentCommand request, CancellationToken cancellationToken)
        {
            var content = _mapper.Map<ContentDetail>(request);
            return await _genericRepository.UpdateAsync(content);
        }
    }
}
