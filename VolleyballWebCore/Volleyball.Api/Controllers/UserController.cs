using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
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
        private readonly UserDbService userDbService = new UserDbService();

        private readonly IConfiguration _config;

        public UserController(IConfiguration config)
        {
            _config = config;
        }

        // Register a new user
        [Route("/api/register")]
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto registerDto)
        {
            if (string.IsNullOrWhiteSpace(registerDto.Password))
                return BadRequest("Password is required.");

            await userDbService.RegisterAsync(registerDto);

            return Ok("Zarejestrowano pomyślnie");
        }

        // Log in
        [Route("/api/login")]
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            await Task.Delay(1000);

            if (!userDbService.Login(loginDto, out Credentials? credentials) || credentials == null)
            {
                return Unauthorized();
            }

            string issuer = _config.GetValue<string>("Jwt:Issuer");
            var key = Encoding.ASCII.GetBytes(_config.GetValue<string>("Jwt:Key"));
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                        new Claim(ClaimTypes.Name, credentials.Email),
                        new Claim(ClaimTypes.NameIdentifier, credentials.Email),
                        new Claim(ClaimTypes.Role, "zz")
                    }),
                Expires = DateTime.UtcNow.AddMinutes(20),
                Issuer = issuer,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            tokenHandler.OutboundClaimTypeMap.Clear();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            var stringToken = tokenHandler.WriteToken(token);


            return Ok(stringToken);

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

            await userDbService.UpdatePasswordAsync(id, updatePasswordDto);

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

            await userDbService.UpdateUserAsync(id, updateUserDto);

            return Ok("User data updated successfully.");
        }
    }
}