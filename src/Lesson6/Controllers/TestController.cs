using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Lesson6.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            return Content("请求成功");
        }
    }
}