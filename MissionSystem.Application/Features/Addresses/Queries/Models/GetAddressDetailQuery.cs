using MediatR;
using MissionSystem.Application.Features.Addresses.Queries.Response;

namespace MissionSystem.Application.Features.Addresses.Queries.Models
{
    public class GetAddressDetailQuery : IRequest<GetAddressListResponse>
    {
        public Guid AddressId { get; set; }
    }
}
