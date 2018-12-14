using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lesson5_Filter.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Lesson5_Filter.Pages
{
    [TestPageFilter]
    public class IndexModel : PageModel
    {
        public void OnGet(string arg)
        {
            ViewData["arg"] = arg; 
        }

        //public override void OnPageHandlerExecuting(PageHandlerExecutingContext context)
        //{
        //    context.HandlerArguments["arg"] = "过滤器重写通用传递的值";
        //}
    }
}
