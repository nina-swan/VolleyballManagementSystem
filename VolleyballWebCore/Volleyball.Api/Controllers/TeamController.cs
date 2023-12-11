using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Volleyball.DbServices.Services;
using Volleyball.DTO.Teams;

namespace Volleyball.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private readonly TeamDbService teamDbService = new TeamDbService();

        [HttpGet]
        public async Task<IActionResult> GetAllTeams()
        {
            return Ok(await teamDbService.GetAllTeamsAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTeamById(int id)
        {
            var result = await teamDbService.GetTeamByIdAsync(id);   
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateTeam(NewTeamDto team)
        {
            string? id = User.Identity?.Name;

            if (string.IsNullOrWhiteSpace(id))
            {
                return Unauthorized();
            }

            var result = await teamDbService.AddTeam(team, id);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [Authorize]
        [HttpPut]
        public async Task<IActionResult> UpdateTeam(ManageTeamDto team)
        {
            string? id = User.Identity?.Name;
            if (string.IsNullOrWhiteSpace(id))
            {
                return Unauthorized();
            }
            var result = await teamDbService.UpdateTeam(team, id);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPut]
        [Route("updateTeamPlayer")]
        public async Task<IActionResult> UpdateTeamPlayer(PlayerSummaryDto teamPlayer)
        {
            var result = await teamDbService.UpdateTeamPlayer(teamPlayer);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        // controller to get teams by league id
        [HttpGet]
        [Route("league/{leagueId}")]
        public async Task<IActionResult> GetTeamsByLeagueId(int leagueId)
        {
            var result = await teamDbService.GetTeamsByLeagueId(leagueId);
            
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet]
        [Authorize]
        [Route("managedteam")]
        public async Task<IActionResult> GetManagedTeam()
        {
            string? id = User.Identity?.Name;
            if (string.IsNullOrWhiteSpace(id))
            {
                return Unauthorized();
            }

            var result = await teamDbService.GetTeamByCaptain(id);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPut]
        [Authorize]
        [Route("updatecaptain")]
        public async Task<IActionResult> UpdateCaptain(int captainId)
        {
            string? id = User.Identity?.Name;
            if (string.IsNullOrWhiteSpace(id))
            {
                return Unauthorized();
            }
            var result = await teamDbService.UpdateCaptain(captainId, id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
