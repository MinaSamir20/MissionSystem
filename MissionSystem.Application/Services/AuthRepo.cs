using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MissionSystem.Domain.Entity;
using MissionSystem.Domain.Entity.Identity;
using MissionSystem.Application.DTOs.Authentication;
using MissionSystem.Infrastructure.Database;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using MissionSystem.Helpers;
using Microsoft.AspNetCore.Hosting;

namespace MissionSystem.Infrastructure.Services
{
    public class AuthRepo
    {
        private readonly AppDbContext _db;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _web;

        public AuthRepo(AppDbContext db, UserManager<User> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration, IWebHostEnvironment web)
        {
            _db = db;
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
            _web = web;
        }
        public async Task<ResponseDto> SeedRolesAsync()
        {
            bool isCoordinatorRoleExists = await _roleManager.RoleExistsAsync("COORDINATOR");
            bool isSupperAdminRoleExists = await _roleManager.RoleExistsAsync("SUPERADMIN");

            if (isCoordinatorRoleExists && isSupperAdminRoleExists)
                return new ResponseDto()
                {
                    IsSuccess = true,
                    DisplayMessage = "Roles Seeding is Already Done"
                };

            await _roleManager.CreateAsync(new IdentityRole("COORDINATOR"));
            await _roleManager.CreateAsync(new IdentityRole("SUPERADMIN"));

            return new ResponseDto()
            {
                IsSuccess = true,
                DisplayMessage = "Role Seeding Done Successfully"
            };
        }

        public async Task<string> AddRoleAsync(AddRoleModel model)
        {
            var user = await _userManager.FindByIdAsync(model.UserId!);
            if (user == null || !await _roleManager.RoleExistsAsync(model.Role!))
                return "Invalid User ID or Role";

            if (await _userManager.IsInRoleAsync(user, model.Role!))
                return "User already assigned to this Role";

            var result = await _userManager.AddToRoleAsync(user, model.Role!);

            return result.Succeeded?  string.Empty : "Something went wrong";
        }


        public async Task<AuthResponseModel> LoginAsync(LoginDto model)
        {
            var authModel = new AuthResponseModel();

            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user is null || !await _userManager.CheckPasswordAsync(user, model.Password))
            {
                authModel.Message = "Email or Password is incorrect!";
                return authModel;
            }

            var jwtSecurityToken = await CreateJwtToken(user);
            var rolesList = await _userManager.GetRolesAsync(user);

            authModel.IsAuthenticated = true;
            authModel.Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            authModel.Email = user.Email;
            authModel.Username = user.UserName;
            authModel.ExpiresOn = jwtSecurityToken.ValidTo;
            authModel.Roles = rolesList.ToList();

            return authModel;

        }
        public async Task<AuthResponseModel> RegisterAsync(RegisterDto model)
        {
            if (await _userManager.FindByEmailAsync(model.Email) is not null)
                return new AuthResponseModel { Message = "Email is already registered!" };

            if (await _userManager.FindByNameAsync(model.UserName) is not null)
                return new AuthResponseModel { Message = "Username is already registered!" };

            var user = new User
            {
                NameEn = model.NameEn,
                NameAr = model.NameAr,
                PhoneNumber = model.PhoneNumber,
                Gender = model.Gender,
                ImageUrl = Helper.UploadFiles(_web.ContentRootPath, "Images/User", model.ImageUrl),
                UserName = model.UserName,
                Email = model.Email,
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
            {
                var errors = new StringBuilder();
                foreach (var error in result.Errors)
                    errors.Append($"{error.Description},");

                return new AuthResponseModel { Message = errors.ToString() };
            }

            await _userManager.AddToRoleAsync(user, "COORDINATOR");

            var jwtSecurityToken = await CreateJwtToken(user);

            return new AuthResponseModel
            {
                Email = user.Email,
                ExpiresOn = jwtSecurityToken.ValidTo,
                IsAuthenticated = true,
                Roles = new List<string> { "COORDINATOR" },
                Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
                Username = user.UserName
            };
        }

        private async Task<JwtSecurityToken> CreateJwtToken(User user)
        {
            var userClaims = await _userManager.GetClaimsAsync(user);
            var userRoles = await _userManager.GetRolesAsync(user);

            var roleClaims = userRoles.Select(r => new Claim("roles", r)).ToList();

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName!),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email!),
                new Claim("uid", user.Id)
            }
            .Union(userClaims)
            .Union(roleClaims);

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Key"]!));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                claims: claims,
                expires: DateTime.Now.AddDays(int.Parse(_configuration["JWT:DurationInDays"]!)),
                signingCredentials: signingCredentials);

            return jwtSecurityToken;
        }

        public async Task DeleteUserAsync(string id)
        {
            var result = await _db.Users.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (result != null) { _db.Users.Remove(result); }
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync() => await _db.Users.ToListAsync();

        public async Task<User> GetUserByIdAsync(string id)
        {
            var user = await _db.Users.Where(x => x.Id == id).FirstOrDefaultAsync();
            return user!;
        }

        public async Task<User> UpdateUserAsync(User Dto)
        {
            _db.Entry(Dto).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return Dto;
        }

        public Task<Address> GetMyAddress(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<School>> GetMySchool(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Mission>> GetMyMission(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ChangePassword(string userId, string password)
        {
            throw new NotImplementedException();
        }
    }
}
