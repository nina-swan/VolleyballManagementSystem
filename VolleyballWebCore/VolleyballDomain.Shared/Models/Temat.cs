using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace VolleyballDomain.Shared.Models;

[Table("Topics", Schema = "dbo")]
public partial class Temat
{
    [Key]
    [Column("idTematu")]
    public int IdTematu { get; set; }

    [Column("idAutora")]
    public int IdAutora { get; set; }

    [Column("tresc")]
    [StringLength(3000)]
    [Unicode(false)]
    public string Tresc { get; set; } = null!;

    [Column("dataUtworzenia")]
    public DateTime DataUtworzenia { get; set; }

    [Column("tytul")]
    [StringLength(255)]
    [Unicode(false)]
    public string Tytul { get; set; } = null!;

    [Column("idKategorii")]
    public int IdKategorii { get; set; }

    [Required]
    [Column("aktywny")]
    public bool? Aktywny { get; set; }

    [ForeignKey("IdAutora")]
    [InverseProperty("Topics")]
    public virtual Player IdAutoraNavigation { get; set; } = null!;

    [ForeignKey("IdKategorii")]
    [InverseProperty("Topics")]
    public virtual Kategoria IdKategoriiNavigation { get; set; } = null!;
}
