using System;
using System.Collections.Generic;

namespace Volleyball.Infrastructure.Database.Models;

public partial class Temat
{
    public int IdTematu { get; set; }

    public int IdAutora { get; set; }

    public string Tresc { get; set; } = null!;

    public DateTime DataUtworzenia { get; set; }

    public string Tytul { get; set; } = null!;

    public int IdKategorii { get; set; }

    public bool? Aktywny { get; set; }

    public virtual Uzytkownik IdAutoraNavigation { get; set; } = null!;

    public virtual Kategorium IdKategoriiNavigation { get; set; } = null!;
}
