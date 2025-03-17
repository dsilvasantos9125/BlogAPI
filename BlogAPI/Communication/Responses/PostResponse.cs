using BlogAPI.Models;

namespace BlogAPI.Communication;

public class PostResponse : BaseResponse
{
	public Post Post { get; private set; }

	private PostResponse(bool success, string message, Post post) : base(success, message)
	{
		Post = post;
	}

	public PostResponse(Post post) : this(true, string.Empty, post)
	{ }

	public PostResponse(string message) : this(false, message, null)
	{ }
}
