using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using MissionSystem.Application.Contracts;
using MissionSystem.Application.Features.Schools.Commands.Models;
using MissionSystem.Domain.Entity;
using MissionSystem.Helpers;

namespace MissionSystem.Application.Features.Schools.Commands.Handler
{
    public class SchoolCommandHandler : IRequestHandler<CreateSchoolCommand, string>, IRequestHandler<UpdateSchoolCommand, School>, IRequestHandler<DeleteSchoolCommand, string>
    {
        private readonly IWebHostEnvironment _web;
        private readonly IGenericRepository<School> _genericRepository;
        private readonly IGenericRepository<Coordinator> _coordinatorRepository;
        private readonly IGenericRepository<Address> _addressRepository;
        private readonly IMapper _mapper;
        private readonly List<string> _allowedExtentions = new() { ".jpg", ".png", ".jpeg" };

        public SchoolCommandHandler(IGenericRepository<School> genericRepository, IMapper mapper, IWebHostEnvironment web, IGenericRepository<Coordinator> coordinatorRepository, IGenericRepository<Address> addressRepository)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
            _web = web;
            _coordinatorRepository = coordinatorRepository;
            _addressRepository = addressRepository;
        }
        public async Task<string> Handle(CreateSchoolCommand request, CancellationToken cancellationToken)
        {
            if (!_allowedExtentions.Contains(Path.GetExtension(request.ImageUrl!.FileName).ToLower()))
                return "Only accepts files with the following extensions: .jpg, .png, .jpeg";
            if (request.ImageUrl!.Length > 3145728)
                return "Not Allowed Size Maximum 3 MB";

            var school = _mapper.Map<School>(request);

            var coordinator = await _coordinatorRepository.GetByIdAsync(a => a.Id == request.CoordinatorId);
            if (coordinator != null)
                school.Coordinator = coordinator;

            var address = await _addressRepository.GetByIdAsync(a => a.Id == request.AddressId);
            if (address != null)
                school.Address = address;

            school.ImageUrl = Helper.UploadFiles(_web.ContentRootPath, "Resources/Images/School", request.ImageUrl!);
            return await _genericRepository.CreateAsync(school);
        }

        public async Task<string> Handle(DeleteSchoolCommand request, CancellationToken cancellationToken)
        {
            return await _genericRepository.DeleteAsync(request.SchoolId);
        }

        public async Task<School> Handle(UpdateSchoolCommand request, CancellationToken cancellationToken)
        {
            var school = _mapper.Map<School>(request);

            var coordinator = await _coordinatorRepository.GetByIdAsync(a => a.Id == request.CoordinatorId);
            if (coordinator != null)
                school.Coordinator = coordinator;

            var address = await _addressRepository.GetByIdAsync(a => a.Id == request.AddressId);
            if (address != null)
                school.Address = address;

            school.ImageUrl = Helper.UploadFiles(_web.ContentRootPath, "Images/School", request.ImageUrl!);
            return await _genericRepository.UpdateAsync(school);
        }
    }
}
