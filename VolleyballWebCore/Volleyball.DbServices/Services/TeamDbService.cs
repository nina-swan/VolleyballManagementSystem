using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volleyball.DTO;
using Volleyball.Infrastructure.Database.Models;

namespace Volleyball.DbServices.Services
{
    public class TeamDbService
    {
        private readonly VolleyballContext context;

        public TeamDbService(VolleyballContext context)
        {
            this.context = context;
        }

        public TeamDbService()
        {
            context = new VolleyballContext();
        }

        public List<TeamDto> GetAllTeamsAsync()
        {
            return context.Teams.ToList().Select(TeamDto.GenerateTeamDto).ToList();
        }

        public async Task<TeamDto?> GetTeamByIdAsync(int id)
        {
            var team = await context.Teams.FirstOrDefaultAsync(t => t.Id == id);

            if(team == null)
            {
                return null;
            }

            return TeamDto.GenerateTeamDto(team);
        }   

        public async Task AddTeam(NewTeamDto team)
        {
            var teamPlayers = new List<TeamPlayer>();
            var newUsers = new List<TeamPlayerDto>();

            foreach (var player in team.Players)
            {
                if(player.Email != null)
                {
                    var user = await context.Users.Include(u => u.Credentials).FirstOrDefaultAsync(u => u.Credentials.Email == player.Email);
                    if (user != null)
                    {
                        teamPlayers.Add(new TeamPlayer
                        {
                            Player = user,
                            JoinDate = DateTime.Now
                        });
                        continue;
                    }
                }
                newUsers.Add(player);
                teamPlayers.Add(new TeamPlayer
                {
                    Player = new User
                    {
                        FirstName = player.FirstName,
                        LastName = player.LastName,
                        Credentials = null
                    },
                    JoinDate = DateTime.Now
                });
            }

            var newTeam = new Team
            {
                Name = team.Name,
                CreationDate = DateTime.Now,
                Image = team.Image,
                League = null,
                Captain = await context.Users.FirstOrDefaultAsync(u => u.Id == team.CaptainId) ?? throw new InvalidOperationException(),
                TeamPlayers = teamPlayers,
                Email = team.Email,
                Logo = team.Logo,
                Phone = team.Phone,
                TeamDescription = team.TeamDescription,
                Website = team.Website
            };
            await context.Teams.AddAsync(newTeam);
            await context.SaveChangesAsync();

            foreach(var player in teamPlayers)
            {
                player.Team = newTeam;
                await context.SaveChangesAsync();
            }

            foreach(var newUser in newUsers)
            {
                SendEmailAddedToTeam(newUser, team);
            }

        }

        public void SendEmailAddedToTeam(TeamPlayerDto player, NewTeamDto team)
        {
            // TODO: Send email to player
        }

    }
}
