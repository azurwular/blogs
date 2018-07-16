using System.Collections.Generic;
using System.Threading.Tasks;
using CBA.AP.Blog.Domain.Models;

namespace CBA.AP.Blog.Domain.Repositories
{
    public interface ICommentRepository
    {
        Task<IEnumerable<Comment>> GetAsync(int postId);
        
        Task CreateAsync(Comment comment, int postId);
    }
}