using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Volleyball.Infrastructure.Database.Models;

namespace Volleyball.DTO.Teams
{
    public class SeasonDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public static explicit operator SeasonDto(Season season)
        {
            return new SeasonDto
            {
                Id = season.Id,
                Name = season.Name
            };
        }
    }
}
