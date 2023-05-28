using System;
using System.Collections.Generic;

namespace Volleyball.Infrastructure.Database.Models;

public partial class Uzytkownik
{
    public int IdUzytkownika { get; set; }

    public string Imie { get; set; } = null!;

    public string Nazwisko { get; set; } = null!;

    public Guid? IdKonta { get; set; }

    public int? RokUrodzenia { get; set; }

    public string? Miasto { get; set; }

    public string? InfoOsobie { get; set; }

    public byte[]? Zdjecie { get; set; }

    public bool Plec { get; set; }

    public byte? Wzrost { get; set; }

    public byte? Waga { get; set; }

    public byte? NrNaKoszulce { get; set; }

    public int? ZasiegBlok { get; set; }

    public int? ZasiegAtak { get; set; }

    public string? SiatkarskiIdol { get; set; }

    public string? EmailDodatkowy { get; set; }

    public string? Hobby { get; set; }

    public string? Telefon { get; set; }

    public int IdPozycji { get; set; }

    public int? ZdjecieWidth { get; set; }

    public int? ZdjecieHeight { get; set; }

    public virtual ICollection<Artykul> Artykuls { get; set; } = new List<Artykul>();

    public virtual Druzyna? Druzyna { get; set; }

    public virtual ICollection<DruzynaZwodnik> DruzynaZwodniks { get; set; } = new List<DruzynaZwodnik>();



    public virtual Pozycja IdPozycjiNavigation { get; set; } = null!;

    public virtual ICollection<Komentarz> Komentarzs { get; set; } = new List<Komentarz>();

    public virtual ICollection<LogPersonalny> LogPersonalnies { get; set; } = new List<LogPersonalny>();

    public virtual ICollection<Mecz> MeczIdMvpNavigations { get; set; } = new List<Mecz>();

    public virtual ICollection<Mecz> MeczIdSedziegoNavigations { get; set; } = new List<Mecz>();

    public virtual ICollection<Temat> Temats { get; set; } = new List<Temat>();

    public virtual ICollection<WynikTypowany> WynikTypowanies { get; set; } = new List<WynikTypowany>();

    public virtual ICollection<Zaproszenie> Zaproszenies { get; set; } = new List<Zaproszenie>();
}
