using System;
using System.Collections.Generic;

namespace Volleyball.Infrastructure.Database.Models;

public partial class MiejsceKomentarza
{
    public int IdMiejscaKomentarza { get; set; }

    public string Nazwa { get; set; } = null!;

    public virtual ICollection<Komentarz> Komentarzs { get; set; } = new List<Komentarz>();
}
