/// ***********************************************************************
///
/// =================================
/// CLR版本	：4.0.30319.42000
/// 命名空间	：BlogDemo.Infrastructure.Resources
/// 文件名称	：PostPropertyMapping.cs
/// =================================
/// 创 建 者	：wyt
/// 创建日期	：2019/1/9 16:56:10 
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
using System.Text;
using BlogDemo.Core.Entities;
using BlogDemo.Infrastructure.Services;

namespace BlogDemo.Infrastructure.Resources
{
    /// <summary>
    /// 
    /// </summary>
    public class PostPropertyMapping:PropertyMapping<PostResource, Post>
    {
        public PostPropertyMapping():base(new Dictionary<string, List<MappedProperty>>(StringComparer.OrdinalIgnoreCase)
        {
            [nameof(PostResource.Title)] = new List<MappedProperty>
            {
                new MappedProperty{ Name = nameof(Post.Title), Revert = false}
            },
            [nameof(PostResource.Body)] = new List<MappedProperty>
            {
                new MappedProperty{ Name = nameof(Post.Body), Revert = false}
            },
            [nameof(PostResource.Author)] = new List<MappedProperty>
            {
                new MappedProperty{ Name = nameof(Post.Author), Revert = false}
            }
        })
        {
            
        }
    }
}
