using System;
using System.Collections.Generic;

namespace Volleyball.Infrastructure.Database.Models;

public partial class LogPersonalny
{
    public int IdPersonLogu { get; set; }

    public int IdUzytkownika { get; set; }

    public int IdLogu { get; set; }

    public virtual Log IdLoguNavigation { get; set; } = null!;

    public virtual Uzytkownik IdUzytkownikaNavigation { get; set; } = null!;
}
