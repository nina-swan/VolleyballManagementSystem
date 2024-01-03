using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Volleyball.DTO.Teams
{
    public class PlayerSummaryDto : ISelectValue
    {
        public int Id { get; set; }

        public string Name
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public byte[]? Photo { get; set; }

        public int? Height { get; set; }

        public string PositionName { get; set; } = null!;

        public int? JerseyNumber { get; set; }

        public static explicit operator PlayerSummaryDto?(User? user)
        {
            return GenerateUserSummaryDto(user);
        }


        // Method to generate UserSummaryDto from User
        public static PlayerSummaryDto? GenerateUserSummaryDto(User? user)
        {
            if (user == null)
            {
                return null;
            }
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
