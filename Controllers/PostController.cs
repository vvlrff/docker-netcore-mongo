using dockerForum.Models;
using dockerForum.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace dockerForum.Controllers
{
    [Authorize]
    [Route("api/post")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostService postService;

        public PostController(IPostService postService)
        {
            this.postService = postService;
        }
        // GET: api/<StudentsController>
        [HttpGet]
        public ActionResult<List<Post>> Get()
        {
            return postService.Get();
        }

        // GET api/<StudentsController>/5
        [HttpGet("{id}")]
        public ActionResult<Post> Get(string id)
        {
            var post = postService.Get(id);

            if (post == null)
            {
                return NotFound($"Post with Id = {id} not found");
            }

            return post;
        }

        // POST api/<StudentsController>
        [HttpPost]
        public ActionResult<Post> Post([FromBody] Post post)
        {
            var currentUser = User; // получаем текущего пользователя
            var userId = currentUser.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;
            post.Owner = userId;

            postService.Create(post);

            return CreatedAtAction(nameof(Get), new { id = post.Id, owner = post.Owner }, post);
        }

        // PUT api/<StudentsController>/5
        [HttpPut("{id}")]
        public ActionResult<Post> Put(string id, [FromBody] Post post)
        {
            var existingPost = postService.Get(id);

            if (existingPost == null)
            {
                return NotFound($"Post with Id = {id} not found");
            }

            postService.Update(id, existingPost);

            return NoContent();
        }

        // DELETE api/<StudentsController>/5
        [HttpDelete("{id}")]
        public ActionResult<Post> Delete(string id)
        {
            var post = postService.Get(id);

            if (post == null)
            {
                return NotFound($"Post with Id = {id} not found");
            }

            postService.Remove(post.Id);

            return Ok($"Post with Id = {id} deleted");
        }
    }
}
