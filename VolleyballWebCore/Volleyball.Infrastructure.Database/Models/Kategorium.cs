using System;
using System.Collections.Generic;

namespace Volleyball.Infrastructure.Database.Models;

public partial class Kategorium
{
    public int IdKategorii { get; set; }

    public string Nazwa { get; set; } = null!;

    public virtual ICollection<Temat> Temats { get; set; } = new List<Temat>();
}
