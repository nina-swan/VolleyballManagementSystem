using System;
using System.Collections.Generic;

namespace Volleyball.Infrastructure.Database.Models;

public partial class Mecz
{
    public int IdMeczu { get; set; }

    public DateTime Termin { get; set; }

    public DateTime DataUtworzenia { get; set; }

    public int IdMiejsca { get; set; }

    public int IdLigi { get; set; }

    public byte Sektor { get; set; }

    public int IdDruzyny1 { get; set; }

    public int IdDruzyny2 { get; set; }

    public byte WynikDruzyny1 { get; set; }

    public byte WynikDruzyny2 { get; set; }

    public int IdKolejki { get; set; }

    public int? IdSedziego { get; set; }

    public string? NazwaNieznanegoSedziego { get; set; }

    public string? InfoOmeczu { get; set; }

    public int IdMvp { get; set; }

    public byte? W1s1 { get; set; }

    public byte? W1s2 { get; set; }

    public byte? W1s3 { get; set; }

    public byte? W1s4 { get; set; }

    public byte? W1s5 { get; set; }

    public byte? W2s1 { get; set; }

    public byte? W2s2 { get; set; }

    public byte? W2s3 { get; set; }

    public byte? W2s4 { get; set; }

    public byte? W2s5 { get; set; }

    public string? LigaMeczu { get; set; }

    public virtual Druzyna IdDruzyny1Navigation { get; set; } = null!;

    public virtual Druzyna IdDruzyny2Navigation { get; set; } = null!;

    public virtual Kolejka IdKolejkiNavigation { get; set; } = null!;

    public virtual Liga IdLigiNavigation { get; set; } = null!;

    public virtual ObiektSportowy IdMiejscaNavigation { get; set; } = null!;

    public virtual Uzytkownik IdMvpNavigation { get; set; } = null!;

    public virtual Uzytkownik? IdSedziegoNavigation { get; set; }

    public virtual ICollection<WynikTypowany> WynikTypowanies { get; set; } = new List<WynikTypowany>();
}
