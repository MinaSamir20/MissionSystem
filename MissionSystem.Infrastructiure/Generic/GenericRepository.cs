using Microsoft.EntityFrameworkCore;
using MissionSystem.Domain.Entity;
using MissionSystem.Infrastructure.Database;
using MissionSystem.Application.Contracts;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MissionSystem.Infrastructure.Generic
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        protected readonly AppDbContext _app;
        public GenericRepository(AppDbContext app)
        {
            _app = app;
        }
        public async Task<string> CreateAsync(T entity)
        {
            entity.Status = true;
            await _app.Set<T>().AddAsync(entity);
            await _app.SaveChangesAsync();
            return entity.Id.ToString();
        }

        public async Task<string> CreateRangeAsync(ICollection<T> entity)
        {
            await _app.Set<T>().AddRangeAsync(entity);
            await _app.SaveChangesAsync();
            return "Created successfully";
        }

        public async Task<string> DeleteAsync(Guid id)
        {
            var entity = await _app.Set<T>().FindAsync(id);

            if (entity != null)
            {
                entity.IsDeleted = true;
                entity.DeletedOn = DateTime.Now;
                await _app.SaveChangesAsync();
                return "Deleted successfully";
            }
            return "fails";
        }

        public async Task<IEnumerable<T>> GetAllAsync(string[]? includes = null)
        {
            IQueryable<T> query = _app.Set<T>().Where(a => a.IsDeleted == false);
            if (includes != null)
            {
                foreach (var include in includes!)
                {
                    query = query.Include(include);
                }
            }
            return await query.ToListAsync();
        }

        public async Task<T> GetByIdAsync(Expression<Func<T, bool>> criteria, string[]? includes = null)
        {
            IQueryable<T> query = _app.Set<T>().Where(a => a.IsDeleted == false);
            if (includes != null)
            {
                foreach (var include in includes!)
                {
                    query = query.Include(include);
                }
            }
            var entity = await query.FirstOrDefaultAsync(criteria);
            return entity!;
            
        }

        public async Task<T> GetByIdAsync(Guid id, string[]? includes = null)
        {
            IQueryable<T> query = _app.Set<T>().Where(a => a.IsDeleted == false);
            if (includes != null)
            {
                foreach (var include in includes!)
                {
                    query = query.Include(include);
                }
            }
            var entity = await query.FirstOrDefaultAsync(a => a.Id == id);
            return entity!;
        }

        public async Task<ICollection<T>> GetByIdAsync(ICollection<Guid> Ids)
        {
            return await _app.Set<T>().Where(m => Ids.Contains(m.Id)).ToListAsync();
        }

        public async Task<T> UpdateAsync(T entity)
        {
            _app.Entry(entity).State = EntityState.Modified;
            await _app.SaveChangesAsync();
            return entity;
        }
    }
}
