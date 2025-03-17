using BlogAPI.Models;

namespace BlogAPI.Communication;

public class BlogResponse : BaseResponse
{
	public Blog Blog { get; private set; }

	private BlogResponse(bool success, string message, Blog blog) : base(success, message)
	{
		Blog = blog;
	}

	public BlogResponse(Blog blog) : this(true, string.Empty, blog)
	{ }

	public BlogResponse(string message) : this(false, message, null)
	{ }
}
