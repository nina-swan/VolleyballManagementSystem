using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volleyball.DTO.Teams;

namespace Volleyball.DTO.Discussion
{
    public partial class NewArticleDto
    {
        public string Content { get; set; } = null!;

        public string Title { get; set; } = null!;

        public byte[] Image { get; set; } = null!;

        public static implicit operator NewArticleDto(Volleyball.Infrastructure.Database.Models.Article article)
        {
            return new NewArticleDto
            {
                Content = article.Content,
                Title = article.Title,
                Image = article.Image,
            };
        }
    }
}
