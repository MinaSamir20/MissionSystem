using Azure.Core;
using Microsoft.EntityFrameworkCore;
using MissionSystem.Application.Contracts;
using MissionSystem.Domain.Entity;
using MissionSystem.Infrastructure.Database;
using MissionSystem.Infrastructure.Generic;
using System.Threading;

namespace MissionSystem.Infrastructure.Repositories.MissionRepository
{
    public class MissionRepository : GenericRepository<Mission>, IMissionRepository
    {
        public MissionRepository(AppDbContext app) : base(app) { }
        public async Task<ICollection<Mission>> GetMissionsByIdsAsync(ICollection<Guid> missionIds)
        {
            return await _app.Missions.Where(m => missionIds.Contains(m.Id)).ToListAsync();
        }
        public async Task<ICollection<Mission>> GetAllMissionAsync(Guid? id = null, string[]? includes = null)
        {
            if(id != null)
                return await _app.Missions.Where(m => m.Coordinators!.Any(c => c.Id == id) && m.IsDeleted == false)
                    .Include(m => m.Coordinators)!.ThenInclude(c => c.User).Include(m => m.Schools)!.Include(m => m.Categories)!.Include(m => m.ContentDetails)!.ToListAsync();
            var mission = await _app.Missions.Where(m => m.IsDeleted == false).Include(m => m.Coordinators)!.ThenInclude(c => c.User).Include(m => m.Schools)!.Include(m => m.Categories)!.Include(m => m.ContentDetails)!.ToListAsync();
            return mission;
        }

        public async Task<ICollection<Mission>> GetAllByCoordinatorIdAsync(Guid id, string[]? includes = null)
        {
            IQueryable<Mission> query = _app.Missions.Where(a => a.IsDeleted == false);
            if (includes != null)
            {
                foreach (var include in includes!)
                {
                    query = query.Include(include);
                }
            }
            return await query.ToListAsync();
        }

        public async Task<ICollection<ContentDetail>> GetContentsByMissionId(Guid id)
        {
            return await _app.ContentDetails.Where(c => c.MissionId == id).ToListAsync();
        }

        private class CategoryDto
        {
            public string? Name { get; set; }
        }
    }
}
