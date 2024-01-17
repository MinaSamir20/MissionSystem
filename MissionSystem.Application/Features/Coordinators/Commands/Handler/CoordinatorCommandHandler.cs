using AutoMapper;
using MediatR;
using MissionSystem.Application.Contracts;
using MissionSystem.Application.Features.Coordinators.Commands.Models;
using MissionSystem.Domain.Entity;
using MissionSystem.Infrastructure.Database;

namespace MissionSystem.Application.Features.Coordinators.Commands.Handler
{
    public class CoordinatorCommandHandler : IRequestHandler<CreateCoordinatorCommand, string>, IRequestHandler<UpdateCoordinatorCommand, Coordinator>,
        IRequestHandler<DeleteCoordinatorCommand, string>
    {
        private readonly IGenericRepository<Coordinator> _repository;
        private readonly IGenericRepository<Address> _addressRepository;
        private readonly ISchoolRepository _schoolRepository;
        private readonly IMissionRepository _missionRepository;
        private readonly IMapper _mapper;

        public CoordinatorCommandHandler(IGenericRepository<Coordinator> repository, IMapper mapper, IGenericRepository<Address> addressRepository, ISchoolRepository schoolRepository, IMissionRepository missionRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _addressRepository = addressRepository;
            _schoolRepository = schoolRepository;
            _missionRepository = missionRepository;
        }

        public async Task<string> Handle(CreateCoordinatorCommand request, CancellationToken cancellationToken)
        {
            var Coordinator = _mapper.Map<Coordinator>(request);

            var address = await _addressRepository.GetByIdAsync(a => a.Id == request.AddressId);
            if (address != null)
                Coordinator.Address = address;
            var user = await _repository.GetByIdAsync(a => a.UserId == request.UserId);
            
            // Add School To Coordinator
            var school = await _schoolRepository.GetSchoolsByIdsAsync(request.SchoolIds!);
            if (school == null)
                return "Invalid School";
            foreach (var item in request.SchoolIds!)
            {
                var existingSchoolIds = await _schoolRepository.GetByIdAsync(a => a.Id == item);
                if (existingSchoolIds != null)
                    return "This School is Exist";
            }
            Coordinator.Schools = school;

            // Add Missions To Coordinator
            var mission = await _missionRepository.GetMissionsByIdsAsync(request.MissionIds!);
            Coordinator.Missions = mission;
            if (user != null)
                return "User is Exist";
            return await _repository.CreateAsync(Coordinator);
        }

        public async Task<string> Handle(DeleteCoordinatorCommand request, CancellationToken cancellationToken)
        {
            return await _repository.DeleteAsync(request.CoordinatorId);
        }

        public async Task<Coordinator> Handle(UpdateCoordinatorCommand request, CancellationToken cancellationToken)
        {
            var coordinator = _mapper.Map<Coordinator>(request);
            return await _repository.UpdateAsync(coordinator);
        }
    }
}
