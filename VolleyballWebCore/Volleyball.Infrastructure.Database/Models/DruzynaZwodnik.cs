using System;
using System.Collections.Generic;

namespace Volleyball.Infrastructure.Database.Models;

public partial class DruzynaZwodnik
{
    public int IdDruzynyZawodnika { get; set; }

    public int IdDruzyny { get; set; }

    public int IdZawodnika { get; set; }

    public DateTime DataDolaczenia { get; set; }

    public virtual Druzyna IdDruzynyNavigation { get; set; } = null!;

    public virtual Uzytkownik IdZawodnikaNavigation { get; set; } = null!;
}
