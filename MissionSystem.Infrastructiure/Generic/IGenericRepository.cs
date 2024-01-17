using System.Linq.Expressions;

namespace MissionSystem.Application.Contracts
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync(string[]? includes = null);
        Task<T> GetByIdAsync(Expression<Func<T, bool>> criteria, string[]? includes = null);
        Task<T> GetByIdAsync(Guid id, string[]? includes = null);
        Task<ICollection<T>> GetByIdAsync(ICollection<Guid> Ids);
        Task<T> UpdateAsync(T entity);
        Task<string> CreateAsync(T entity);
        Task<string> CreateRangeAsync(ICollection<T> entity);
        Task<string> DeleteAsync(Guid id);
    }
}
