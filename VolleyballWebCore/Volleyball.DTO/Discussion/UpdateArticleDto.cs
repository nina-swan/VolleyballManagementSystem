using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volleyball.DTO.Teams;

namespace Volleyball.DTO.Discussion
{
    public partial class UpdateArticleDto
    {
        public int Id { get; set; }

        public string Content { get; set; } = null!;

        public string Title { get; set; } = null!;

        public byte[] Image { get; set; } = null!;
    }
}
