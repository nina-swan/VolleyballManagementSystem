using System;
using System.Collections.Generic;

namespace Volleyball.Infrastructure.Database.Models;

public partial class Log
{
    public int IdLogu { get; set; }

    public string? Link { get; set; }

    public string Opis { get; set; } = null!;

    public DateTime Data { get; set; }

    public bool Admin { get; set; }

    public virtual ICollection<LogPersonalny> LogPersonalnies { get; set; } = new List<LogPersonalny>();
}
