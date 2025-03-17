using BlogAPI.Communication;
using BlogAPI.Models;

namespace BlogAPI.Services;

public interface IPostService
{
	public Task<PostResponse> Create(Post newPost);
	public Task<PostResponse> Delete(Guid id);
	public Task<Post> Get(Guid id);
	public Task<List<Post>> GetByBlogId(Guid blogId);
	public Task<PostResponse> Update(Guid id, Post updatedPost);
}
