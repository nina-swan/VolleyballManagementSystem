using System;
using System.Collections.Generic;

namespace Volleyball.Infrastructure.Database.Models;

public partial class Zaproszenie
{
    public int IdZaproszenia { get; set; }

    public int IdZawodnika { get; set; }

    public int IdDruzyny { get; set; }

    public DateTime DataUtworzenia { get; set; }

    public virtual Druzyna IdDruzynyNavigation { get; set; } = null!;

    public virtual Uzytkownik IdZawodnikaNavigation { get; set; } = null!;
}
