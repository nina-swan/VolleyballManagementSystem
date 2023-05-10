using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace VolleyballDomain.Shared.Models;

[Table("Articles", Schema = "dbo")]
public partial class Artykul
{
    [Key]
    [Column("idArtykulu")]
    public int IdArtykulu { get; set; }

    [Column("idAutora")]
    public int IdAutora { get; set; }

    [Column("tresc", TypeName = "text")]
    public string Tresc { get; set; } = null!;

    [Column("dataUtworzenia", TypeName = "datetime")]
    public DateTime DataUtworzenia { get; set; }

    [Column("tytul")]
    [StringLength(255)]
    [Unicode(false)]
    public string Tytul { get; set; } = null!;

    [Required]
    [Column("aktywny")]
    public bool? Aktywny { get; set; }

    [Column("zdjecie", TypeName = "image")]
    public byte[] Zdjecie { get; set; } = null!;

    [ForeignKey("IdAutora")]
    [InverseProperty("Articles")]
    public virtual Player IdAutoraNavigation { get; set; } = null!;
}
