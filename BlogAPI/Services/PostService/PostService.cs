using BlogAPI.Communication;
using BlogAPI.Data;
using BlogAPI.Models;
using BlogAPI.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BlogAPI.Services;

public class PostService : IPostService
{
    private readonly IPostRepository _postRepository;
	private readonly IUnitOfWork _unitOfWork;

	public PostService(IPostRepository postRepository, IUnitOfWork unitOfWork)
	{
		_postRepository = postRepository;
		_unitOfWork = unitOfWork;
	}

	public async Task<PostResponse> Create(Post newPost)
	{
		try
		{
			await _postRepository.Create(newPost);
			await _unitOfWork.CompleteAsync();

			return new PostResponse(newPost);
		}
		catch (Exception ex)
		{
			return new PostResponse($"$\"Um erro ocorreu ao salvar o post: {ex.Message}");
		}
	}

	public async Task<PostResponse> Delete(Guid id)
	{
		Post existingPost = await _postRepository.Get(id);

		if (existingPost == null)
			return new PostResponse("Post não encontrado.");

		try
		{
			_postRepository.Delete(existingPost);
			await _unitOfWork.CompleteAsync();

			return new PostResponse(existingPost);
		}
		catch (Exception ex)
		{
			return new PostResponse($"Um erro ocorreu ao salvar o post: {ex.Message}");
		}
	}

	public async Task<Post> Get(Guid id) =>
		await _postRepository.Get(id);

	public async Task<List<Post>> GetByBlogId(Guid blogId) =>
		await _postRepository.GetByBlogId(blogId);

	public async Task<PostResponse> Update(Guid id, Post updatedPost)
	{
		Post existingPost = await _postRepository.Get(id);

		if (existingPost == null) 
			return new PostResponse("Post não encontrado.");

		updatedPost.PostName = existingPost.PostName;
		updatedPost.PostContent = existingPost.PostContent;
		updatedPost.PostDate = DateTime.Now.ToString("Editado em: f");

		try
		{
			_postRepository.Update(existingPost);
		}
		catch (Exception ex)
		{
			throw;
		}
	}
}

