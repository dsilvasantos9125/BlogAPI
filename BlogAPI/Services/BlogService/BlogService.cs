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

	public async Task<BlogResponse> Create(Blog newBlog) 
	{
		try
		{
			await _blogRepository.Create(newBlog);
			await _unitOfWork.CompleteAsync();

			return new BlogResponse(newBlog);
		}
		catch (Exception ex)
		{
			return new BlogResponse($"Um erro ocorreu ao salvar o blog: {ex.Message}");
		}
	}

	public async Task<BlogResponse> Delete(Guid id)
	{
		Blog existingBlog = await _blogRepository.Get(id);

		if (existingBlog == null)
			return new BlogResponse("Blog não encontrado.");

		try
		{
			_blogRepository.Delete(existingBlog);
			await _unitOfWork.CompleteAsync();

			return new BlogResponse(existingBlog);
		}
		catch (Exception ex)
		{
			return new BlogResponse($"Um erro ocorreu ao salvar o blog: {ex.Message}");
		}
	}

	public async Task<Blog> Get(Guid id) => 
		await _blogRepository.Get(id);
		
	public async Task<List<Blog>> GetAll() => 
		await _blogRepository.GetAll();

    public async Task<BlogResponse> Update(Guid id, Blog updatedBlog)
	{
		Blog existingBlog = await _blogRepository.Get(id);

		if (existingBlog == null)
			return new BlogResponse("Blog não encontrado.");

		existingBlog.BlogAuthor = updatedBlog.BlogAuthor;
		existingBlog.BlogName = updatedBlog.BlogName;
		existingBlog.BlogDescription = updatedBlog.BlogDescription;

		try
		{
			_blogRepository.Update(existingBlog);
			await _unitOfWork.CompleteAsync();

			return new BlogResponse(existingBlog);
		}
		catch (Exception ex)
		{
			return new BlogResponse($"Um erro ocorreu ao salvar o blog: {ex.Message}");
		}
	}
}
