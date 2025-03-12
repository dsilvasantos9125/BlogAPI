
using BlogAPI.Data;

namespace BlogAPI.Repositories;

public class UnitOfWork : IUnitOfWork
{
	private readonly BlogContext _blogContext;

	public UnitOfWork(BlogContext blogContext)
	{
		_blogContext = blogContext;
	}

	public async Task CompleteAsync() =>
		await _blogContext.SaveChangesAsync();
}
