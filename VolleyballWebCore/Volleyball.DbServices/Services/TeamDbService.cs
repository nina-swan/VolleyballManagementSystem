using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volleyball.DTO;
using Volleyball.Infrastructure.Database.Models;
using VolleyballDomain.Shared;

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

        public async Task<ServiceResponse<TeamDto>> GetTeamByIdAsync(int id)
        {
            var response = new ServiceResponse<TeamDto>();
            var team = await context.Teams.FirstOrDefaultAsync(t => t.Id == id);

            if (team == null)
            {
                response.Success = false;
                response.Message = "Team not found";
                return response;
            }

            response.Data = TeamDto.GenerateTeamDto(team);

            return response;
        }

        public async Task<ServiceResponse<TeamDto>> AddTeam(NewTeamDto team)
        {
            var response = new ServiceResponse<TeamDto>();

            var teamPlayers = new List<TeamPlayer>();
            var newUsersToSendInvitation = new List<TeamPlayerDto>();

            foreach (var player in team.Players)
            {
                // if players email is not null, try to match them with existing account
                if (player.Email != null)
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

                // if cant match, add them to Users
                newUsersToSendInvitation.Add(player);
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

            try
            {
                await context.Teams.AddAsync(newTeam);
                await context.SaveChangesAsync();

                foreach (var player in teamPlayers)
                {
                    player.Team = newTeam;
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                response.Success = false;
                response.Message = e.Message;
                return response;
            }

            foreach (var newUser in newUsersToSendInvitation)
            {
                SendEmailAddedToTeam(newUser, team);
            }

            return response;
        }

        public async Task<ServiceResponse<TeamDto>> UpdateTeam(TeamDto team)
        {
            var response = new ServiceResponse<TeamDto>();

            var teamToUpdate = await context.Teams.FirstOrDefaultAsync(t => t.Id == team.Id);

            if (teamToUpdate == null)
            {
                response.Success = false;
                response.Message = "Team not found";
                return response;
            }

            teamToUpdate.Name = team.Name;
            teamToUpdate.Image = team.Image;
            teamToUpdate.Logo = team.Logo;
            teamToUpdate.Phone = team.Phone;
            teamToUpdate.TeamDescription = team.TeamDescription;
            teamToUpdate.Website = team.Website;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                response.Success = false;
                response.Message = e.Message;
                return response;
            }

            return response;
        }

        public async Task<ServiceResponse> UpdateTeamPlayer(PlayerSummaryDto userSummary)
        {
            var response = new ServiceResponse();

            var player = context.Users.FirstOrDefault(u => u.Id == userSummary.Id);

            if (player == null)
            {
                response.Success = false;
                response.Message = "Player not found";
                return response;
            }

            player.JerseyNumber = (byte?)userSummary.JerseyNumber;
            player.Height = (byte?)userSummary.Height;
            player.Position = await context.Positions.FirstOrDefaultAsync(p => p.Name == userSummary.PositionName);

            try
            {
                await context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                response.Success = false;
                response.Message = e.Message;
                return response;
            }

            return response;
        }

        public void SendEmailAddedToTeam(TeamPlayerDto player, NewTeamDto team)
        {
            // TODO: Send email to player
        }

    }
}
