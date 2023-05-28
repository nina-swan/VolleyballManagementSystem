using System;
using System.Collections.Generic;

namespace Volleyball.Infrastructure.Database.Models;

public partial class Druzyna
{
    public int IdDruzyny { get; set; }

    public string Nazwa { get; set; } = null!;

    public DateTime DataUtworzenia { get; set; }

    public byte[]? Zdjecie { get; set; }

    public int IdLigi { get; set; }

    public bool Zaakceptowana { get; set; }

    public int IdKapitana { get; set; }

    public string Email { get; set; } = null!;

    public bool? Zgloszona { get; set; }

    public int IleZmian { get; set; }

    public int? ZdjecieWidth { get; set; }

    public int? ZdjecieHeight { get; set; }

    public byte[]? Logo { get; set; }

    public int? LogoWidth { get; set; }

    public int? LogoHeight { get; set; }

    public string Telefon { get; set; } = null!;

    public string? OpisDruzyny { get; set; }

    public string? StronaWww { get; set; }

    public int? KorekcjaPunktow { get; set; }

    public virtual ICollection<DruzynaZwodnik> DruzynaZwodniks { get; set; } = new List<DruzynaZwodnik>();

    public virtual Uzytkownik IdKapitanaNavigation { get; set; } = null!;

    public virtual Liga IdLigiNavigation { get; set; } = null!;

    public virtual ICollection<Mecz> MeczIdDruzyny1Navigations { get; set; } = new List<Mecz>();

    public virtual ICollection<Mecz> MeczIdDruzyny2Navigations { get; set; } = new List<Mecz>();

    public virtual StatystykiDruzyny? StatystykiDruzyny { get; set; }

    public virtual ICollection<Zaproszenie> Zaproszenies { get; set; } = new List<Zaproszenie>();
}
