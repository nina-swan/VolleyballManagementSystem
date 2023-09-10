
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Volleyball.Infrastructure.Database.Models
{
    public class Credentials
    {
        public int Id { get; set; }
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;

        public int UserId { get; set; }

        public virtual User User { get; set; } = null!;

        public List<Role> Roles { get; set; }
    }
}
