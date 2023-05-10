using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace VolleyballDomain.Shared.Models;

[Table("PersonalLog", Schema = "dbo")]
public partial class PersonalLog
{
    [Key]
    [Column("idPersonLogu")]
    public int IdPersonLogu { get; set; }

    [Column("idUzytkownika")]
    public int IdUzytkownika { get; set; }

    [Column("idLogu")]
    public int IdLogu { get; set; }

    [ForeignKey("IdLogu")]
    [InverseProperty("PersonalLog")]
    public virtual Log IdLoguNavigation { get; set; } = null!;

    [ForeignKey("PlayerId")]
    [InverseProperty("PersonalLog")]
    public virtual Player IdUzytkownikaNavigation { get; set; } = null!;
}
