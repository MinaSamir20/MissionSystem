using MissionSystem.Domain.Entity;

namespace MissionSystem.Application.Contracts
{
    public interface IMissionRepository : IGenericRepository<Mission>
    {
        Task<ICollection<Mission>> GetMissionsByIdsAsync(ICollection<Guid> missionIds);
        Task<ICollection<Mission>> GetAllMissionAsync(Guid? id = null, string[]? includes = null);
        Task<ICollection<Mission>> GetAllByCoordinatorIdAsync(Guid id, string[]? includes = null);
        Task<ICollection<ContentDetail>> GetContentsByMissionId(Guid id);
    }
}
