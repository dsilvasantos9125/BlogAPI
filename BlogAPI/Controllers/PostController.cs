using AutoMapper;
using BlogAPI.Models;
using BlogAPI.Resources;
using BlogAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace BlogAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PostController : ControllerBase
{
	private readonly IPostService _postService;
	private readonly IMapper _mapper;

	public PostController(IPostService postService, IMapper mapper)
	{
		_postService = postService;
		_mapper = mapper;
	}

	[HttpPost]
	public async Task<IActionResult> Add(PostResource addPostResource)
	{
		Post newPost = _mapper.Map<PostResource, Post>(addPostResource);

		await _postService.Create(newPost);
		return Ok(addPostResource);
	}

	[Route("Get/{id}")]
	[HttpGet]
	public async Task<IActionResult> Get(Guid id)
	{
		Post? selectedPost = await _postService.Get(id);

		if (selectedPost == null)
			return NotFound();

		PostResource resultPost = _mapper.Map<Post, PostResource>(selectedPost);
		return Ok(resultPost);
	}

	[Route("GetByBlogId/{blogId}")]
	[HttpGet]
	public async Task<IActionResult> GetByBlogId(Guid blogId)
	{
		List<Post> posts = await _postService.GetByBlogId(blogId);

		List<PostResource> postsResources = _mapper.Map<
			List<Post>,
			List<PostResource>>(posts);

		return Ok(postsResources);
	}

	[HttpPut("{id}")]
	public async Task<IActionResult> Update(Guid id, PostUpdateResource updatePostResource)
	{
		Post updatedPost = _mapper.Map<PostUpdateResource, Post>(updatePostResource);

		await _postService.Update(id, updatedPost);
		return Ok(updatePostResource);
	}

	[HttpDelete("{id}")]
	public async Task<IActionResult> Delete(Guid id)
	{
		await _postService.Delete(id);
		return Ok();
	}
}
