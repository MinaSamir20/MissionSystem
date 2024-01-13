using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using MissionSystem.Domain.Entity;
using MissionSystem.Infrastructure.Database;
using MissionSystem.Infrastructure.Generic;

namespace MissionSystem.Infrastructure.Repositories.GovernmentRepository
{
    public class GavernmentRepository : GenericRepository<Government>, IGovernmentRepository
    {
        public GavernmentRepository(AppDbContext appDbContext) : base(appDbContext) { }
        public async Task<bool> GetByNameAsync(string name)
        {
            var entity = await _app.Governments.FirstOrDefaultAsync(e => e.GovernmentNameEn == name);
            bool result = entity != null;
            return result!;
        }
    }
}
