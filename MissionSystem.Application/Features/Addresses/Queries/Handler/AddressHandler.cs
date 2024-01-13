using AutoMapper;
using MediatR;
using MissionSystem.Application.Contracts;
using MissionSystem.Application.Features.Addresses.Queries.Models;
using MissionSystem.Application.Features.Addresses.Queries.Response;
using MissionSystem.Domain.Entity;

namespace MissionSystem.Application.Features.Addresses.Queries.Handler
{
    public class AddressHandler : IRequestHandler<GetAddressListQuery, IEnumerable<GetAddressListResponse>>, IRequestHandler<GetAddressDetailQuery, GetAddressListResponse>
    {
        private readonly IGenericRepository<Address> _genericRepository;
        private readonly IMapper _mapper;

        public AddressHandler(IGenericRepository<Address> genericRepository, IMapper mapper)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetAddressListResponse>> Handle(GetAddressListQuery request, CancellationToken cancellationToken)
        {
            var address = await _genericRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<GetAddressListResponse>>(address);
        }

        public async Task<GetAddressListResponse> Handle(GetAddressDetailQuery request, CancellationToken cancellationToken)
        {
            var address = await _genericRepository.GetById(a => a.Id == request.AddressId);
            return _mapper.Map<GetAddressListResponse>(address);
        }
    }
}
