using BlogAPI.Models;

namespace BlogAPI.Repository;

public interface IBlogRepository
{
	public Task Create(Blog newBlog);
	public void Delete(Blog blog);
	public Task<Blog> Get(Guid id);
	public Task<List<Blog>> GetAll();
	public void Update(Blog updatedBlog);
}
