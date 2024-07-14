using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RoutingDemo.Models;
using RoutingDemo.Services;

namespace RoutingDemo.Controllers
{
    [Route("api/[controller]")]
    // [Route("api/some-posts-whatever")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IPostService _postsService;

        public PostsController(IPostService postService)
        {
            _postsService = postService;
        }

        // id must be integer and in range 1-100
        // else return 404 Not Found 
        [HttpGet("{id:int:range(1,100)}")]
        public async Task<ActionResult<Post>> GetPost(int id)
        {
            var post = await _postsService.GetPost(id);
            if (post == null)
            {
                return NotFound();
            }
            return Ok(post);
        }

        [HttpPost]
        public async Task<ActionResult<Post>> CreatePost(Post post)
        {
            await _postsService.CreatePost(post);
            return CreatedAtAction(nameof(GetPost), new {id = post.Id}, post);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdatePost(int id, Post post)
        {
            if (id != post.Id)
            {
                return BadRequest();
            }
            var updatedPost = await _postsService.UpdatePost(id, post);
            if (updatedPost == null)
            {
                return NotFound();
            }
            return Ok(post);
        }
        [HttpGet]
        // pageIndex and pageQuery get from URL query
        public async Task<ActionResult<List<Post>>> GetPosts([FromQuery] int pageIndex, [FromQuery] int pageSize)
        {
            var posts = await _postsService.GetAllPosts();
            return Ok(posts);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePost(int id)
        {
            await _postsService.DeletePost(id);
            return Ok();
        }
    }
}
