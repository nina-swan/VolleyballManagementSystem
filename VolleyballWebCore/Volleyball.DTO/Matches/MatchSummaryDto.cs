using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volleyball.DTO.Teams;

namespace Volleyball.DTO.Matches
{
    public class MatchSummaryDto
    {
        public string? HomeTeamName { get; set; }
        public string? GuestTeamName { get; set; }
        public string? LeagueName { get; set; }
        public int? Team1Score { get; set; }
        public int? Team2Score { get; set; }
        public DateTime Schedule { get; set; }
        public PlayerSummaryDto? Referee { get; set; }
        public string? UnknownRefereeName { get; set; }

        public static explicit operator MatchSummaryDto(Volleyball.Infrastructure.Database.Models.Match match)
        {
            return new MatchSummaryDto
            {
                HomeTeamName = match.HomeTeam.Name,
                GuestTeamName = match.GuestTeam.Name,
                LeagueName = match.League.Name,
                Team1Score = match.Team1Score,
                Team2Score = match.Team2Score,
                Schedule = match.Schedule,
                Referee = (PlayerSummaryDto?)match.Referee,
                UnknownRefereeName = match.UnknownRefereeName
            };
        }
    }
}
