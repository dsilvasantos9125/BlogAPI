
using BlogAPI.Data;

namespace BlogAPI.SharedLibrary
{
    public class SharedContext : ISharedContext
    {
        private readonly BlogContext _blogContext;

        public async Task AddAsync(object generic)
            => await _blogContext.AddAsync(generic);

        public void DeleteAsync(object blog)
            => _blogContext.Remove(blog);

        public async Task<object> FindAsync(Type keyValues)
            => await _blogContext.FindAsync(keyValues);

        public async Task SaveChangesAsync()
            => await _blogContext.SaveChangesAsync();
    }
}
