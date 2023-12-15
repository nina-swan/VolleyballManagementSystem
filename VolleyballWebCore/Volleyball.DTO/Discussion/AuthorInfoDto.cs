using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Volleyball.DTO.Discussion
{
    public class AuthorInfoDto
    {
        public int Id { get; set; }

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public byte[]? Photo { get; set; }

        public static explicit operator AuthorInfoDto(User user)
        {
            return new AuthorInfoDto
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Photo = user.Photo,
            };
        }
    }
}
