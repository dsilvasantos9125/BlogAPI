using BlogAPI.Models;
using BlogAPI.Resources;
using BlogAPI.Services;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using BlogAPI.Extensions;
using BlogAPI.Communication;

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
		BlogResponse result = await _blogService.Create(newBlog);

		if (!result.Success)
			return BadRequest(result.Message);

		BlogResource blogResource = _mapper.Map<Blog, BlogResource>(result.Blog);
		return Ok(blogResource);
    }

	[HttpDelete("{id}")]
	public async Task<IActionResult> Delete(Guid id)
	{
		BlogResponse result = await _blogService.Delete(id);

		if (!result.Success)
			return BadRequest(result.Message);

		BlogResource blogResource = _mapper.Map<Blog, BlogResource>(result.Blog);
		return Ok(blogResource);
	}

	[HttpGet]
	public async Task<IActionResult> Get()
	{
		List<Blog> blogsList = await _blogService.GetAll();

		List<BlogGetResource> resultBlogs = _mapper.Map<
			List<Blog>, 
			List<BlogGetResource>>(blogsList);

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

		BlogGetResource resultBlog = _mapper.Map<Blog, BlogGetResource>(currentBlog);
		return Ok(resultBlog);
	}

	[HttpPut("{id}")]
	public async Task<IActionResult> Update(Guid id, [FromBody] BlogResource updateBlogResource)
	{
		if (!ModelState.IsValid)
			return BadRequest(ModelState.GetErrorMessages());	

		Blog updateBlog = _mapper.Map<BlogResource, Blog>(updateBlogResource);
		BlogResponse result = await _blogService.Update(id, updateBlog);

		if (!result.Success)
			BadRequest(result.Message);

		BlogResource blogResource = _mapper.Map<Blog, BlogResource>(result.Blog);
		return Ok(blogResource);
	}
}
