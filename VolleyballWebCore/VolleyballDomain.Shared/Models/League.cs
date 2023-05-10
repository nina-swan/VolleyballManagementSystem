using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace VolleyballDomain.Shared.Models;

[Table("League", Schema = "dbo")]
[Index("Name", Name = "IX_Liga", IsUnique = true)]
public partial class League
{
    [Key]
    [Column("idLigi")]
    public int IdLigi { get; set; }

    [Column("nazwa")]
    [StringLength(255)]
    [Unicode(false)]
    public string Nazwa { get; set; } = null!;

    [InverseProperty("IdLigiNavigation")]
    public virtual ICollection<Team> Druzyna { get; set; } = new List<Team>();

    [InverseProperty("IdLigiNavigation")]
    public virtual ICollection<Game> Mecz { get; set; } = new List<Game>();
}
