using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volleyball.DTO.Teams;
using Volleyball.Infrastructure.Database.Models;

namespace Volleyball.DTO.Matches
{

    public partial class ManageMatchDto
    {
        public int Id { get; set; }

        public DateTime Schedule { get; set; }

        public int VenueId { get; set; }

        public int Sector { get; set; }

        public int Team1Score { get; set; }

        public int Team2Score { get; set; }

        public int RefereeId { get; set; }

        public string? UnknownRefereeName { get; set; }

        public string? MatchInfo { get; set; }

        public int MvpId { get; set; }

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
    }
}
