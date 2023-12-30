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
    public class LeagueDbService
    {
        private readonly VolleyballContext _context;
        public LeagueDbService()
        {
            _context = new VolleyballContext();
        }

        public async Task<ServiceResponse<List<LeagueDto>>> GetAllLeaguesAsync()
        {
            var response = new ServiceResponse<List<LeagueDto>>();
            var leagues = await _context.Leagues.ToListAsync();
            response.Data = leagues.Select(l => (LeagueDto)l).ToList();
            return response;
        }

        // create league
        public async Task<ServiceResponse> CreateLeagueAsync(LeagueDto league)
        {
            var response = new ServiceResponse();
            var leagueToAdd = new League
            {
                Name = league.Name
            };
            await _context.Leagues.AddAsync(leagueToAdd);
            await _context.SaveChangesAsync();
            return response;
        }

        // update league
        public async Task<ServiceResponse> UpdateLeagueAsync(LeagueDto league)
        {
            var response = new ServiceResponse();
            var leagueToUpdate = await _context.Leagues.FirstOrDefaultAsync(l => l.Id == league.Id);
            if (leagueToUpdate == null)
            {
                response.Success = false;
                response.Message = "Nie znaleziono ligi";
                return response;
            }
            leagueToUpdate.Name = league.Name;
            _context.Leagues.Update(leagueToUpdate);
            await _context.SaveChangesAsync();
            return response;
        }

        // delete league
        public async Task<ServiceResponse> DeleteLeagueAsync(int id)
        {
            var response = new ServiceResponse();
            var league = await _context.Leagues.FirstOrDefaultAsync(l => l.Id == id);
            if (league == null)
            {
                response.Success = false;
                response.Message = "Nie znaleziono ligi";
                return response;
            }
            _context.Leagues.Remove(league);
            await _context.SaveChangesAsync();
            return response;
        }
    }
}
