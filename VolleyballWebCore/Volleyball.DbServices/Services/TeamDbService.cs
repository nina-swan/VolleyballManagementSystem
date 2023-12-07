using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;
using Volleyball.DTO.Teams;
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

        public async Task<ServiceResponse<List<TeamDto>>> GetAllTeamsAsync()
        {
            var response = new ServiceResponse<List<TeamDto>>();
            response.Data = (await context.Teams.ToListAsync()).Select(t => (TeamDto)t).ToList();
            return response;
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

        public async Task<ServiceResponse<TeamDto>> AddTeam(NewTeamDto team, string userId)
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
                        Height = (byte?)player.Height,
                        JerseyNumber = (byte?)player.JerseyNumber,
                        PositionId = player.PositionId,
                        Credentials = null
                    },
                    JoinDate = DateTime.Now
                });
            }

            var captain = (await context.Credentials.Include(c => c.User).FirstOrDefaultAsync(u => u.Email == userId))?.User;

            if (captain == null)
            {
                response.Success = false;
                response.Message = "Captain not found";
                return response;
            }

            var newTeam = new Team
            {
                Name = team.Name,
                CreationDate = DateTime.Now,
                Image = team.Image,
                LeagueId = 1,
                CaptainId = captain.Id,
                TeamPlayers = teamPlayers,
                Email = team.Email,
                Logo = team.Logo,
                Phone = team.Phone,
                TeamDescription = team.TeamDescription,
                Website = team.Website,
                IsReportedToPlay = false
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

        public async Task<ServiceResponse<ManagedTeamDataDto>> GetTeamByCaptain(string email)
        {
            var response = new ServiceResponse<ManagedTeamDataDto>();
            
            var team = await context.Teams
                .Include(t => t.League)
                .Include(u => u.Captain)
                .Include(t => t.TeamPlayers).ThenInclude(t => t.Player)
                .FirstOrDefaultAsync(t => t.Captain.Credentials.Email == email);

            if (team == null)
            {
                response.Success = false;
                response.Message = "Team not found";
                return response;
            }

            response.Data = (ManagedTeamDataDto)team;
            return response;
        }

        // get team by league id
        public async Task<ServiceResponse<List<TeamDto>>> GetTeamsByLeagueId(int leagueId)
        {
            var response = new ServiceResponse<List<TeamDto>>();
            var teams = await context.Teams.Where(t => t.League != null && t.League.Id == leagueId).ToListAsync();
            if (teams == null)
            {
                response.Success = false;
                response.Message = "Teams not found";
                return response;
            }
            response.Data = teams.Select(t => (TeamDto)t).ToList();
            return response;
        }


        private void SendEmailAddedToTeam(TeamPlayerDto player, NewTeamDto team)
        {
            // TODO: Send email to player
        }

    }
}
