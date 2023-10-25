
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Volleyball.DTO;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace VolleyballBlazor.Infrastructure.Client.Services
{
    public interface IUserService
    {
        Task<ApiResponse> Register(RegisterDto registerDto);
        Task<ApiResponse<bool>> Login(LoginDto loginDto);
        Task UpdatePassword(string userId, UpdatePasswordDto updatePasswordDto);
    }

    public class UserService : IUserService
    {
        private HttpClient _httpClient;

        public UserService() {
            _httpClient = new HttpClient
            {
                // development address 
                BaseAddress = new Uri("https://localhost:5134/")
            };
        }

        public UserService(string baseAddress)
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(baseAddress)
            };
        }

        public async Task<ApiResponse> Register(RegisterDto registerDto)
        {
            var response = await _httpClient.PostAsJsonAsync("api/user/register", registerDto);

            return new ApiResponse(response);

        }

        public async Task<ApiResponse<bool>> Login(LoginDto loginDto)
        {
            var response = await _httpClient.PostAsJsonAsync("api/user/login", loginDto);

            ApiResponse<bool> apiResponse = new(response.IsSuccessStatusCode, response);    

            if (!response.IsSuccessStatusCode)
            {
                if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    apiResponse.Message = "Wrong username or password";
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.Forbidden)
                {
                    apiResponse.Message = "Too many failed login attempts. Your account is blocked for 5 minutes";
                }
                else
                {
                    apiResponse.Message = "Server error. Try again later";
                }
            }
            return apiResponse;
        }

        public async Task UpdatePassword(string userId, UpdatePasswordDto updatePasswordDto)
        {
            await _httpClient.PostAsJsonAsync($"api/user/{userId}/updatePassword", updatePasswordDto);
        }

    }
}
