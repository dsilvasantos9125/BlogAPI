using BlogAPI.Models;

namespace BlogAPI.Repositories;

public interface IPostRepository
{
	public Task Create(Post newPost);
	public void Delete(Post post);
	public Task<Post> Get(Guid id);
	public Task<List<Post>> GetByBlogId(Guid blogId);
	public void Update(Post post);
}
