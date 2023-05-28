using System;
using System.Collections.Generic;

namespace Volleyball.Infrastructure.Database.Models;

public partial class PrywatneWiadomosci
{
    public string? Nadawca { get; set; }

    public string? Treść { get; set; }

    public string Odbiorca { get; set; } = null!;

    public string? Data { get; set; }

    public bool? Aktywny { get; set; }
}
