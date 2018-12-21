/// ***********************************************************************
///
/// =================================
/// CLR版本	：4.0.30319.42000
/// 命名空间	：NewsPublish.Model.Response
/// 文件名称	：CommentModel.cs
/// =================================
/// 创 建 者	：wyt
/// 创建日期	：2018/12/21 13:20:30 
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

namespace NewsPublish.Model.Response
{
    /// <summary>
    /// 
    /// <see cref="CommentModel" langword="" />
    /// </summary>
    public class CommentModel
    {
        public int Id { get; set; }
        public string NewsName { get; set; }
        public string Contents { get; set; }
        public DateTime AddTime { get; set; }
        public string Remark { get; set; }
        public string Floor { get; set; }
    }
}
