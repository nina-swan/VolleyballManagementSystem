using System;
using System.Collections.Generic;

namespace Volleyball.Infrastructure.Database.Models;

public partial class StatystykiDruzyny
{
    public int IdDruzyny { get; set; }

    public int Punkty { get; set; }

    public int RozegraneMecze { get; set; }

    public int WygraneMecze { get; set; }

    public int PrzegraneMecze { get; set; }

    public int Wygrane32 { get; set; }

    public int Przegrane23 { get; set; }

    public int MiejsceGlobalne { get; set; }

    public virtual Druzyna IdDruzynyNavigation { get; set; } = null!;
}
