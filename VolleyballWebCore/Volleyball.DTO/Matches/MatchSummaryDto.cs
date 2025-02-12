﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volleyball.DTO.Teams;

namespace Volleyball.DTO.Matches
{
    public class MatchSummaryDto
    {
        public int Id { get; set; }
        public TeamSummaryDto? HomeTeam { get; set; }
        public TeamSummaryDto? GuestTeam { get; set; }
        public string? LeagueName { get; set; }
        public int? Team1Score { get; set; }
        public int? Team2Score { get; set; }
        public DateTime Schedule { get; set; }
        public string? VenueName { get; set; }
        public string RoundName { get; set; } = null!;
        public PlayerSummaryDto? Referee { get; set; }
        public string? UnknownRefereeName { get; set; }
        public string? MatchInfo { get; set; }

        public static explicit operator MatchSummaryDto(Volleyball.Infrastructure.Database.Models.Match match)
        {
            return new MatchSummaryDto
            {
                Id = match.Id,
                HomeTeam = (TeamSummaryDto?)match.HomeTeam,
                GuestTeam = (TeamSummaryDto?)match.GuestTeam,
                LeagueName = match.League?.Name ?? "Nieokreślona",
                Team1Score = match.Team1Score,
                Team2Score = match.Team2Score,
                Schedule = match.Schedule,
                Referee = (PlayerSummaryDto?)match.Referee,
                UnknownRefereeName = match.UnknownRefereeName,
                MatchInfo = match.MatchInfo,
                VenueName = match.Venue?.Name ?? "Nieokreślona",
                RoundName = match.Round?.Name ?? "Nieokreślona"
            };
        }
    }
}
