using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volleyball.DTO.Teams;
using Volleyball.Infrastructure.Database.Models;
using VolleyballDomain.Shared;

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

        public async Task<ServiceResponse<List<PositionDto>>> GetAllPositionsAsync()
        {
            var response = new ServiceResponse<List<PositionDto>>();

            try
            {
                response.Data = (await context.Positions.ToListAsync()).Select(p => (PositionDto)p).ToList();
            }
            catch (Exception e)
            {
                response.Success = false;
                response.Message = e.Message;
            }

            return response;
        }

        public async Task<ServiceResponse<Position>> GetPositionByIdAsync(int id)
        {
            var response = new ServiceResponse<Position>();

            var position = await context.Positions.FirstOrDefaultAsync(p => p.Id == id);
            if (position == null)
            {
                return new ServiceResponse<Position>
                {
                    Success = false,
                    Message = "Position not found"
                };
            }

            response.Data = position;
            return response;
        }

        public async Task<ServiceResponse> CreatePosition(PositionDto position)
        {
            var response = new ServiceResponse();
            try
            {
                context.Positions.Add((Position)position);
                await context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                response.Success = false;
                response.Message = e.Message;
            }

            return response;
        }

        public async Task<ServiceResponse> UpdatePosition(int id, PositionDto updatedPosition)
        {
            var result = new ServiceResponse();
            try
            {
                var position = await context.Positions.FirstOrDefaultAsync(p => p.Id == id);
                if (position == null)
                {
                    result.Success = false;
                    result.Message = "Position not found";
                    return result;
                }

                position.Name = updatedPosition.Name;
                await context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                result.Success = false;
                result.Message = e.Message;
            }

            return result;
        }

        public async Task<ServiceResponse> DeletePosition(int id)
        {
            var result = new ServiceResponse();
            try
            {
                var position = await context.Positions.FirstOrDefaultAsync(p => p.Id == id);
                if (position == null)
                {
                    result.Success = false;
                    result.Message = "Position not found";
                    return result;
                }

                context.Positions.Remove(position);
                await context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                result.Success = false;
                result.Message = e.Message;
            }
            return result;
        }
    }
}
