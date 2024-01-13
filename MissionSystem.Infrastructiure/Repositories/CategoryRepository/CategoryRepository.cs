using Microsoft.EntityFrameworkCore;
using MissionSystem.Domain.Entity;
using MissionSystem.Infrastructure.Database;
using MissionSystem.Infrastructure.Generic;

namespace MissionSystem.Infrastructure.Repositories.CategoryRepository
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext app) : base(app) { }

        public async Task<Category> GetCategoryByIdAsync(Guid categoryId)
        {
            return await _app.Categories.FirstAsync(c => c.Id == categoryId);
        }
    }
}
