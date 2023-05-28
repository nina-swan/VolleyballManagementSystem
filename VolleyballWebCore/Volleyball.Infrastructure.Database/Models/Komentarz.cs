using System;
using System.Collections.Generic;

namespace Volleyball.Infrastructure.Database.Models;

public partial class Komentarz
{
    public int IdKomentarza { get; set; }

    public int IdTresci { get; set; }

    public int IdAutora { get; set; }

    public string Tresc { get; set; } = null!;

    public bool Aktywny { get; set; }

    public DateTime DataUtworzenia { get; set; }

    public int IdMiejscaKomentarza { get; set; }

    public virtual Uzytkownik IdAutoraNavigation { get; set; } = null!;

    public virtual MiejsceKomentarza IdMiejscaKomentarzaNavigation { get; set; } = null!;
}
