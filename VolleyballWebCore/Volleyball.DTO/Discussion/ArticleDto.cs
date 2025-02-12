﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volleyball.DTO.Teams;

namespace Volleyball.DTO.Discussion
{
    public partial class ArticleDto
    {
        public int Id { get; set; }

        public string Content { get; set; } = null!;

        public DateTime CreationDate { get; set; }

        public string Title { get; set; } = null!;

        public byte[] Image { get; set; } = null!;

        public virtual AuthorInfoDto Author { get; set; } = null!;

        public static implicit operator ArticleDto(Volleyball.Infrastructure.Database.Models.Article article)
        {
            return new ArticleDto
            {
                Id = article.Id,
                Content = article.Content,
                CreationDate = article.CreationDate,
                Title = article.Title,
                Image = article.Image,
                Author = (AuthorInfoDto)article.Author
            };
        }
    }
}
