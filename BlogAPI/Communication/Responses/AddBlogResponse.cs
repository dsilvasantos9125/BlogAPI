using BlogAPI.Models;

namespace BlogAPI.Communication;

public class AddBlogResponse : BaseResponse
{
	public Blog Blog { get; private set; }

	private AddBlogResponse(bool success, string message, Blog blog) : base(success, message)
	{
		Blog = blog;
	}

	public AddBlogResponse(Blog blog) : this(true, string.Empty, blog)
	{ }

	public AddBlogResponse(string message) : this(false, message, null)
	{ }
}
