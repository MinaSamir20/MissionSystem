using MissionSystem.Application.Contracts;
using MissionSystem.Domain.Entity.Identity;

namespace MissionSystem.Infrastructure.Repositories.AuthenticationRepository
{
    public interface IAuthRepository : IGenericRepository<User>
    {
        Task<AuthServiceResponseDto> MakeAdminAsync(UpdatePermissionDto updatePermissionDto);
        Task<AuthServiceResponseDto> MakeUserAsync
          (UpdatePermissionDto updatePermissionDto);
        Task<AuthServiceResponseDto> MakeSuperAdminAsync(UpdatePermissionDto updatePermissionDto);
    }
}
