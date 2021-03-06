﻿/// ***********************************************************************
///
/// =================================
/// CLR版本	：4.0.30319.42000
/// 命名空间	：BlogDemo.Infrastructure.Database
/// 文件名称	：MyContext.cs
/// =================================
/// 创 建 者	：wyt
/// 创建日期	：2019/1/5 18:06:08 
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
using System.Reflection;
using System.Text;
using BlogDemo.Core.Entities;
using BlogDemo.Core.EntityConfigurations;
using BlogDemo.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BlogDemo.Infrastructure.Database
{
    /// <summary>
    /// 
    /// <see cref="MyContext" langword="" />
    /// </summary>
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options: options)
        { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfiguration(new PostConfiguration());
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(IEntity).Assembly);
        }


        public DbSet<Post> Posts { get; set; }
    }
}
