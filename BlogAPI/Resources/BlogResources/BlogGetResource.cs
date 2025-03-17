namespace BlogAPI.Resources;

public class BlogGetResource
{
	public required string BlogAuthor { get; set; }
	public required string BlogDescription { get; set; }
	public required string BlogName { get; set; }
	public List<PostGetResource> Posts { get; set; }
}
