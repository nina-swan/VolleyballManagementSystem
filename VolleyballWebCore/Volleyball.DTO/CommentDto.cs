using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volleyball.Infrastructure.Database.Models;

namespace Volleyball.DTO
{
    public class CommentDto
    {
        public int Id { get; set; }

        public string Content { get; set; } = null!;

        public DateTime CreationDate { get; set; }

        public AuthorInfoDto Author { get; set; } = null!;

        public static explicit operator CommentDto(Comment comment)
        {
            return new CommentDto
            {
                Id = comment.Id,
                Content = comment.Content,
                CreationDate = comment.CreationDate,
                Author = (AuthorInfoDto)comment.Author,
            };
        }
    }
}
