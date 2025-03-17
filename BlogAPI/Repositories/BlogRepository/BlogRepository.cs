using BlogAPI.Data;
using BlogAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogAPI.Repository;

public class BlogRepository : IBlogRepository
{
	private readonly BlogContext _blogContext;

	public BlogRepository(BlogContext blogContext)
	{
		_blogContext = blogContext;
	}

	public async Task Create(Blog newBlog) =>
		await _blogContext.AddAsync(newBlog);

	public void Delete(Blog blog) =>
		_blogContext.Blogs.Remove(blog);

	public async Task<Blog> Get(Guid id)
	{
		Blog blog = await _blogContext.Blogs
			.Include(blog => blog.Posts)
			.FirstOrDefaultAsync(x => x.BlogId == id);

		return blog;
	}

	public async Task<List<Blog>> GetAll()
	{
		List<Blog> blogs = await _blogContext.Blogs
			.Include(
			blog => blog.Posts
			.OrderBy(post => post.PostName))
			.ToListAsync();

		return blogs;
	}

	public void Update(Blog updatedBlog) =>
		_blogContext.Update(updatedBlog);

}
