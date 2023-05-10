using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace VolleyballDomain.Shared.Models;

[Table("Pozycja", Schema = "dbo")]
public partial class Pozycja
{
    [Key]
    [Column("idPozycji")]
    public int IdPozycji { get; set; }

    [Column("nazwa")]
    [StringLength(255)]
    [Unicode(false)]
    public string Nazwa { get; set; } = null!;

    [InverseProperty("IdPozycjiNavigation")]
    public virtual ICollection<Player> Uzytkownik { get; set; } = new List<Player>();
}
