using BlogAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogAPI.Data;

public class BlogContext : DbContext
{
	public BlogContext(DbContextOptions options) : base(options) { }

	public BlogContext() { }

	public virtual DbSet<Blog> Blogs { get; set; }
	public virtual DbSet<Post> Posts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
		modelBuilder.Entity<Blog>().ToTable("Blog");
        modelBuilder.Entity<Post>().ToTable("Post");
    }
}
