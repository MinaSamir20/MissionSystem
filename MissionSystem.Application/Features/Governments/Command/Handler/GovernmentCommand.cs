using AutoMapper;
using MediatR;
using MissionSystem.Application.Contracts;
using MissionSystem.Application.Features.Governments.Command.Models;
using MissionSystem.Domain.Entity;

namespace MissionSystem.Application.Features.Governments.Command.Handler
{
    public class GovernmentCommand : IRequestHandler<CreateGovernmentCommand, string>
    {
        private readonly IGenericRepository<Government> _repository;
        private readonly IMapper _mapper;

        public GovernmentCommand(IGenericRepository<Government> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<string> Handle(CreateGovernmentCommand request, CancellationToken cancellationToken)
        {
            var government = _mapper.Map<Government>(request);
            return await _repository.CreateAsync(government);
        }
    }
}
