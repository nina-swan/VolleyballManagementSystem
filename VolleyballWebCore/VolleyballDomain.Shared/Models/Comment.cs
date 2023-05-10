using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace VolleyballDomain.Shared.Models;

[Table("Comment", Schema = "dbo")]
public partial class Comment
{
    [Key]
    [Column("idKomentarza")]
    public int IdKomentarza { get; set; }

    [Column("idTresci")]
    public int IdTresci { get; set; }

    [Column("idAutora")]
    public int IdAutora { get; set; }

    [Column("tresc")]
    [StringLength(3000)]
    [Unicode(false)]
    public string Tresc { get; set; } = null!;

    [Column("aktywny")]
    public bool Aktywny { get; set; }

    [Column("dataUtworzenia", TypeName = "datetime")]
    public DateTime DataUtworzenia { get; set; }

    [Column("idMiejscaKomentarza")]
    public int IdMiejscaKomentarza { get; set; }

    [ForeignKey("IdAutora")]
    [InverseProperty("Comment")]
    public virtual Player IdAutoraNavigation { get; set; } = null!;

    [ForeignKey("IdMiejscaKomentarza")]
    [InverseProperty("Comment")]
    public virtual MiejsceKomentarza IdMiejscaKomentarzaNavigation { get; set; } = null!;
}
