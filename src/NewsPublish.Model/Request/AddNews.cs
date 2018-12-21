/// ***********************************************************************
///
/// =================================
/// CLR版本	：4.0.30319.42000
/// 命名空间	：NewsPublish.Model.Request
/// 文件名称	：AddNews.cs
/// =================================
/// 创 建 者	：wyt
/// 创建日期	：2018/12/21 11:22:20 
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

namespace NewsPublish.Model.Request
{
    /// <summary>
    /// 
    /// <see cref="AddNews" langword="" />
    /// </summary>
    public class AddNews
    {
        public int NewsClassifyId { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public string Contents { get; set; }
        public string Remark { get; set; }
    }
}
