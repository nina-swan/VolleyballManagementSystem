using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Volleyball.DbServices.Services;
using Volleyball.DTO.Teams;

namespace Volleyball.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PositionController : ControllerBase
    {
        private readonly PositionDbService positionDbService = new PositionDbService();
        [HttpGet]
        public async Task<IActionResult> GetAllPositions()
        { 
            var result = await positionDbService.GetAllPositionsAsync();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPositionById(int id)
        {
            return Ok(await positionDbService.GetPositionByIdAsync(id));
        }
        [HttpPost]
        public async Task<IActionResult> CreatePosition(PositionDto position)
        {
            await positionDbService.CreatePosition(position);
            return Ok();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePosition(int id, PositionDto updatedPosition)
        {
            await positionDbService.UpdatePosition(id, updatedPosition);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePosition(int id)
        {
            await positionDbService.DeletePosition(id);
            return Ok();
        }       
    }
}
