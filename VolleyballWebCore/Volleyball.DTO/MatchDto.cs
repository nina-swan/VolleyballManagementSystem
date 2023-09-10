using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volleyball.Infrastructure.Database.Models;

namespace Volleyball.DTO
{

    public partial class MatchDto
    {
        public int Id { get; set; }

        public DateTime Schedule { get; set; }

        public DateTime CreationDate { get; set; }

        public string? VenueName { get; set; }

        public LeagueDto League { get; set; } = null!;

        public int Sector { get; set; }

        public int Team1Score { get; set; }

        public int Team2Score { get; set; }

        public string? RoundName { get; set; }

        public UserSummaryDto? Referee { get; set; }

        public string? MatchInfo { get; set; }

        public UserSummaryDto MVP { get; set; } = null!;

        public int? Set1Team1Score { get; set; }

        public int? Set2Team1Score { get; set; }

        public int? Set3Team1Score { get; set; }

        public int? Set4Team1Score { get; set; }

        public int? Set5Team1Score { get; set; }

        public int? Set1Team2Score { get; set; }

        public int? Set2Team2Score { get; set; }

        public int? Set3Team2Score { get; set; }

        public int? Set4Team2Score { get; set; }

        public int? Set5Team2Score { get; set; }

        public string? MatchLeague { get; set; }

        public TeamDto HomeTeam { get; set; } = null!;

        public TeamDto GuestTeam { get; set; } = null!;

        public ICollection<TypedResult>? TypedResults { get; set; }
    }
}
