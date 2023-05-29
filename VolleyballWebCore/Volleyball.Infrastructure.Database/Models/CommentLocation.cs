using System;
using System.Collections.Generic;

namespace Volleyball.Infrastructure.Database.Models
{
    public partial class CommentLocation
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();
    }
}
