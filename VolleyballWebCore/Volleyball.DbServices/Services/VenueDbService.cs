using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volleyball.DTO.Matches;
using Volleyball.Infrastructure.Database.Models;
using VolleyballDomain.Shared;

namespace Volleyball.DbServices.Services
{
    public class VenueDbService
    {
        private readonly VolleyballContext _context = new VolleyballContext();

        public VenueDbService() { }

        public async Task<ServiceResponse<List<VenueDto>>> GetAllVenuesAsync()
        {
            var response = new ServiceResponse<List<VenueDto>>();
            var venues = (await _context.SportsVenues.Include(v => v.Matches).ToListAsync()).Select(v => (VenueDto)v);
            response.Data = venues.ToList();
            return response;
        }

        public async Task<ServiceResponse> CreateVenue(VenueDto venue)
        {
            var response = new ServiceResponse();
            try
            {
                await _context.SportsVenues.AddAsync((SportsVenue)venue);
                await _context.SaveChangesAsync();
            }
            catch
            {
                response.Success = false;
                response.Message = "Błąd w trakcie zapisu danych";
            }
            return response;
        }

        public async Task<ServiceResponse> UpdateVenue(VenueDto venue)
        {
            var response = new ServiceResponse();
            try
            {
                var venueToUpdate = await _context.SportsVenues.FirstOrDefaultAsync(v => v.Id == venue.Id);

                if (venueToUpdate == null)
                {
                    response.Success = false;
                    response.Message = "Nie znaleziono obiektu";
                    return response;
                }

                venueToUpdate.Name = venue.Name;
                venueToUpdate.AdditionalInfo = venue.AdditionalInfo;
                _context.Update(venueToUpdate);
                await _context.SaveChangesAsync();
            }
            catch
            {
                response.Success = false;
                response.Message = "Błąd w trakcie zapisu danych";
            }
            return response;
        }

        public async Task<ServiceResponse> DeleteVenue(int id)
        {
            var response = new ServiceResponse();
            try
            {
                var venueToDelete = await _context.SportsVenues.FirstOrDefaultAsync(v => v.Id == id);
                if (venueToDelete == null)
                {
                    response.Success = false;
                    response.Message = "Nie znaleziono obiektu";
                    return response;
                }
                _context.Remove(venueToDelete);
                await _context.SaveChangesAsync();
            }
            catch
            {
                response.Success = false;
                response.Message = "Błąd w trakcie zapisu danych";
            }
            return response;
        }
    }
}
