using BlogAPI.Models;
using BlogAPI.Resources;
using BlogAPI.Services;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using BlogAPI.Extensions;

namespace BlogAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BlogController : ControllerBase
{
    private readonly IBlogService _blogService;
	private readonly IMapper _mapper;

	public BlogController(IBlogService blogService, IMapper mapper)
	{
		_blogService = blogService;
		_mapper = mapper;
	}

	[HttpPost]
    public async Task<IActionResult> Add([FromBody] BlogResource addBlogResource)
    {
		if (!ModelState.IsValid)
			return BadRequest(ModelState.GetErrorMessages());

		Blog newBlog = _mapper.Map<BlogResource, Blog>(addBlogResource);

	    await _blogService.Create(newBlog);
	    return Ok(addBlogResource);
    }

	[HttpDelete("{id}")]
	public async Task<IActionResult> Delete(Guid id)
	{
		await _blogService.Delete(id);
		return Ok();
	}

	[HttpGet]
	public async Task<IActionResult> Get()
	{
		List<Blog> blogsList = await _blogService.GetAll();

		List<BlogResource> resultBlogs = _mapper.Map<List<Blog>, List<BlogResource>>(blogsList);
		return Ok(resultBlogs);
	}

	[HttpGet("{id}")]
	public async Task<IActionResult> Get(Guid id)
	{
		Blog? currentBlog = await _blogService.Get(id);

		if (currentBlog == null)
		{
			return NotFound();
		}

		BlogResource resultBlog = _mapper.Map<Blog, BlogResource>(currentBlog);

		return Ok(resultBlog);
	}

	[HttpPut("{id}")]
	public async Task<IActionResult> Update(Guid id, BlogResource updateBlogResource)
	{
		Blog updateBlog = _mapper.Map<BlogResource, Blog>(updateBlogResource);

		await _blogService.Update(id, updateBlog);
		return Ok(updateBlogResource);
	}
}
