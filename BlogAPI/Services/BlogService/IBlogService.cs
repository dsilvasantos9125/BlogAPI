using BlogAPI.Communication;
using BlogAPI.Models;

namespace BlogAPI.Services;

public interface IBlogService
{
    public Task<BlogResponse> Create(Blog newBlog);
    public Task<BlogResponse> Delete(Guid id);
    public Task<Blog> Get(Guid id);
    public Task<List<Blog>> GetAll();
    public Task<BlogResponse> Update(Guid id, Blog updatedBlog);
}
