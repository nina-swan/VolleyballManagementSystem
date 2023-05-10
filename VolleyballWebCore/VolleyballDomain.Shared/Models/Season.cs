using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace VolleyballDomain.Shared.Models;

[Table("Season", Schema = "dbo")]
public partial class Season
{
    [Key]
    public int IdSezonu { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string Name { get; set; } = null!;

    [InverseProperty("IdSezonuNavigation")]
    public virtual ICollection<Round> Rounds { get; set; } = new List<Round>();
}
