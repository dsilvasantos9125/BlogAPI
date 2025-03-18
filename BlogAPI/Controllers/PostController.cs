using AutoMapper;
using BlogAPI.Communication;
using BlogAPI.Extensions;
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
	public async Task<IActionResult> Add([FromBody] PostResource addPostResource)
	{
		if (!ModelState.IsValid)
			return BadRequest(ModelState.GetErrorMessages());

		Post newPost = _mapper.Map<PostResource, Post>(addPostResource);
		PostResponse result = await _postService.Create(newPost);

		if (!result.Success)
			return BadRequest(result.Message);

		PostResource postResource = _mapper.Map<Post, PostResource>(result.Post);
		return Ok(postResource);
	}

	[HttpDelete("{id}")]
	public async Task<IActionResult> Delete(Guid id)
	{
		PostResponse result = await _postService.Delete(id);

		if (!result.Success)
			return BadRequest(result.Message);
		
		PostResource postResource = _mapper.Map<Post, PostResource>(result.Post);
		return Ok(postResource);
	}

	[Route("Get/{id}")]
	[HttpGet]
	public async Task<IActionResult> Get(Guid id)
	{
		Post? selectedPost = await _postService.Get(id);

		if (selectedPost == null)
			return NotFound();

		PostGetResource postResource = _mapper.Map<Post, PostGetResource>(selectedPost);
		return Ok(postResource);
	}

	[Route("GetByBlogId/{blogId}")]
	[HttpGet]
	public async Task<IActionResult> GetByBlogId(Guid blogId)
	{
		List<Post> posts = await _postService.GetByBlogId(blogId);

		List<PostGetResource> postsResources = _mapper.Map<
			List<Post>,
			List<PostGetResource>>(posts);

		return Ok(postsResources);
	}

	[HttpPut("{id}")]
	public async Task<IActionResult> Update(Guid id, [FromBody] PostGetResource updatePostResource)
	{
		if (!ModelState.IsValid)
			return BadRequest(ModelState.GetErrorMessages());

		Post updatedPost = _mapper.Map<PostGetResource, Post>(updatePostResource);
		PostResponse result = await _postService.Update(id, updatedPost);

		if (!result.Success)
			return BadRequest(result.Message);

		PostGetResource postResource = _mapper.Map<Post, PostGetResource>(result.Post);
		return Ok(postResource);
	}
}
