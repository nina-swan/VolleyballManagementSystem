using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Volleyball.Infrastructure.Database.Models;

namespace Volleyball.DTO.Teams
{
    public class ManagedTeamDataDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public DateTime CreationDate { get; set; }

        public byte[]? Image { get; set; }

        public LeagueDto? League { get; set; }

        public TeamPlayerDto Captain { get; set; } = null!;

        public List<TeamPlayerDto> Players { get; set; } = null!;

        public string Email { get; set; } = null!;

        public byte[]? Logo { get; set; }

        public byte[]? Photo { get; set; }

        public string Phone { get; set; } = null!;

        public string? TeamDescription { get; set; }

        public string? Website { get; set; }

        public int? AvailableTransfers { get; set; }

        // Method to generate TeamDto from Team
        public static ManagedTeamDataDto GenerateTeamDto(Team team)
        {
            return new ManagedTeamDataDto
            {
                Id = team.Id,
                Name = team.Name,
                CreationDate = team.CreationDate,
                Image = team.Image,
                League = LeagueDto.GenerateLeagueDto(team.League),
                Captain = (TeamPlayerDto)team.Captain,
                Players = team.TeamPlayers.Select(p => (TeamPlayerDto)p).ToList(),
                Email = team.Email,
                Logo = team.Logo,
                Photo = team.Image,
                Phone = team.Phone,
                TeamDescription = team.TeamDescription,
                Website = team.Website,
                AvailableTransfers = -team.ChangeCount
            };
        }

        public static explicit operator ManagedTeamDataDto(Team team)
        {
            return GenerateTeamDto(team);
        }

    }
}
