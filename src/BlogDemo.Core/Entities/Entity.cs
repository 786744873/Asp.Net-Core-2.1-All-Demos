﻿/// ***********************************************************************
///
/// =================================
/// CLR版本	：4.0.30319.42000
/// 命名空间	：BlogDemo.Core.Entities
/// 文件名称	：Entity.cs
/// =================================
/// 创 建 者	：wyt
/// 创建日期	：2019/1/5 17:56:06 
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
using BlogDemo.Core.Interfaces;

namespace BlogDemo.Core.Entities
{
    /// <summary>
    /// 
    /// <see cref="Entity" langword="" />
    /// </summary>
    public abstract class Entity : IEntity
    {
        public int Id { get; set; }
    }
}
