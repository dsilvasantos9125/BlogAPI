using AutoMapper;
using BlogAPI.Models;
using BlogAPI.Resources;

namespace BlogAPI.Mapping
{
	public class PostMappingProfile : Profile
	{
		public PostMappingProfile()
		{
			CreateMap<Post, PostResource>();
			CreateMap<PostResource, Post>();
			CreateMap<PostUpdateResource, Post>();
		}
	}
}
