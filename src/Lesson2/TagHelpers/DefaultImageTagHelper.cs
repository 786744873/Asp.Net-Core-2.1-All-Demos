using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lesson2.TagHelpers
{
    [HtmlTargetElement("img")]//确定影响的元素范围（哪个标签生效的 ） 
    public class DefaultImageTagHelper : TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            //base.Process(context, output);

            //首先判断当前的src属性是否有值
            string src = context.AllAttributes["src"]?.Value.ToString();
            //如果没有值，修改src属性为默认图片
            if (string.IsNullOrEmpty(src))
            {
                var index = output.Attributes.IndexOfName("src");
                if (index > 0)//有图片地址
                {
                    output.Attributes[index] = new TagHelperAttribute("src", DefaultImage);
                }
                else
                {
                    output.Attributes.Add(new TagHelperAttribute("src", DefaultImage));
                }
            }

            //增加内容(只有有结束标签的才可以用)
            //output.PreContent.Append("前");
            //output.PostContent.Append("后");

            //增加外部标签
            output.PreElement.AppendHtml("<a>");
            output.PostElement.AppendHtml("</a>");
        }

        //确定属性输入(当前的属性值是从哪个属性中拿到的)
        [HtmlAttributeName("defaultimage")]
        public string DefaultImage { get; set; }



        /* TagHelperOutput:
         * 
         * AllAttributes 属性集合
         * Content  输入内容
         * TagName  标签名称
         * SuppressOutput   组织输入
         */
    }
}
