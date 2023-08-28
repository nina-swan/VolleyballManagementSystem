using System;
using System.Collections.Generic;

namespace Volleyball.Infrastructure.Database.Models
{
    public partial class ForumCategory
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public virtual ICollection<ForumTopic> Topics { get; set; } = new List<ForumTopic>();
    }
}
