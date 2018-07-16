using System.Collections.Generic;
using System.Threading.Tasks;
using CBA.AP.Blog.Domain.Models;

namespace CBA.AP.Blog.Services.Interfaces
{
    public interface IPostService
    {
        Task<IEnumerable<Post>> GetAsync(int count, int page);

        Task CreateAsync(string title, string content);
    }
}