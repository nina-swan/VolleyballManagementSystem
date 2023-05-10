using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace VolleyballDomain.Shared.Models;

[Table("Team", Schema = "dbo")]
public partial class Team
{
    [Key]
    public int Id { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string Name { get; set; } = null!;

    public DateTime DateCreated { get; set; }

    public byte[]? Image { get; set; }

    public League League { get; set; }

    public bool Zaakceptowana { get; set; }

    public string Email { get; set; } = null!;

    public bool? SignedUp { get; set; }

    public int Transfers { get; set; }

    public byte[]? Logo { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string PhoneNumber { get; set; } = null!;

    [StringLength(5000)]
    [Unicode(false)]
    public string? Description { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string? PageAddress { get; set; }

    [Column("korekcjaPunktow")]
    public int? KorekcjaPunktow { get; set; }

    public virtual Player Captain { get; set; } = null!;

    public ICollection<Player> Players { get; set; } = null!;

    public virtual ICollection<Game> GamesTeam1 { get; set; } = new List<Game>();

    public virtual ICollection<Game> GamesTeam2 { get; set; } = new List<Game>();

    public virtual TeamStats? TeamStats { get; set; }

    public virtual ICollection<Invitation> Invitations { get; set; } = new List<Invitation>();
}
