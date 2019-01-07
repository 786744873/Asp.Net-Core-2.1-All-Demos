/// ***********************************************************************
///
/// =================================
/// CLR版本	：4.0.30319.42000
/// 命名空间	：BlogDemo.Core.EntityConfigurations
/// 文件名称	：PostConfiguration.cs
/// =================================
/// 创 建 者	：wyt
/// 创建日期	：2019/1/7 11:59:10 
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
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogDemo.Core.EntityConfigurations
{
    /// <summary>
    /// 
    /// <see cref="PostConfiguration" langword="" />
    /// </summary>
    public class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.Property(x => x.Author).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Title).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Body).IsRequired().HasColumnType("nvarchar(max)");
            builder.Property(x => x.Body).IsRequired().HasMaxLength(200);
        }
    }
}
