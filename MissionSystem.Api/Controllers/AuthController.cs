﻿using Microsoft.AspNetCore.Mvc;
using MissionSystem.Application.DTOs.Authentication;
using MissionSystem.Domain.Entity.Identity;
using MissionSystem.Infrastructure.Services;

namespace MissionSystem.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly AuthService _authService;

        public AuthController(AuthService authService)
        {
            this._authService = authService;
        }

        [HttpPost]
        [Route("seed-roles")]
        public async Task<IActionResult> SeedRoles()
        {
            var seerRoles = await _authService.SeedRolesAsync();

            return Ok(seerRoles);
        }



        // Route -> Register
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromForm] RegisterDto model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _authService.RegisterAsync(model);

            if (!result.IsAuthenticated)
                return BadRequest(result.Message);

            return Ok(result);
        }


        // Route -> Login
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _authService.LoginAsync(model);

            if (!result.IsAuthenticated)
                return BadRequest(result.Message);

            return Ok(result);
        }

        [HttpPost]
        [Route("addrole")]
        public async Task<IActionResult> AddRole([FromBody] AddRoleModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _authService.AddRoleAsync(model);

            if (!string.IsNullOrEmpty(result))
                return BadRequest(result);

            return Ok(model);
        }

        [HttpGet]
        [Route("GetAllUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _authService.GetAllUsersAsync();
            return Ok(result);
        }
        [HttpDelete]
        [Route("DeleteUser/Id")]
        public async Task<IActionResult> DeleteUser([FromRoute] string Id)
        {
            await _authService.DeleteUserAsync(Id);
            return Ok("Deleted Successfully");
        }

        [HttpGet]
        [Route("GetUserById")]
        public async Task<IActionResult> GetUserById([FromQuery] string Id)
        {
            var result = await _authService.GetUserByIdAsync(Id);
            return Ok(result);
        }
        [HttpPut]
        [Route("UpdateUser")]
        public async Task<IActionResult> UpdateUser([FromBody] User model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _authService.UpdateUserAsync(model);
            return Ok(result);
        }


    }
}
