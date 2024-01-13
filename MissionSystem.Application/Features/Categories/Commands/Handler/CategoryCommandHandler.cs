using AutoMapper;
using MediatR;
using MissionSystem.Application.Contracts;
using MissionSystem.Application.Features.Categories.Commands.Models;
using MissionSystem.Domain.Entity;

namespace MissionSystem.Application.Features.Categories.Commands.Handler
{
    public class CategoryCommandHandler :IRequestHandler<CreateCategoryCommand, string>, IRequestHandler<UpdateCategoryCommand, Category>, IRequestHandler<DeleteCategoryCommand, string>
    {
        private readonly IGenericRepository<Category> _genericRepository;
        private readonly IMapper _mapper;

        public CategoryCommandHandler(IGenericRepository<Category> genericRepository, IMapper mapper)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
        }

        public async Task<string> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = _mapper.Map<Category>(request);
            return await _genericRepository.CreateAsync(category);
        }

        public async Task<Category> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = _mapper.Map<Category>(request);
            return await _genericRepository.UpdateAsync(category);
        }

        public async Task<string> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            return await _genericRepository.DeleteAsync(request.CategoryId);
        }
    }
}
