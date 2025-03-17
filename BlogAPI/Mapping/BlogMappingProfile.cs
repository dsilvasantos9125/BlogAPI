using AutoMapper;
using BlogAPI.Models;
using BlogAPI.Resources;

namespace BlogAPI.Mapping;

public class BlogMappingProfile : Profile
{
	public BlogMappingProfile()
	{
		CreateMap<Blog, BlogResource>();
		CreateMap<BlogResource, Blog>();
		CreateMap<Blog, BlogGetResource>();
	}
}
