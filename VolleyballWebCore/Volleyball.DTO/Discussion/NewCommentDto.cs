using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Volleyball.DTO.Discussion
{
    public class NewCommentDto
    {
        public string Content { get; set; } = null!;
        public int CommentLocation { get; set; }
    }
}
