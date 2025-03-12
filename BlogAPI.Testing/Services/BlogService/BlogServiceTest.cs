//using BlogAPI.Data;
//using BlogAPI.Models;
//using BlogAPI.Services;
//using Microsoft.EntityFrameworkCore;
//using Moq;

//namespace BlogAPI.Testing.Services;

//public class BlogServiceTest
//{   
//    private BlogService _context;
//    private Mock<DbSet<Blog>> mockSet;
//    private Mock<BlogContext> mockContext;

//    [SetUp]
//    public void SetUp()
//    {
//        mockSet = new();

//        mockContext = new();
//        mockContext.Setup(m => m.Blogs).Returns(mockSet.Object);

//        _context = new(mockContext.Object);
//    }

//    [Test]
//    public async Task CreateBlog_ShouldAddBlogEqualToDTO()
//    {
//        //Arrange
//        AddBlogDto expectedAddBlogDto = new()
//        {
//            BlogAuthor = "Expected blog author",
//            BlogDescription = "Expected blog description",
//            BlogName = "Expected blog name"
//        };

//        //Act
//        await _context.CreateBlog(expectedAddBlogDto);

//        //Assert
//        mockSet.Verify(m => 
//            m.AddAsync(It.IsAny<Blog>(), It.IsAny<CancellationToken>()),
//            Times.Once());
//        mockContext.Verify(m => 
//            m.SaveChangesAsync(It.IsAny<CancellationToken>()), 
//            Times.Once());
//    }
//}
