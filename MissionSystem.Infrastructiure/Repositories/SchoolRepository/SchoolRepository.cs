using Microsoft.EntityFrameworkCore;
using MissionSystem.Application.Contracts;
using MissionSystem.Domain.Entity;
using MissionSystem.Infrastructure.Database;
using MissionSystem.Infrastructure.Generic;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace MissionSystem.Infrastructiure.Repositories.SchoolRepository
{
    public class SchoolRepository : GenericRepository<School>, ISchoolRepository
    {
        public SchoolRepository(AppDbContext app) : base(app) { }
        public async Task<ICollection<School>> GetSchoolsByIdsAsync(ICollection<Guid> schoolIds)
        {
            return await _app.Schools.Where(m => schoolIds.Contains(m.Id)).ToListAsync();
        }

        public async Task<ICollection<School>> GetAllByCoordinatorIdAsync(Guid id, string[]? includes = null)
        {
            IQueryable<School> query = _app.Schools.Where(a => a.IsDeleted == false);
            if (includes != null)
            {
                foreach (var include in includes!)
                {
                    query = query.Include(include);
                }
            }
            return await query.ToListAsync();
        }

        public async Task<ICollection<School>> GetAllSchoolsAsync(Guid? id = null, string[]? includes = null)
        {
            var query = _app.Schools.Where(a => a.IsDeleted == false);
            if (id != null)
                query = _app.Schools.Where(m => m.CoordinatorId == id && m.IsDeleted == false);
            if (includes != null)
            {
                foreach (var include in includes!)
                {
                    query = query.Include(include);
                }
            }
            return await query.ToListAsync();
        }
    }
}
