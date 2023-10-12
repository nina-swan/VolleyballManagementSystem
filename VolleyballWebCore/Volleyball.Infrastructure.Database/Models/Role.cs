namespace Volleyball.Infrastructure.Database.Models
{
    public class Role
    {
        public int RoleId { get; set; }

        public string Name { get; set; } = null!;

        public List<Credentials> Credentials { get; set; } = null!;
    }
}