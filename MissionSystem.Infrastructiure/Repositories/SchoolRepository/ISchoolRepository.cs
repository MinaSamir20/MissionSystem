using MissionSystem.Domain.Entity;

namespace MissionSystem.Application.Contracts
{
    public interface ISchoolRepository : IGenericRepository<School>
    {
        Task<ICollection<School>> GetAllSchoolsAsync(Guid? id = null, string[]? includes = null);
        Task<ICollection<School>> GetSchoolsByIdsAsync(ICollection<Guid> schoolIds);
        Task<ICollection<School>> GetAllByCoordinatorIdAsync(Guid id, string[]? includes = null);
    }
}
