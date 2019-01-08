/// ***********************************************************************
///
/// =================================
/// CLR版本	：4.0.30319.42000
/// 命名空间	：BlogDemo.Infrastructure.Resources
/// 文件名称	：PostResource.cs
/// =================================
/// 创 建 者	：wyt
/// 创建日期	：2019/1/8 16:47:30 
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

namespace BlogDemo.Infrastructure.Resources
{
    /// <summary>
    /// 
    /// <see cref="PostResource" langword="" />
    /// </summary>
    public class PostResource
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public string Author { get; set; }
        public DateTime UpdateTime { get; set; }

        public string Remark { get; set; }
    }
}
