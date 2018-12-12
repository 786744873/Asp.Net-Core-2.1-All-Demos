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
     */
    public class TestViewComponent : ViewComponent
    {
        public TestViewComponent()
        {
        }

        public IViewComponentResult Invoke()
        {
            //return View();
            return Content("这是一个视图组件");
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return Content("这是一个视图组件");
        }
    }
}
