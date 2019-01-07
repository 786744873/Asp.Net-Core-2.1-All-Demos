/// ***********************************************************************
///
/// =================================
/// CLR版本	：4.0.30319.42000
/// 命名空间	：BlogDemo.Infrastructure.Database
/// 文件名称	：UnitOfWork.cs
/// =================================
/// 创 建 者	：wyt
/// 创建日期	：2019/1/7 11:27:11 
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
using BlogDemo.Core.Interfaces;

namespace BlogDemo.Infrastructure.Database
{
    /// <summary>
    /// 
    /// <see cref="UnitOfWork" langword="" />
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MyContext _myContext;

        public UnitOfWork(MyContext myContext)
        {
            _myContext = myContext;
        }

        public async Task<bool> SaveAsync()
        {
            return await _myContext.SaveChangesAsync() > 0;
        }
    }
}
