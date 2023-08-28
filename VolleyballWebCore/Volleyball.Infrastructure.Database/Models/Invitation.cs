using Volleyball.Infrastructure.Database.Models;

public partial class Invitation
{
    public int Id { get; set; }
    public int UserId { get; set; }

    public int TeamId { get; set; }

    public DateTime CreationDate { get; set; }

    public virtual Team Team { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}