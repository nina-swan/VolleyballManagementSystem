using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace VolleyballDomain.Shared.Models;

[Table("TeamStats", Schema = "dbo")]
public partial class TeamStats
{
    [Key]
    public int Id { get; set; }

    public int Punkty { get; set; }

    [Column("rozegraneMecze")]
    public int RozegraneMecze { get; set; }

    [Column("wygraneMecze")]
    public int WygraneMecze { get; set; }

    [Column("przegraneMecze")]
    public int PrzegraneMecze { get; set; }

    [Column("wygrane32")]
    public int Wygrane32 { get; set; }

    [Column("przegrane23")]
    public int Przegrane23 { get; set; }

    [Column("miejsceGlobalne")]
    public int MiejsceGlobalne { get; set; }

    public virtual Team Team { get; set; } = null!;
}
