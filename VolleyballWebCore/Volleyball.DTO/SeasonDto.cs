using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VolleyballDomain.Shared.Models;

namespace Volleyball.DTO
{
    public class SeasonDto
    {
        public int SeasonId { get; set; }
        public string Name { get; set; }

        public static SeasonDto GenerateSeasonDTO(Season season)
        {
            return new SeasonDto
            {
                SeasonId = season.SeasonId,
                Name = season.Name
            };
        }

        public static Season GenerateSeason(SeasonDto season)
        {
            return new Season
            {
                SeasonId = season.SeasonId,
                Name = season.Name
            };
        }
    }
}
