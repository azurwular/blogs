using System.Threading.Tasks;
using CBA.AP.Blog.Requests;
using CBA.AP.Blog.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CBA.AP.Blog.Controllers
{
    [Route("api/blog/posts")]
    public class PostsController
    {
        private readonly IPostService postService;
       

        public PostsController(IPostService postService)
        {
            this.postService = postService;
        }

        [HttpGet]
        public async Task<IActionResult> Get(GetPostsRequest request)
        {
            var allPosts = await this.postService.GetAsync(request.Count, request.Page);

            // Serializes and returns the result as json
            return new JsonResult(allPosts);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Post([FromBody] CreatePostRequest request)
        {
            await this.postService.CreateAsync(request.Title, request.Content);
            return new OkResult();
        }
        
    }

    
   


	    // TODO: Update post
        // TODO: Add comment to post
        // TODO: Remove comment from post
        // TODO: Edit comment at post
    }
