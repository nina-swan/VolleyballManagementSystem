using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Volleyball.DTO;
using Volleyball.Infrastructure.Database.Models;

namespace VolleyballDomain.Shared.Services
{
    public class UserDbService
    {
        private readonly VolleyballContext _context;
        private readonly PasswordHasher<string> passwordHasher = new PasswordHasher<string>();
        public UserDbService() {
            _context = new VolleyballContext();

        }

        // Service to register a new user
        public async Task RegisterAsync(RegisterDto registerDto)
        {
            var user = ConvertToUser(registerDto);
            //user.Position = new Position() { Id = registerDto.PositionId ?? 1 }; // TODO: Fix this
            _context.Users.Add(user);
            var credentials = new Credentials
            {
                Email = registerDto.Email,
                Password = HashPassword(registerDto.Email, registerDto.Password), // Hash the password
                User = user
            };

            _context.Credentials.Add(credentials);
            await _context.SaveChangesAsync();
        }

        // Service to login a user
        public bool Login(LoginDto loginDto, out Credentials? credentials)
        {
            credentials =  _context.Credentials.FirstOrDefault(c => c.Email == loginDto.Login);
            if (credentials == null)
                return false;
            if (!VerifyPassword(loginDto.Login, loginDto.Password, credentials.Password))
                return false;
            return true;
        }



        // Service to hash and update password
        public async Task UpdatePasswordAsync(string userId, UpdatePasswordDto updatePasswordDto)
        {
            var credentials = await _context.Credentials.Include(c => c.User).FirstOrDefaultAsync(c => c.Email == userId);

            if (credentials == null)
                throw new NotFoundException();

            var user = credentials.User;

            string hashedPassword = HashPassword(credentials.Email, updatePasswordDto.NewPassword);
            credentials.Password = hashedPassword;
            await _context.SaveChangesAsync();
        }

        // Service to update user
        public async Task UpdateUserAsync(string userId, UpdateUserDto updateUserDto)
        {
            var credentials = await _context.Credentials.Include(c => c.User).FirstOrDefaultAsync(c => c.Email == userId);

            if (credentials == null)
                throw new NotFoundException();

            var user = credentials.User;

            user.AdditionalEmail = updateUserDto.AdditionalEmail ?? user.AdditionalEmail;
            user.AttackRange = updateUserDto.AttackRange ?? user.AttackRange;
            user.BirthYear = updateUserDto.BirthYear ?? user.BirthYear;
            user.City = updateUserDto.City ?? user.City;
            user.BlockRange = updateUserDto.BlockRange ?? user.BlockRange;
            user.FirstName = updateUserDto.FirstName ?? user.FirstName;
            user.Gender = updateUserDto.Gender ?? user.Gender;
            user.Height = updateUserDto.Height ?? user.Height;
            user.Weight = updateUserDto.Weight ?? user.Weight;
            user.JerseyNumber = updateUserDto.JerseyNumber ?? user.JerseyNumber;
            user.VolleyballIdol = updateUserDto.VolleyballIdol ?? user.VolleyballIdol;
            user.Hobby = updateUserDto.Hobby ?? user.Hobby;
            user.Photo = updateUserDto.Photo ?? user.Photo;
            user.Phone = updateUserDto.Phone ?? user.Phone;
            user.LastName = updateUserDto.LastName ?? user.LastName;
            user.PositionId = updateUserDto.PositionId ?? user.PositionId;
            user.PersonalInfo = updateUserDto.PersonalInfo ?? user.PersonalInfo;

            await _context.SaveChangesAsync();
        }



        // Password hashing

        private bool VerifyPassword(string email, string password, string hashedPassword)
        {
            string hash = PepperPassowrd(password);
            var result = passwordHasher.VerifyHashedPassword(email, hashedPassword, hash);
            return result == PasswordVerificationResult.Success;
        }
        private string HashPassword(string email, string password)
        {
            string hash = PepperPassowrd(password);

            hash = passwordHasher.HashPassword(email, hash);
            return hash;

        }

        private static string GetHashString(string inputString)
        {
            StringBuilder sb = new StringBuilder();
            foreach (byte b in GetHash(inputString))
                sb.Append(b.ToString("X2"));

            return sb.ToString();
        }

        private static byte[] GetHash(string inputString)
        {
            using (HashAlgorithm algorithm = SHA256.Create())
                return algorithm.ComputeHash(Encoding.UTF8.GetBytes(inputString));
        }


        private string PepperPassowrd(string password)
        {
            string pepper = "qaSJKvYBm9$$;=EDOC-)EJ0m";
            return password + pepper;
        }

        // Helper methods
        private User ConvertToUser(RegisterDto registerDto)
        {
            return new User
            {
                FirstName = registerDto.FirstName,
                LastName = registerDto.LastName,
                AccountId = null,
                BirthYear = registerDto.BirthYear,
                City = registerDto.City,
                PersonalInfo = registerDto.PersonalInfo,
                Photo = null,
                Gender = registerDto.Gender,
                Height = (byte?)registerDto.Height,
                Weight = (byte?)registerDto.Weight,
                JerseyNumber = (byte?)registerDto.JerseyNumber,
                BlockRange = registerDto.BlockRange,
                AttackRange = registerDto.AttackRange,
                VolleyballIdol = registerDto.VolleyballIdol,
                AdditionalEmail = registerDto.AdditionalEmail,
                Hobby = registerDto.Hobby,
                Phone = null,
                PositionId = registerDto.PositionId ?? 0, 
                PhotoWidth = null,
                PhotoHeight = null,
                Articles = new List<Article>(),
                Team = null,
                TeamPlayers = new List<TeamPlayer>(), // Initialize as needed
            };
        }

        public class NotFoundException : Exception { }
    }
}
