using BlogAPI.Models;

namespace BlogAPI.Services;

public interface IPostService
{
	public Task Create(Post newPost);
	public Task Delete(Guid id);
	public Task<Post> Get(Guid id);
	public Task<List<Post>> GetByBlogId(Guid blogId);
	public Task Update(Guid id, Post updatedPost);
}
