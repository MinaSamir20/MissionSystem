using AutoMapper;
using MediatR;
using MissionSystem.Application.Contracts;
using MissionSystem.Application.Features.Categories.Queries.Models;
using MissionSystem.Application.Features.Categories.Queries.Response;
using MissionSystem.Domain.Entity;

namespace MissionSystem.Application.Features.Categories.Queries.Handler
{
    public class CategoryHandler : IRequestHandler<GetCategoryListQuery, IEnumerable<GetCategoryListResponse>>, IRequestHandler<GetCategoryDetailQuery, GetCategoryListResponse>
    {
        private readonly IGenericRepository<Category> _categoryRepository;

        private readonly IMapper _mapper;
        public CategoryHandler(IGenericRepository<Category> categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetCategoryListResponse>> Handle(GetCategoryListQuery request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<GetCategoryListResponse>>(category);
        }

        public async Task<GetCategoryListResponse> Handle(GetCategoryDetailQuery request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetByIdAsync(a => a.Id == request.CategoryId);
            return _mapper.Map<GetCategoryListResponse>(category);
        }
    }
}
