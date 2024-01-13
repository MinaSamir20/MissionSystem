using AutoMapper;
using MediatR;
using MissionSystem.Application.Contracts;
using MissionSystem.Application.Features.Addresses.Commands.Models;
using MissionSystem.Domain.Entity;

namespace MissionSystem.Application.Features.Addresses.Commands.Handler
{
    public class AddressCommandHandler : IRequestHandler<CreateAddressCommand, string>, IRequestHandler<UpdateAddressCommand, Address>, IRequestHandler<DeleteAddressCommand, string>
    {
        private readonly IGenericRepository<Address> _repository;
        private readonly IGenericRepository<Government> _government;
        private readonly IMapper _mapper;

        public AddressCommandHandler(IGenericRepository<Address> repository, IMapper mapper, IGenericRepository<Government> government)
        {
            _repository = repository;
            _mapper = mapper;
            _government = government;
        }

        public async Task<string> Handle(CreateAddressCommand request, CancellationToken cancellationToken)
        {
            var address = _mapper.Map<Address>(request);
            var government = await _government.GetById(a => a.Id == request.GovermentId);
            if (address != null)
                address.Government = government;
            return await _repository.CreateAsync(address!);
        }

        public async Task<Address> Handle(UpdateAddressCommand request, CancellationToken cancellationToken)
        {
            var address = _mapper.Map<Address>(request);
            return await _repository.UpdateAsync(address);
        }

        public async Task<string> Handle(DeleteAddressCommand request, CancellationToken cancellationToken)
        {
            return await _repository.DeleteAsync(request.AddressId);
        }
    }
}
