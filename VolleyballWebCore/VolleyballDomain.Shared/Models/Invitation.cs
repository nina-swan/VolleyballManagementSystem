using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace VolleyballDomain.Shared.Models;

[Table("Invites", Schema = "dbo")]
public partial class Invitation
{
    [Key]
    [Column("idZaproszenia")]
    public int IdZaproszenia { get; set; }

    [Column("idZawodnika")]
    public int IdZawodnika { get; set; }


    [Column("dataUtworzenia", TypeName = "datetime")]
    public DateTime DataUtworzenia { get; set; }

    public virtual Team Team { get; set; } = null!;

    [ForeignKey("IdZawodnika")]
    [InverseProperty("Invites")]
    public virtual Player IdZawodnikaNavigation { get; set; } = null!;
}
