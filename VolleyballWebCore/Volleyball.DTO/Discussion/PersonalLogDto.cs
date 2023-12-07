using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Volleyball.DTO.Discussion
{
    public class PersonalLogDto
    {
        public int Id { get; set; }

        public string? Link { get; set; }

        public string Description { get; set; } = null!;

        public DateTime Date { get; set; }

        public User? User { get; set; }
    }
}
