﻿/// ***********************************************************************
///
/// =================================
/// CLR版本	：4.0.30319.42000
/// 命名空间	：BlogDemo.Infrastructure.Services
/// 文件名称	：ITypeHelperService.cs
/// =================================
/// 创 建 者	：wyt
/// 创建日期	：2019/1/10 10:24:36 
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

namespace BlogDemo.Infrastructure.Services
{
    /// <summary>
    /// 
    /// </summary>
    public interface ITypeHelperService
    {
        bool TypeHasProperties<T>(string fields);
    }
}
