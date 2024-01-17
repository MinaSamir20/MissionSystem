using System.Linq.Expressions;
using MissionSystem.Domain.Entity.Identity;

namespace MissionSystem.Infrastructure.Repositories.AuthenticationRepository
{
    public class AuthRepository : IAuthRepository
    {
        public Task<string> CreateAsync(User entity)
        {
            throw new NotImplementedException();
        }

        public Task<string> CreateRangeAsync(ICollection<User> entity)
        {
            throw new NotImplementedException();
        }

        public Task<string> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> GetAllAsync(string[]? includes = null)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetByIdAsync(Expression<Func<User, bool>> criteria, string[]? includes = null)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetByIdAsync(Guid id, string[]? includes = null)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<User>> GetByIdAsync(ICollection<Guid> Ids)
        {
            throw new NotImplementedException();
        }

        public Task<AuthServiceResponseDto> MakeAdminAsync(UpdatePermissionDto updatePermissionDto)
        {
            throw new NotImplementedException();
        }

        public Task<AuthServiceResponseDto> MakeSuperAdminAsync(UpdatePermissionDto updatePermissionDto)
        {
            throw new NotImplementedException();
        }

        public Task<AuthServiceResponseDto> MakeUserAsync(UpdatePermissionDto updatePermissionDto)
        {
            throw new NotImplementedException();
        }

        public Task<User> UpdateAsync(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
