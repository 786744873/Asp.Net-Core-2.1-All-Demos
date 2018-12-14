using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lesson3.ViewComponents
{
    /*声明视图组件的三种方式
     * 
     * 1.类派生自ViewComponent
     * 2.添加 [ViewComponent] 特性
     * 3.类以ViewComponent结尾
     * 
     * 注意，千万不可以ViewComponent结尾再派生自ViewComponent
     */
    //[ViewComponent(Name =nameof(TestViewCompont))]//可以添加Name属性给视图组件重命名(不使用该特性的话会无法在视图中调用TagHelper以name引用,而且使用<vc></vc>元素必须采用小写短横线格式)
    public class TestViewCompont : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(string name)
        {
            return Content("这是一个视图组件"+name);
        }
    }
}
