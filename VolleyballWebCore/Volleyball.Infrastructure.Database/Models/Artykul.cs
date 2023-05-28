using System;
using System.Collections.Generic;

namespace Volleyball.Infrastructure.Database.Models;

public partial class Artykul
{
    public int IdArtykulu { get; set; }

    public int IdAutora { get; set; }

    public string Tresc { get; set; } = null!;

    public DateTime DataUtworzenia { get; set; }

    public string Tytul { get; set; } = null!;

    public bool? Aktywny { get; set; }

    public byte[] Zdjecie { get; set; } = null!;

    public virtual Uzytkownik IdAutoraNavigation { get; set; } = null!;
}
