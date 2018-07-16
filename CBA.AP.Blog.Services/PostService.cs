using System.Collections.Generic;
using System.Threading.Tasks;
using CBA.AP.Blog.Domain.Models;
using CBA.AP.Blog.Domain.Repositories;
using CBA.AP.Blog.Services.Interfaces;

namespace CBA.AP.Blog.Services
{
    public class PostService : IPostService
    {
        private readonly IPostRepository postRepository;

        public PostService(IPostRepository blogRepository)
        {
            this.postRepository = blogRepository;
        }

        public async Task<IEnumerable<Post>> GetAsync(int count, int page)
        {
            return await this.postRepository.GetAsync(count, page);
        }

        public async Task CreateAsync(string title, string content)
        {
            var newPost = new Post();

            newPost.Title = title;
            newPost.Content = content;

            await this.postRepository.CreateAsync(newPost);
        }
    }
}