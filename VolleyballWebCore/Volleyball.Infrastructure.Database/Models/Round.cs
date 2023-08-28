using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Volleyball.Infrastructure.Database.Models
{
    public partial class Round
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public int SeasonId { get; set; }

        public virtual Season Season { get; set; } = null!;

        public virtual ICollection<Match> Matches { get; set; } = new List<Match>();
    }
}
