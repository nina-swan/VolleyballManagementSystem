using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Volleyball.DTO;
using Volleyball.Infrastructure.Database.Models;
using VolleyballDomain.Shared.Services;

namespace YourNamespace.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserDbService UserDbService = new UserDbService();

        public UserController()
        {
        }

        // Register a new user
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto registerDto)
        {
            if (string.IsNullOrWhiteSpace(registerDto.Password))
                return BadRequest("Password is required.");

            await UserDbService.RegisterAsync(registerDto);

            return Ok("Zarejestrowano pomyślnie");
        }

        // Log in
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            if (await UserDbService.LoginAsync(loginDto))
            {
                return Ok("Zalogowano");
            }
            else return Unauthorized("Złe hasło");

        }

        // Update password
        [HttpPut("updatePassword")]
        public async Task<IActionResult> UpdatePassword(UpdatePasswordDto updatePasswordDto)
        {
            string id = User.Identity?.Name;

            if (string.IsNullOrWhiteSpace(id))
            {
                return NotFound();
            }

            await UserDbService.UpdatePasswordAsync(id, updatePasswordDto);

            return Ok("Password updated successfully.");
        }

        // Update user data
        [HttpPut("updateUserData")]
        public async Task<IActionResult> UpdateUserData(UpdateUserDto updateUserDto)
        {
            string id = User.Identity?.Name;
            
            if (string.IsNullOrWhiteSpace(id))
            {
                return NotFound();
            }

            await UserDbService.UpdateUserAsync(id, updateUserDto);

            return Ok("User data updated successfully.");
        }
    }
}