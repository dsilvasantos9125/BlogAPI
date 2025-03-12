using BlogAPI.Communication;
using BlogAPI.Models;
using BlogAPI.Repositories;
using BlogAPI.Repository;

namespace BlogAPI.Services;

public class BlogService : IBlogService
{
    private readonly IBlogRepository _blogRepository;
	private readonly IUnitOfWork _unitOfWork;

	public BlogService(IBlogRepository blogRepository, IUnitOfWork unitOfWork)
	{
		_blogRepository = blogRepository;
		_unitOfWork = unitOfWork;
	}

	public async Task<AddBlogResponse> Create(Blog newBlog) 
	{
		try
		{
			await _blogRepository.Create(newBlog);
			await _unitOfWork.CompleteAsync();

			return new AddBlogResponse(newBlog);
		}
		catch (Exception ex)
		{
			return new AddBlogResponse($"Um erro ocorreu ao salvar a categoria: {ex.Message}");
		}
	}

	public async Task Delete(Guid id) =>
		await _blogRepository.Delete(id);

	public async Task<Blog> Get(Guid id) => 
		await _blogRepository.Get(id);
		
	public async Task<List<Blog>> GetAll() => 
		await _blogRepository.GetAll();

    public async Task Update(Guid id, Blog updatedBlog) =>
		await _blogRepository.Update(id, updatedBlog);
}
