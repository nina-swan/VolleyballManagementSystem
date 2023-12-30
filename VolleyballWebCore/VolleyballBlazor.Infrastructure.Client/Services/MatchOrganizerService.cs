using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Volleyball.DTO.Matches;
using Volleyball.DTO.Teams;

namespace VolleyballBlazor.Infrastructure.Client.Services
{
    public interface IMatchOrganizerService
    {
        public Task<ApiResponse<List<VenueDto>>> GetVenues();
        public Task<ApiResponse<List<RoundDto>>> GetRounds();
        public Task<ApiResponse<List<LeagueDto>>> GetLeagues();
        public Task<ApiResponse<List<PlayerSummaryDto>>> GetReferees();
        public Task<ApiResponse<List<PlayerSummaryDto>>> GetPlayers(int matchId);
        public Task<ApiResponse<MatchDto>> GetMatch(int matchId);
        public Task<ApiResponse> CreateMatch(NewMatchDto match);
        public Task<ApiResponse> UpdateMatch(ManageMatchDto match);

    }

    public class MatchOrganizerService : IMatchOrganizerService
    {
        private readonly HttpClient httpClient;

        public MatchOrganizerService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<ApiResponse<VenueDto>> GetVenues()
        {
            var response = await httpClient.GetAsync("api/venue");
            return new ApiResponse<VenueDto>(response);
        }

        public async Task<ApiResponse<RoundDto>> GetRounds()
        {
            var response = await httpClient.GetAsync("api/round");
            return new ApiResponse<RoundDto>(response);
        }

        public async Task<ApiResponse<LeagueDto>> GetLeagues()
        {
            var response = await httpClient.GetAsync("api/league");
            return new ApiResponse<LeagueDto>(response);
        }

        public async Task<ApiResponse<PlayerSummaryDto>> GetReferees()
        {
            var response = await httpClient.GetAsync("api/match/referees");
            return new ApiResponse<PlayerSummaryDto>(response);
        }

        public async Task<ApiResponse<PlayerSummaryDto>> GetPlayers(int matchId)
        {
            throw new NotImplementedException();
        }

        public async Task<ApiResponse<MatchDto>> GetMatch(int matchId)
        {
            var response = await httpClient.GetAsync($"api/match/{matchId}");
            return new ApiResponse<MatchDto>(response);
        }

        public async Task<ApiResponse> CreateMatch(NewMatchDto match)
        {
            var response = await httpClient.PostAsJsonAsync("api/match", match);
            return new ApiResponse(response);
        }

        public async Task<ApiResponse> UpdateMatch(ManageMatchDto match)
        {
            var response = await httpClient.PutAsJsonAsync("api/match", match);
            return new ApiResponse(response);
        }

    }
}
