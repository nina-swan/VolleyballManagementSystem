using System;
using System.Collections.Generic;

namespace Volleyball.Infrastructure.Database.Models;

public partial class Liga
{
    public int IdLigi { get; set; }

    public string Nazwa { get; set; } = null!;

    public virtual ICollection<Druzyna> Druzynas { get; set; } = new List<Druzyna>();

    public virtual ICollection<Mecz> Meczs { get; set; } = new List<Mecz>();
}
