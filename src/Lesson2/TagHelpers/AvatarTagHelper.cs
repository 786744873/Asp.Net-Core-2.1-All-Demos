using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lesson2.TagHelpers
{
    [HtmlTargetElement("avatar")]
    public class AvatarTagHelper: TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            //avatar=>img
            output.TagName = "img";

            output.Attributes.Add(new TagHelperAttribute("src", Url));

            //组织当前标签输出
            output.SuppressOutput();
        }

        [HtmlAttributeName("url")]
        public string Url { get; set; }
    }
}
