using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace VolleyballDomain.Shared.Models;

[Table("Kategoria", Schema = "dbo")]
public partial class Kategoria
{
    [Key]
    [Column("idKategorii")]
    public int IdKategorii { get; set; }

    [Column("nazwa")]
    [StringLength(255)]
    [Unicode(false)]
    public string Nazwa { get; set; } = null!;

    [InverseProperty("IdKategoriiNavigation")]
    public virtual ICollection<Temat> Temat { get; set; } = new List<Temat>();
}
