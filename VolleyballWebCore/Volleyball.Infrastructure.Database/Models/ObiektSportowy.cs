using System;
using System.Collections.Generic;

namespace Volleyball.Infrastructure.Database.Models;

public partial class ObiektSportowy
{
    public int IdObiektu { get; set; }

    public string Nazwa { get; set; } = null!;

    public string? InfoDodatkowe { get; set; }

    public virtual ICollection<Mecz> Meczs { get; set; } = new List<Mecz>();
}
