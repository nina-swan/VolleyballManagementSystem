using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volleyball.DTO.Teams;

namespace Volleyball.DTO.Matches
{
    public class MatchPlayersDto
    {
        public List<PlayerSummaryDto> HomeTeamPlayers { get; set; } = new List<PlayerSummaryDto>();
        public List<PlayerSummaryDto> GuestTeamPlayers { get; set; } = new List<PlayerSummaryDto>();

    }
}
