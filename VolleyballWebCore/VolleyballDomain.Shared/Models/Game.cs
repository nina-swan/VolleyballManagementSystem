using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace VolleyballDomain.Shared.Models;

[Table("Game", Schema = "dbo")]
public partial class Game
{
    [Key]
    public int GameId { get; set; }

    public DateTime GameDate { get; set; }

    public DateTime CreatedDate { get; set; }

    public Place Place { get; set; }

    [Column("idLigi")]
    public int IdLigi { get; set; }

    [Column("sektor")]
    public byte Sektor { get; set; }

    [Column("idDruzyny1")]
    public int IdDruzyny1 { get; set; }

    [Column("idDruzyny2")]
    public int IdDruzyny2 { get; set; }

    [Column("wynikDruzyny1")]
    public byte WynikDruzyny1 { get; set; }

    [Column("wynikDruzyny2")]
    public byte WynikDruzyny2 { get; set; }

    [Column("idKolejki")]
    public int IdKolejki { get; set; }

    [Column("idSedziego")]
    public int? IdSedziego { get; set; }

    [Column("nazwaNieznanegoSedziego")]
    [StringLength(255)]
    [Unicode(false)]
    public string? NazwaNieznanegoSedziego { get; set; }

    [Column("infoOMeczu")]
    [StringLength(3000)]
    [Unicode(false)]
    public string? InfoOmeczu { get; set; }

    [Column("idMVP")]
    public int IdMvp { get; set; }

    [Column("w1s1")]
    public byte? W1s1 { get; set; }

    [Column("w1s2")]
    public byte? W1s2 { get; set; }

    [Column("w1s3")]
    public byte? W1s3 { get; set; }

    [Column("w1s4")]
    public byte? W1s4 { get; set; }

    [Column("w1s5")]
    public byte? W1s5 { get; set; }

    [Column("w2s1")]
    public byte? W2s1 { get; set; }

    [Column("w2s2")]
    public byte? W2s2 { get; set; }

    [Column("w2s3")]
    public byte? W2s3 { get; set; }

    [Column("w2s4")]
    public byte? W2s4 { get; set; }

    [Column("w2s5")]
    public byte? W2s5 { get; set; }

    [Column("ligaMeczu")]
    [StringLength(255)]
    [Unicode(false)]
    public string? LigaMeczu { get; set; }

    [ForeignKey("IdDruzyny1")]
    [InverseProperty("GamesTeam2")]
    public virtual Team IdDruzyny1Navigation { get; set; } = null!;

    [ForeignKey("IdDruzyny2")]
    [InverseProperty("GamesTeam1")]
    public virtual Team IdDruzyny2Navigation { get; set; } = null!;

    [ForeignKey("Id")]
    [InverseProperty("Game")]
    public virtual Round IdKolejkiNavigation { get; set; } = null!;

    [ForeignKey("IdLigi")]
    [InverseProperty("Game")]
    public virtual League IdLigiNavigation { get; set; } = null!;

    [ForeignKey("Place")]
    [InverseProperty("Game")]
    public virtual Place IdMiejscaNavigation { get; set; } = null!;

    [ForeignKey("IdMvp")]
    [InverseProperty("GamesMVP")]
    public virtual Player IdMvpNavigation { get; set; } = null!;

    [ForeignKey("IdSedziego")]
    [InverseProperty("GamesUmpire")]
    public virtual Player? IdSedziegoNavigation { get; set; }

    [InverseProperty("IdMeczuNavigation")]
    public virtual ICollection<WynikTypowany> WynikTypowany { get; set; } = new List<WynikTypowany>();
}
