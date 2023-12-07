using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Volleyball.DTO.Users
{
    public class UpdateUserDto
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int? BirthYear { get; set; }
        public string? City { get; set; }
        public string? PersonalInfo { get; set; }
        public byte[]? Photo { get; set; }
        public bool? Gender { get; set; }
        public byte? Height { get; set; }
        public byte? Weight { get; set; }
        public byte? JerseyNumber { get; set; }
        public int? BlockRange { get; set; }
        public int? AttackRange { get; set; }
        public string? VolleyballIdol { get; set; }
        public string? AdditionalEmail { get; set; }
        public string? Hobby { get; set; }
        public string? Phone { get; set; }
        public int? PositionId { get; set; }
    }
}
