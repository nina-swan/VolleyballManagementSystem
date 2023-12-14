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
        public Task<ApiResponse> UpdateTeam(ManageTeamDto team);
        public Task<ApiResponse> DeleteTeam(int id);
        public Task<ApiResponse<List<TeamDto>>> GetTeamsByLeague(int leagueId);
        public Task<ApiResponse<ManagedTeamDataDto>> GetManagedTeam();
        public Task<ApiResponse<List<LeagueDto>>> GetLeagues();
        public Task<ApiResponse<List<SeasonDto>>> GetSeasons();
        public Task<ApiResponse> UpdateCaptain(int playerId);

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
            var response = await _httpClient.GetAsync($"api/team/id/{id}");
            return new ApiResponse<TeamDto>(response);
        }

        public async Task<ApiResponse<ManagedTeamDataDto>> GetManagedTeam()
        {
            var response = await _httpClient.GetAsync($"api/team/managedteam");
            return new ApiResponse<ManagedTeamDataDto>(response);
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

        public async Task<ApiResponse> UpdateTeam(ManageTeamDto team)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/team", team);
            return new ApiResponse(response);
        }

        public async Task<ApiResponse> DeleteTeam(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/team/id/{id}");
            return new ApiResponse(response);
        }

        public async Task<ApiResponse> UpdateCaptain(int playerId)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/team/updateCaptain", playerId);
            return new ApiResponse(response);
        }




        // get leagues
        public async Task<ApiResponse<List<LeagueDto>>> GetLeagues()
        {
            try
            {
                using (var response = await _httpClient.GetAsync($"api/team/leagues"))
                {
                    return new ApiResponse<List<LeagueDto>>(response);
                }
            }
            catch
            {
                return ApiResponse<List<LeagueDto>>.NetworkErrorResponse;
            }
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

        // get seasons
        public async Task<ApiResponse<List<SeasonDto>>> GetSeasons()
        {
            try
            {
                using (var response = await _httpClient.GetAsync($"api/team/seasons"))
                {
                    return new ApiResponse<List<SeasonDto>>(response);
                }
            }
            catch
            {
                return ApiResponse<List<SeasonDto>>.NetworkErrorResponse;
            }
        }
    }
}
