using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using WebApplication1.DTO;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PostsController : Controller
    {
        private IPostsService _postService;
        public PostsController([FromKeyedServices("PostsService")] IPostsService postsService) 
        {
            _postService = postsService;
        }
        [HttpGet("all")]
        public async Task<IEnumerable<PostDTO>> GetAll() =>
         await _postService.Get();
        
    }
}
