using System;
using System.Collections.Generic;

namespace Volleyball.Infrastructure.Database.Models;

public partial class Pozycja
{
    public int IdPozycji { get; set; }

    public string Nazwa { get; set; } = null!;

    public virtual ICollection<Uzytkownik> Uzytkowniks { get; set; } = new List<Uzytkownik>();
}
