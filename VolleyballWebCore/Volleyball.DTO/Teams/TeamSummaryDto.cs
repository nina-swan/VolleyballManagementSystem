using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Volleyball.DTO.Teams
{
    public class TeamSummaryDto : ISelectValue
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public int LeagueId { get; set; }

        public static explicit operator TeamSummaryDto(Volleyball.Infrastructure.Database.Models.Team team)
        {
            return new TeamSummaryDto
            {
                Id = team.Id,
                Name = team.Name,
                LeagueId = team.LeagueId
            };
        }

    }
}
