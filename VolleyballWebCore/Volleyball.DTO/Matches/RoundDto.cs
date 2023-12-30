using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Volleyball.DTO.Matches
{
    public class RoundDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int SeasonId { get; set; }

        public static explicit operator RoundDto(Volleyball.Infrastructure.Database.Models.Round round)
        {
            return new RoundDto
            {
                Id = round.Id,
                Name = round.Name,
                SeasonId = round.SeasonId
            };
        }

        public static explicit operator Volleyball.Infrastructure.Database.Models.Round(RoundDto roundDto)
        {
            return new Volleyball.Infrastructure.Database.Models.Round
            {
                Id = roundDto.Id,
                Name = roundDto.Name,
                SeasonId = roundDto.SeasonId
            };
        }
    }
}
