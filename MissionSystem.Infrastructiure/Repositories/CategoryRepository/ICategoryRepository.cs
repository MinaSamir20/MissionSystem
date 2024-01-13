using MissionSystem.Application.Contracts;
using MissionSystem.Domain.Entity;

namespace MissionSystem.Infrastructure.Repositories.CategoryRepository
{
    public interface ICategoryRepository :IGenericRepository<Category>
    {
        Task<Category> GetCategoryByIdAsync(Guid categoryId);
    }
}
