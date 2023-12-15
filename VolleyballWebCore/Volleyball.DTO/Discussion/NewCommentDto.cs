using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Volleyball.DTO.Discussion
{
    public class NewCommentDto
    {
        [MaxLength(500, ErrorMessage = "Komentarz przekracza limit 500 znaków.")]
        [Required(ErrorMessage = "Komentarz nie może być pusty.")]
        public string Content { get; set; } = null!;

        public int ContentLocationId { get; set; }
    }
}
