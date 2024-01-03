using Volleyball.DTO.Matches;
using Volleyball.DTO.Teams;
using VolleyballBlazor.Client.Shared.FormUtils;

namespace VolleyballBlazor.Client.Models
{
    public class NewMatchModel : NewMatchDto
    {
        [ExcludeFromForm]
        public List<VenueDto> VenueList { get; set; } = new List<VenueDto>() { };

        [ExcludeFromForm]
        public List<RoundDto> RoundList { get; set; } = new List<RoundDto>() { };

        [ExcludeFromForm]
        public List<LeagueDto> LeagueList { get; set; } = new List<LeagueDto>() { };

        [ExcludeFromForm]
        public List<PlayerSummaryDto> RefereeList { get; set; } = new List<PlayerSummaryDto>() { };

        [ExcludeFromForm]
        public List<TeamDto> HomeTeamList { get; set; } = new List<TeamDto>() { };

        [ExcludeFromForm]
        public List<TeamDto> GuestTeamList { get; set; } = new List<TeamDto>() { };




    }
}
