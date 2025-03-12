namespace BlogAPI.Models;

public class Post
{
    public Guid PostId { get; set; }
    public required Guid BlogId { get; set; }
    public required string PostContent { get; set; }
    public string PostDate { get; set; }
    public required string PostName { get; set; }

    public Blog Blog { get; set; }
}
