using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace VolleyballDomain.Shared.Models;

[Table("Log", Schema = "dbo")]
public partial class Log
{
    [Key]
    [Column("idLogu")]
    public int IdLogu { get; set; }

    [Column("link")]
    [StringLength(255)]
    [Unicode(false)]
    public string? Link { get; set; }

    [Column("opis")]
    [StringLength(255)]
    [Unicode(false)]
    public string Opis { get; set; } = null!;

    [Column("data", TypeName = "datetime")]
    public DateTime Data { get; set; }

    [Column("admin")]
    public bool Admin { get; set; }

    [InverseProperty("IdLoguNavigation")]
    public virtual ICollection<PersonalLog> LogPersonalny { get; set; } = new List<PersonalLog>();
}
