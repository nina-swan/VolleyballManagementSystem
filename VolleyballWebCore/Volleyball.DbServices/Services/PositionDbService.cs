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
    // TODO: Implement PositionDbServices   
    public class PositionDbService
    {
        private readonly VolleyballContext context;

        public PositionDbService()
        {
            context = new VolleyballContext();
        }

        public PositionDbService(VolleyballContext context)
        {
            this.context = context;
        }

        public async Task<List<Position>> GetAllPositionsAsync()
        {
            return await context.Positions.ToListAsync();
        }

        public async Task<Position> GetPositionByIdAsync(int id)
        {
            return await context.Positions.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task CreatePosition(PositionDto position)
        {
            context.Positions.Add(position);
            await context.SaveChangesAsync();
        }

        public async Task UpdatePosition(int id, PositionDto updatedPosition)
        {
            var position = await context.Positions.FirstOrDefaultAsync(p => p.Id == id);
            if (position == null)
            {
                throw new InvalidOperationException("Position not found");
            }

            position.Name = updatedPosition.Name;
            await context.SaveChangesAsync();
        }

        public async Task DeletePosition(int id)
        {
            var position = await context.Positions.FirstOrDefaultAsync(p => p.Id == id);
            if (position == null)
            {
                throw new InvalidOperationException("Position not found");
            }

            context.Positions.Remove(position);
            await context.SaveChangesAsync();
        }
    }
}
