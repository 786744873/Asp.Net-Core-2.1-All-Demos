/// ***********************************************************************
///
/// =================================
/// CLR版本	：4.0.30319.42000
/// 命名空间	：BlogDemo.Infrastructure.Resources
/// 文件名称	：PostResourceValidator.cs
/// =================================
/// 创 建 者	：wyt
/// 创建日期	：2019/1/8 17:17:50 
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
using FluentValidation;

namespace BlogDemo.Infrastructure.Resources
{
    /// <summary>
    /// 
    /// <see cref="PostResourceValidator" langword="" />
    /// </summary>
    public class PostResourceValidator: AbstractValidator<PostResource>
    {
        public PostResourceValidator()
        {
            RuleFor(x=>x.Author)
                .NotNull()
                .WithName("作者")
                .WithMessage("{PropertyName}是必填的")
                .MaximumLength(50)
                .WithMessage("{PropertyName}的最大长度是{MaxLength}");
        }
    }
}
