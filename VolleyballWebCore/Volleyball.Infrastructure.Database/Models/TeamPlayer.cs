using Volleyball.Infrastructure.Database.Models;

public partial class TeamPlayer
{
    public int Id { get; set; }
    public int TeamId { get; set; }

    public int PlayerId { get; set; }

    public DateTime JoinDate { get; set; }

    public virtual Team Team { get; set; } = null!;

    public virtual User Player { get; set; } = null!;
}