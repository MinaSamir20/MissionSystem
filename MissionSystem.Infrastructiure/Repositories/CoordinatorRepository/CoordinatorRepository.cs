using Microsoft.EntityFrameworkCore;
using MissionSystem.Application.Contracts;
using MissionSystem.Domain.Entity;
using MissionSystem.Infrastructure.Database;
using MissionSystem.Infrastructure.Generic;
using System.Linq.Expressions;

namespace MissionSystem.Infrastructiure.Repositories.CoordinatorRepository
{
    public class CoordinatorRepository : GenericRepository<Coordinator>, ICoordinatorRepository
    {
        public CoordinatorRepository(AppDbContext app) : base(app) { }

        public async Task<string> AsignMissionToCoordinatorAsync(Guid Id, List<Guid> missionIds)
        {
            await _app.Schools.FindAsync(missionIds);
            return "";
        }

        public async Task<string> AsignSchoolToCoordinatorAsync(Guid Id, List<Guid> schoolIds)
        {
            await _app.Schools.FindAsync(schoolIds);

            //if (schoolsToAdd.Count != schoolIds.Count)
            //{
            //    return false; // One or more schools not found
            //}

            //coordinator.Schools.AddRange(schoolsToAdd);
            //await _coordinatorRepository.SaveAsync();

            //return true;
            return "";
        }

        public async Task<ICollection<Coordinator>> GetCoordinatorByIdsAsync(ICollection<Guid> coordinatorIds)
        {
            return await _app.Coordinators.Where(m => coordinatorIds.Contains(m.Id)).ToListAsync();
        }
    }
}
