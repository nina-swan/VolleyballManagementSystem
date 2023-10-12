
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volleyball.Infrastructure.Database.Models;

namespace Volleyball.DTO
{
    public class NewTeamDto
    {
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string? TeamDescription { get; set; }
        public string? Website { get; set; }
        public byte[]? Image { get; set; }
        public byte[]? Logo { get; set; }
        public List<TeamPlayerDto> Players { get; set; } = new List<TeamPlayerDto>();
        public int CaptainId { get; set; }

        // Method to generate NewTeamDto from Team
        public static NewTeamDto GenerateNewTeamDto(Team team)
        {
            return new NewTeamDto
            {
                Name = team.Name,
                Email = team.Email,
                Phone = team.Phone,
                TeamDescription = team.TeamDescription,
                Website = team.Website,
                Image = team.Image,
                Logo = team.Logo
            };
        }
    }
}
