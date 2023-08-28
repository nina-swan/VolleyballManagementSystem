using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Volleyball.Infrastructure.Database.Models
{
    public partial class League
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public virtual ICollection<Team> Teams { get; set; } = new List<Team>();

        public virtual ICollection<Match> Matches { get; set; } = new List<Match>();
    }
}
