using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace VolleyballDomain.Shared.Models;

[Table("Player", Schema = "dbo")]
public partial class Player
{
    [Key]
    [Column("idUzytkownika")]
    public int PlayerId { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string Name { get; set; } = null!;

    [StringLength(255)]
    [Unicode(false)]
    public string Surname { get; set; } = null!;


    public int? BirthYear { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string? City { get; set; }

    [StringLength(3000)]
    [Unicode(false)]
    public string? Description { get; set; }

    public byte[]? Image { get; set; }

    public bool Sex { get; set; }

    public int? Height { get; set; }

    public int? Weight { get; set; }

    public int? PlayerNumber { get; set; }

    public int? BlockRange { get; set; }

    public int? AttackRange { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string? VolleyballIdol { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string? Email { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string? Hobby { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string? PhoneNumber { get; set; }

    public Pozycja Position { get; set; }

    public virtual ICollection<Artykul> Articles { get; set; } = new List<Artykul>();

    public virtual Team? TeamOwner { get; set; }

    public virtual ICollection<Team> TeamsPlayer { get; set; } = new List<Team>();

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual ICollection<PersonalLog> PersonalLogs { get; set; } = new List<PersonalLog>();

    public virtual ICollection<Game> GamesMVP { get; set; } = new List<Game>();

    public virtual ICollection<Game> GamesUmpire { get; set; } = new List<Game>();

    public virtual ICollection<Temat> Topics { get; set; } = new List<Temat>();

    public virtual ICollection<WynikTypowany> BetScore { get; set; } = new List<WynikTypowany>();

    [InverseProperty("IdZawodnikaNavigation")]
    public virtual ICollection<Invitation> Invites { get; set; } = new List<Invitation>();
}
