using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Volleyball.DTO
{
    public class PlayerSummaryDto
    {
        public int Id { get; set; }

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public byte[]? Photo { get; set; }

        public int? Height { get; set; }

        public string PositionName { get; set; } = null!;   

        public int? JerseyNumber { get; set; }

        // Method to generate UserSummaryDto from User
        public static PlayerSummaryDto GenerateUserSummaryDto(User user)
        {
            return new PlayerSummaryDto
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Photo = user.Photo,
                Height = user.Height,
                PositionName = user.Position != null ? user.Position.Name : "",
                JerseyNumber = user.JerseyNumber
            };
        }
    }
}
