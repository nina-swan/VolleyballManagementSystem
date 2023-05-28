using System;
using System.Collections.Generic;

namespace Volleyball.Infrastructure.Database.Models;

public partial class Kolejka
{
    public int IdKolejki { get; set; }

    public string Nazwa { get; set; } = null!;

    public int IdSezonu { get; set; }

    public virtual Sezon IdSezonuNavigation { get; set; } = null!;

    public virtual ICollection<Mecz> Meczs { get; set; } = new List<Mecz>();
}
