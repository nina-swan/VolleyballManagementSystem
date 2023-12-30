using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Volleyball.DbServices.Services;
using Volleyball.DTO.Teams;

namespace Volleyball.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeagueController : ControllerBase
    {
        private readonly LeagueDbService leagueDbService = new LeagueDbService();

        [HttpGet]
        public async Task<IActionResult> GetAllLeagues()
        {
            return Ok(await leagueDbService.GetAllLeaguesAsync());
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateLeague(LeagueDto league)
        {
            string? id = User.Identity?.Name;
            if (string.IsNullOrWhiteSpace(id))
            {
                return Unauthorized();
            }
            var result = await leagueDbService.CreateLeagueAsync(league);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [Authorize]
        [HttpPut]
        public async Task<IActionResult> UpdateLeague(LeagueDto league)
        {
            string? id = User.Identity?.Name;
            if (string.IsNullOrWhiteSpace(id))
            {
                return Unauthorized();
            }
            var result = await leagueDbService.UpdateLeagueAsync(league);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLeague(int id)
        {
            string? userId = User.Identity?.Name;
            if (string.IsNullOrWhiteSpace(userId))
            {
                return Unauthorized();
            }
            var result = await leagueDbService.DeleteLeagueAsync(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}
