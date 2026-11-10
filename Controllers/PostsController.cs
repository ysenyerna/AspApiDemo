using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class PostsController : ControllerBase
{
	private static readonly List<Post> Posts = [];
	private static int _nextId = 1;

	// Get all posts
	[HttpGet]
	public ActionResult<IEnumerable<Post>> GetAll()
	{
		return Ok(Posts.ToList());
	}

	// Create a new post
	[HttpPost]
	public ActionResult<Post> Create(Post post)
	{
		if (!ModelState.IsValid)
		{
			return ValidationProblem(ModelState);
		}
		
		post.Id = _nextId++;
		Posts.Add(post);

		return Created("/api/posts", post);
	}
}
