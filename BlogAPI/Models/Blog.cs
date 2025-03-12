namespace BlogAPI.Models;

public class Blog
{
    public Guid BlogId { get; set; }
    public required string BlogAuthor { get; set; }
    public required string BlogDescription { get; set; }
    public required string BlogName { get; set; }

    public List<Post> Posts { get; set; }
}
