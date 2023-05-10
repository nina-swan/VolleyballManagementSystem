using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace VolleyballDomain.Shared.Models;

[Table("BetScore", Schema = "dbo")]
public partial class WynikTypowany
{
    [Key]
    [Column("idWynikuTypowanego")]
    public int IdWynikuTypowanego { get; set; }

    [Column("idUzytkownika")]
    public int IdUzytkownika { get; set; }

    [Column("idMeczu")]
    public int IdMeczu { get; set; }

    [Column("wynik1")]
    public byte Wynik1 { get; set; }

    [Column("wynik2")]
    public byte Wynik2 { get; set; }

    [ForeignKey("GameId")]
    [InverseProperty("BetScore")]
    public virtual Game IdMeczuNavigation { get; set; } = null!;

    [ForeignKey("PlayerId")]
    [InverseProperty("BetScore")]
    public virtual Player IdUzytkownikaNavigation { get; set; } = null!;
}
