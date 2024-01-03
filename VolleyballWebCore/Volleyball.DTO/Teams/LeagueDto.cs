using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volleyball.Infrastructure.Database.Models;

namespace Volleyball.DTO.Teams
{
    public class LeagueDto : ISelectValue
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        // Method to generate LeagueDto from League
        public static LeagueDto GenerateLeagueDto(League league)
        {
            return new LeagueDto
            {
                Id = league.Id,
                Name = league.Name
            };
        }

        public static explicit operator LeagueDto(League league)
        {
            return GenerateLeagueDto(league);
        }
    }
}
