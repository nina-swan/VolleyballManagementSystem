using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Volleyball.DTO
{
    public partial class ArticleDto
    {
        public int Id { get; set; }

        public string Content { get; set; } = null!;

        public DateTime CreationDate { get; set; }

        public string Title { get; set; } = null!;

        public bool? IsActive { get; set; }

        public byte[] Image { get; set; } = null!;

        public virtual User Author { get; set; } = null!;
    }
}
