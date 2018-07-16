using System.Collections.Generic;
using System.Threading.Tasks;
using CBA.AP.Blog.Domain.Models;
using CBA.AP.Blog.Domain.Repositories;

namespace CBA.AP.Blog.Infrastructure.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        public Task<IEnumerable<Comment>> GetAsync(int postId)
        {
            throw new System.NotImplementedException();
        }

        public Task CreateAsync(Comment comment, int postId)
        {
            throw new System.NotImplementedException();
        }
    }
}