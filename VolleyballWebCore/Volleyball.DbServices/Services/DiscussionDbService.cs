using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volleyball.DTO.Discussion;
using Volleyball.Infrastructure.Database.Models;
using VolleyballDomain.Shared;

namespace Volleyball.DbServices.Services
{
    public class DiscussionDbService
    {
        private readonly VolleyballContext context;

        public DiscussionDbService() { }

        public DiscussionDbService(VolleyballContext context)
        {
            this.context = context;
        }

        public async Task<ServiceResponse<List<CommentDto>>> GetComments(int locationId, CommentLocation location)
        {

        }

        public async Task<ServiceResponse> AddComment(NewCommentDto comment, string authorEmail)
        {

        }
    }
}
