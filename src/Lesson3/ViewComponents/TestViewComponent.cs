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
    public class TestViewCompont : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return Content("这是一个视图组件");
        }
    }
}
