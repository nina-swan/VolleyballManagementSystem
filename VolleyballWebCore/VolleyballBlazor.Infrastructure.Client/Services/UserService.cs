
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Volleyball.DTO.Teams;
using Volleyball.DTO.Users;
using VolleyballDomain.Shared;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace VolleyballBlazor.Infrastructure.Client.Services
{
    public interface IUserService
    {
        Task<ApiResponse> Register(RegisterDto registerDto);
        Task<ApiResponse<string>> Login(LoginDto loginDto);
        Task UpdatePassword(string userId, UpdatePasswordDto updatePasswordDto);
        Task<ApiResponse<List<PositionDto>>> GetPositions();
        Task<ApiResponse<PlayerSummaryDto>> GetUserSummary();
        Task<ApiResponse<UserProfileDto>> GetUserProfile(int userId);
        Task<ApiResponse<bool>> IsTeamCaptain();
    }

    public class UserService : IUserService
    {
        private HttpClient _httpClient;

        public UserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            //_httpClient.BaseAddress = new Uri("https://localhost:7213/");
        }   

        public async Task<ApiResponse> Register(RegisterDto registerDto)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("api/user/register", registerDto);
                return new ApiResponse(response);
            }
            catch (HttpRequestException)
            {
                return ApiResponse.NetworkErrorResponse;
            }
        }

        public async Task<ApiResponse<string>> Login(LoginDto loginDto)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("api/user/login", loginDto);
                return new ApiResponse<string>(response);
            }
            catch
            {
                return ApiResponse<string>.NetworkErrorResponse;
            }

        }

        public async Task<ApiResponse<List<PositionDto>>> GetPositions()
        {
            try
            {
                using (var response = await _httpClient.GetAsync("api/position"))
                {
                    return new ApiResponse<List<PositionDto>>(response);
                }
            }
            catch
            {
                return ApiResponse<List<PositionDto>>.NetworkErrorResponse;
            }
        }

        public async Task<ApiResponse<PlayerSummaryDto>> GetUserSummary()
        {
            try
            {
                using (var response = await _httpClient.GetAsync("api/user/usersummary"))
                {
                    return new ApiResponse<PlayerSummaryDto>(response);
                }
            }
            catch
            {
                return ApiResponse<PlayerSummaryDto>.NetworkErrorResponse;
            }
        }

        // get user profile
        public async Task<ApiResponse<UserProfileDto>> GetUserProfile(int userId)
        {
            try
            {
                using (var response = await _httpClient.GetAsync($"api/User/userprofile/{userId}"))
                {
                    return new ApiResponse<UserProfileDto>(response);
                }
            }
            catch
            {
                return ApiResponse<UserProfileDto>.NetworkErrorResponse;
            }
        }


        // check if user has a team
        public async Task<ApiResponse<bool>> IsTeamCaptain()
        {
            try
            {
                using (var response = await _httpClient.GetAsync($"api/User/isteamcaptain"))
                {
                    return new ApiResponse<bool>(response);
                }
            }
            catch
            {
                return ApiResponse<bool>.NetworkErrorResponse;
            }
        }

        // TODO
        public async Task UpdatePassword(string userId, UpdatePasswordDto updatePasswordDto)
        {
            await _httpClient.PostAsJsonAsync($"api/user/{userId}/updatePassword", updatePasswordDto);
        }

    }
}
