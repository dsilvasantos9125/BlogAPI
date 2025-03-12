namespace BlogAPI.Resources;

public class PostResource
{
	public required Guid BlogId { get; set; }
	public required string PostContent { get; set; }
	public required string PostName { get; set; }
}
