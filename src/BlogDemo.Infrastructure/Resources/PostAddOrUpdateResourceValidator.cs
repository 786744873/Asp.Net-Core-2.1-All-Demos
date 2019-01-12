/// ***********************************************************************
///
/// =================================
/// CLR版本	：4.0.30319.42000
/// 命名空间	：BlogDemo.Infrastructure.Resources
/// 文件名称	：PostAddOrUpdateResourceValidator.cs
/// =================================
/// 创 建 者	：wyt
/// 创建日期	：2019/1/10 14:48:21 
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
using FluentValidation;

namespace BlogDemo.Infrastructure.Resources
{
    /// <summary>
    /// 
    /// </summary>
    public class PostAddOrUpdateResourceValidator<T>:AbstractValidator<T> where T:PostAddOrUpdateResource
    {
        public PostAddOrUpdateResourceValidator()
        {
            RuleFor(x=>x.Title)
                .NotNull()
                .WithName("标题")
                .WithMessage("required|{PropertyName}是必填的")
                .MaximumLength(50)
                .WithMessage("maxlength|{PropertyName}的最大长度是{MaxLength}");

            RuleFor(x => x.Body)
                .NotNull()
                .WithName("正文")
                .WithMessage("required|{{PropertyName}是必填的")
                .MinimumLength(100)
                .WithMessage("minlength|{PropertyName}的最小长度是{MinLength}");
        }
    }
}
