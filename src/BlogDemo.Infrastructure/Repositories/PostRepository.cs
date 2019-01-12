/// ***********************************************************************
///
/// =================================
/// CLR版本	：4.0.30319.42000
/// 命名空间	：BlogDemo.Infrastructure.Repositories
/// 文件名称	：PostRepository.cs
/// =================================
/// 创 建 者	：wyt
/// 创建日期	：2019/1/7 11:15:27 
/// 邮箱		：786744873@qq.com
/// 个人主站	：https://www.cnblogs.com/wyt007/
///
/// 功能描述	：
/// 使用说明	：
/// =================================
/// 修改者	：
/// 修改日期	：
/// 修改内容	：
/// =================================
///
/// ***********************************************************************


using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;
using BlogDemo.Core.Entities;
using BlogDemo.Core.Interfaces;
using BlogDemo.Infrastructure.Database;
using BlogDemo.Infrastructure.Extensions;
using BlogDemo.Infrastructure.Resources;
using BlogDemo.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;

namespace BlogDemo.Infrastructure.Repositories
{
    /// <summary>
    /// 
    /// <see cref="PostRepository" langword="" />
    /// </summary>
    public class PostRepository : IPostRepository
    {
        private readonly MyContext _myContext;
        private readonly IPropertyMappingContainer _propertyMappingContainer;

        public PostRepository(MyContext myContext, IPropertyMappingContainer propertyMappingContainer)
        {
            _myContext = myContext;
            _propertyMappingContainer = propertyMappingContainer;
        }

        public async Task<PaginatedList<Post>> GetAllPostsAsync(PostParameters postParameters)
        {
            var query = _myContext.Posts.AsQueryable();

            if (!string.IsNullOrEmpty(postParameters.Title))
            {
                var title = postParameters.Title.ToLowerInvariant();
                query = query.Where(x => x.Title.ToLowerInvariant()==title );
            }

            //query = query.OrderBy(x => x.Id);

            query = query.ApplySort(postParameters.OrderBy, _propertyMappingContainer.Resolve<PostResource, Post>());

            query = query.OrderBy(postParameters.OrderBy);

            var count = await query.CountAsync();

            var data= await query
                .Skip(postParameters.PageIndex * postParameters.PageSize)
                .Take(postParameters.PageSize)
                .ToListAsync();

            return new PaginatedList<Post>(postParameters.PageIndex,postParameters.PageSize,count,data);
        }

        public async Task<Post> GetPostByIdAsync(int id)
        {
            return await _myContext.Posts.FindAsync(id);
        }

        public void AddPost(Post post)
        {
            _myContext.Posts.Add(post);
        }

        public void Delete(Post post)
        {
            _myContext.Posts.Remove(post);
        }

        public void Update(Post post)
        {
            _myContext.Entry(post).State = EntityState.Modified;
        }
    }
}
