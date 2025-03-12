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
	
	public async Task Delete(Guid id)
	{
		Blog? currentBlog = await Get(id);

		_blogContext.Blogs.Remove(currentBlog);
	}

	public async Task<Blog> Get(Guid id) =>
		await _blogContext.Blogs.FirstOrDefaultAsync(x => x.BlogId == id);

	public async Task<List<Blog>> GetAll() =>
		await _blogContext.Blogs.ToListAsync();

	public async Task Update(Guid id, Blog updatedBlog)
	{
		Blog? selectedBlog = await Get(id);

		selectedBlog.BlogAuthor = updatedBlog.BlogAuthor;
		selectedBlog.BlogDescription = updatedBlog.BlogDescription;
		selectedBlog.BlogName = updatedBlog.BlogName;
	}
}
