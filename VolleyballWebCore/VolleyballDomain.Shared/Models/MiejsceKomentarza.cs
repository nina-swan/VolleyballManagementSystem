using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace VolleyballDomain.Shared.Models;

[Table("MiejsceKomentarza", Schema = "dbo")]
public partial class MiejsceKomentarza
{
    [Key]
    [Column("idMiejscaKomentarza")]
    public int IdMiejscaKomentarza { get; set; }

    [Column("nazwa")]
    [StringLength(50)]
    [Unicode(false)]
    public string Nazwa { get; set; } = null!;

    [InverseProperty("IdMiejscaKomentarzaNavigation")]
    public virtual ICollection<Comment> Komentarz { get; set; } = new List<Comment>();
}
