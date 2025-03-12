namespace BlogAPI.SharedLibrary
{
    public interface ISharedContext
    {
        public Task AddAsync(object generic);
        public void DeleteAsync(object blog);
        public Task<object> FindAsync(Type keyValues);
        public Task SaveChangesAsync();
    }
}
