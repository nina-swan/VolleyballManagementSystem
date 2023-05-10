using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace VolleyballDomain.Shared.Models;

public partial class Round
{
    [Key]
    [Column("idKolejki")]
    public int RoundId { get; set; }

    [Column("nazwa")]
    [StringLength(255)]
    [Unicode(false)]
    public string Name { get; set; } = null!;

    [Column("idSezonu")]
    public Season Season { get; set; }

    [InverseProperty("IdKolejkiNavigation")]
    public virtual ICollection<Game> Mecz { get; set; } = new List<Game>();
}
