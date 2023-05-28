using System;
using System.Collections.Generic;

namespace Volleyball.Infrastructure.Database.Models;

public partial class Sezon
{
    public int IdSezonu { get; set; }

    public string Nazwa { get; set; } = null!;

    public virtual ICollection<Kolejka> Kolejkas { get; set; } = new List<Kolejka>();
}
