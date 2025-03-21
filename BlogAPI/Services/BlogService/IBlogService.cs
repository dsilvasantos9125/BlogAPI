﻿using BlogAPI.Models;

namespace BlogAPI.Services;

public interface IBlogService
{
    public Task Create(Blog newBlog);
    public Task Delete(Guid id);
    public Task<Blog> Get(Guid id);
    public Task<List<Blog>> GetAll();
    public Task Update(Guid id, Blog updatedBlog);
}
