using MissionSystem.Application.Contracts;
using MissionSystem.Domain.Entity;

namespace MissionSystem.Infrastructure.Repositories.GovernmentRepository
{
    public interface IGovernmentRepository : IGenericRepository<Government>
    {
        Task<bool> GetByNameAsync(string name);
    }
}
