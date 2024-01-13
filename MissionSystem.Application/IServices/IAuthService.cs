using MissionSystem.Application.DTOs.Authentication;
using MissionSystem.Domain.Entity;
using MissionSystem.Domain.Entity.Identity;

namespace MissionSystem.Application.IServices
{
    public interface IAuthService
    {

        Task<ResponseDto> SeedRolesAsync();
        Task<AuthResponseModel> RegisterAsync(RegisterDto registerDto);
        Task<AuthResponseModel> LoginAsync(LoginDto loginDto);

        Task<string> AddRoleAsync(AddRoleModel model);

        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User> GetUserByIdAsync(string id);


        Task<User> UpdateUserAsync(User Dto);
        Task DeleteUserAsync(string id);

        Task<Address> GetMyAddress(string userId);
        Task<IEnumerable<School>> GetMySchool(string userId);
        Task<IEnumerable<Mission>> GetMyMission(string userId);

        Task<bool> ChangePassword(string userId, string password);
        //ChangePassword

    }
}
