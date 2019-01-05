/// ***********************************************************************
///
/// =================================
/// CLR版本	：4.0.30319.42000
/// 命名空间	：BlogDemo.Core.Entities
/// 文件名称	：Post.cs
/// =================================
/// 创 建 者	：wyt
/// 创建日期	：2019/1/5 17:57:29 
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

namespace BlogDemo.Core.Entities
{
    /// <summary>
    /// 
    /// <see cref="Post" langword="" />
    /// </summary>
    public class Post:Entity
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public string Author { get; set; }
        public DateTime LastModified { get; set; }

        public string Remark { get; set; }
    }
}
