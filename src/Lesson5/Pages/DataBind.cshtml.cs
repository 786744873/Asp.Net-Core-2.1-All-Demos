using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Lesson5.Pages
{
    public class DataBindModel : PageModel
    {
        public void OnPost()
        {
            UserName = $"原有值：{UserName}修改成新的值：123";
        }

        [BindProperty]
        //[BindProperty(SupportsGet =true)]     //默认值支持Post请求，如果要支持Get请求，那么要加上SupportsGet
        [ViewData]
        [TempData]
        public string UserName { get; set; }
    }
}