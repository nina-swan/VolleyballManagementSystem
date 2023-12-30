using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Volleyball.DTO.Matches
{
    public class VenueDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public string? AdditionalInfo { get; set; }

        public static explicit operator VenueDto(Volleyball.Infrastructure.Database.Models.SportsVenue venue)
        {
            return new VenueDto
            {
                Id = venue.Id,
                Name = venue.Name,
                AdditionalInfo = venue.AdditionalInfo
            };
        }

        public static explicit operator Volleyball.Infrastructure.Database.Models.SportsVenue(VenueDto venueDto)
        {
            return new Volleyball.Infrastructure.Database.Models.SportsVenue    
            {
                Id = venueDto.Id,
                Name = venueDto.Name,
                AdditionalInfo = venueDto.AdditionalInfo
            };
        }
    }
}
