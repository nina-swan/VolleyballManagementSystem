using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Volleyball.DTO.Teams;

namespace VolleyballBlazor.Infrastructure.Client.Services
{
    public interface ITeamService
    {
        public Task<ApiResponse<List<TeamDto>>> GetAllTeams();
        public Task<ApiResponse<TeamDto>> GetTeam(int id);
        public Task<ApiResponse> CreateTeam(NewTeamDto team);
        public Task<ApiResponse> UpdateTeam(TeamDto team);
        public Task<ApiResponse> DeleteTeam(int id);
        public Task<ApiResponse> UpdateTeamPlayer(PlayerSummaryDto teamPlayer);
        public Task<ApiResponse<List<TeamDto>>> GetTeamsByLeague(int leagueId);
        public Task<ApiResponse<TeamDto>> GetManagedTeam();
    }

    public class TeamService : ITeamService
    {
        private HttpClient _httpClient;

        public TeamService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ApiResponse<List<TeamDto>>> GetAllTeams()
        {
            var response = await _httpClient.GetAsync("api/team");
            return new ApiResponse<List<TeamDto>>(response);
        }

        public async Task<ApiResponse<TeamDto>> GetTeam(int id)
        {
            var response = await _httpClient.GetAsync($"api/team/{id}");
            return new ApiResponse<TeamDto>(response);
        }

        public async Task<ApiResponse<TeamDto>> GetManagedTeam()
        {
            var response = await _httpClient.GetAsync($"api/team/managedteam");
            return new ApiResponse<TeamDto>(response);
        }

        public async Task<ApiResponse<List<TeamDto>>> GetTeamsByLeague(int leagueId)
        {
            var response = await _httpClient.GetAsync($"api/team/league/{leagueId}");
            return new ApiResponse<List<TeamDto>>(response);
        }

        public async Task<ApiResponse> CreateTeam(NewTeamDto team)
        {
            var response = await _httpClient.PostAsJsonAsync("api/team", team);
            return new ApiResponse(response);
        }

        public async Task<ApiResponse> UpdateTeam(TeamDto team)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/team/{team.Id}", team);
            return new ApiResponse(response);
        }

        public async Task<ApiResponse> DeleteTeam(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/team/{id}");
            return new ApiResponse(response);
        }

        public async Task<ApiResponse> UpdateTeamPlayer(PlayerSummaryDto teamPlayer)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/updateTeamPlayer", teamPlayer);
            return new ApiResponse(response);
        }

        // check if user has a team
        public async Task<ApiResponse<bool>> CheckIfUserHasTeam()
        {
            try
            {
                using (var response = await _httpClient.GetAsync($"api/User/hasTeam"))
                {
                    return new ApiResponse<bool>(response);
                }
            }
            catch
            {
                return ApiResponse<bool>.NetworkErrorResponse;
            }
        }
    }
}
