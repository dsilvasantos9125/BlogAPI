using BlogAPI.Data;
using BlogAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogAPI.Services;

public class BlogService : IBlogService
{
    private readonly BlogContext _blogContext;

    public BlogService(BlogContext blogContext)
    {
        _blogContext = blogContext;
    }

    public async Task Create(Blog newBlog)
    {
        await _blogContext.Blogs.AddAsync(newBlog);
        await _blogContext.SaveChangesAsync();
    }

	public async Task Delete(Guid id)
	{
		Blog? currentBlog = await Get(id);

		_blogContext.Blogs.Remove(currentBlog);
		await _blogContext.SaveChangesAsync();
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

		await _blogContext.SaveChangesAsync();
    }
}
