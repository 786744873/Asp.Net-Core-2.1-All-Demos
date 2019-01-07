/// ***********************************************************************
///
/// =================================
/// CLR版本	：4.0.30319.42000
/// 命名空间	：BlogDemo.Core.Interfaces
/// 文件名称	：IPostRepository.cs
/// =================================
/// 创 建 者	：wyt
/// 创建日期	：2019/1/7 11:14:03 
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
using System.Threading.Tasks;
using BlogDemo.Core.Entities;

namespace BlogDemo.Core.Interfaces
{
    /// <summary>
    /// 
    /// <see cref="IPostRepository" langword="" />
    /// </summary>
    public interface IPostRepository
    {
        Task<IEnumerable<Post>> GetAllPostsAsync();
        void AddPost(Post post);
    }
}
