using IvanGovnov.Data;
using IvanGovnov.DTOs;
using IvanGovnov.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IvanGovnov.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PostsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/posts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PostDto>>> GetPosts()
        {
            var posts = await _context.Posts
                .Select(p => new PostDto
                {
                    Title = p.Title,
                    Content = p.Content,
                    UserId = p.UserId
                })
                .ToListAsync();

            return Ok(posts);
        }

        // POST: api/posts
        [HttpPost]
        public async Task<ActionResult<PostDto>> CreatePost(PostDto postDto)
        {
            // ѕровер€ем, существует ли пользователь с таким UserId
            var userExists = await _context.Users.AnyAsync(u => u.Id == postDto.UserId);
            if (!userExists)
            {
                return BadRequest("ѕользователь с таким Id не найден");
            }

            var post = new Post
            {
                Title = postDto.Title,
                Content = postDto.Content,
                UserId = postDto.UserId
            };

            _context.Posts.Add(post);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPosts), new { id = post.Id }, postDto);
        }
    }
}
