using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BlogDemo.Core.Entities;
using BlogDemo.Infrastructure.Resources;

namespace BlogDemo.Api.Extensions
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Post, PostResource>().ForMember(dest=>dest.UpdateTime,opt=>opt.MapFrom(src=>src.LastModified)).ReverseMap();
            //CreateMap<PostResource, Post>().ForMember(desc => desc.LastModified, opt => opt.MapFrom(s => s.UpdateTime));

            CreateMap<PostResource, Post>().ReverseMap();
            CreateMap<PostAddResource, Post>().ReverseMap();
            CreateMap<PostUpdateResource, Post>().ReverseMap();
        }
    }
}
