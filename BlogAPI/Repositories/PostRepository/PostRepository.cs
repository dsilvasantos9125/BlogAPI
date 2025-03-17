using BlogAPI.Data;
using BlogAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogAPI.Repositories.PostRepository;

public class PostRepository : IPostRepository
{
	private readonly BlogContext _blogContext;

	public PostRepository(BlogContext blogContext)
	{
		_blogContext = blogContext;
	}

	public async Task Create(Post newPost)
	{
		newPost.PostDate = DateTime.Now.ToString("f");

		await _blogContext.Posts.AddAsync(newPost);
	}

	public void Delete(Post post) =>
		_blogContext.Remove(post);
	
	public async Task<Post> Get(Guid id)
	{
		Post post = await _blogContext.Posts
		.Include(post => post.Blog)
		.FirstOrDefaultAsync(post => post.PostId == id);

		return post;
	}

	public async Task<List<Post>> GetByBlogId(Guid blogId)
	{
		List<Post> posts = await _blogContext.Posts
		.Include(x => x.Blog)
		.Where(x => x.BlogId == blogId)
		.ToListAsync();

		return posts;
	}

	public void Update(Post post) =>
		_blogContext.Update(post);
}
