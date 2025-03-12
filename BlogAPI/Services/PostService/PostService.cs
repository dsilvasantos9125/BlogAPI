using BlogAPI.Data;
using BlogAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogAPI.Services;

public class PostService : IPostService
{
    private readonly BlogContext _blogContext;

    public PostService(BlogContext blogContext)
    {
        _blogContext = blogContext;
    }

	public async Task Create(Post newPost)
	{
		newPost.PostDate = DateTime.Now.ToString("f");

		await _blogContext.Posts.AddAsync(newPost);
		await _blogContext.SaveChangesAsync();
	}

	public async Task Delete(Guid id)
	{
		Post? currentPost = await Get(id);

		_blogContext.Remove(currentPost);
		await _blogContext.SaveChangesAsync();
	}

	public async Task<Post> Get(Guid id) => 
		await _blogContext.Posts.FirstOrDefaultAsync(x => x.PostId == id);

	public async Task<List<Post>> GetByBlogId(Guid blogId)
	{
		List<Post> posts = await _blogContext.Posts
			.Include(x => x.Blog)
			.Where(x => x.BlogId == blogId)
			.ToListAsync();

		return posts;
	}

	public async Task Update(Guid id, Post updatedPost)
	{
		Post? selectedPost = await Get(id);

		selectedPost.PostContent = updatedPost.PostContent;
		selectedPost.PostDate = "Editado em: " + DateTime.Now.ToString("f");
		selectedPost.PostName = updatedPost.PostName;

		await _blogContext.SaveChangesAsync();
	}
}

