using MissionSystem.Domain.Entity;

namespace MissionSystem.Application.Contracts
{
    public interface ICoordinatorRepository : IGenericRepository<Coordinator>
    {
        Task<ICollection<Coordinator>> GetCoordinatorByIdsAsync(ICollection<Guid> coordinatorIds);
        Task<string> AsignSchoolToCoordinatorAsync(Guid Id, List<Guid> SchoolIds);
        Task<string> AsignMissionToCoordinatorAsync(Guid Id, List<Guid> MissionIds);
    }
}
