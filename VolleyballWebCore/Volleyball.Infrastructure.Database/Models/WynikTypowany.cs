using System;
using System.Collections.Generic;

namespace Volleyball.Infrastructure.Database.Models;

public partial class WynikTypowany
{
    public int IdWynikuTypowanego { get; set; }

    public int IdUzytkownika { get; set; }

    public int IdMeczu { get; set; }

    public byte Wynik1 { get; set; }

    public byte Wynik2 { get; set; }

    public virtual Mecz IdMeczuNavigation { get; set; } = null!;

    public virtual Uzytkownik IdUzytkownikaNavigation { get; set; } = null!;
}
