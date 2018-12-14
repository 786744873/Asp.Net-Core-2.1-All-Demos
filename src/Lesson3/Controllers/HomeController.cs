using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Lesson3.Models;
using Lesson3.ViewComponents;

namespace Lesson3.Controllers
{
    //官文地址：https://docs.microsoft.com/zh-cn/aspnet/core/mvc/views/view-components?view=aspnetcore-2.2
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return ViewComponent(nameof(TestViewCompont), new { name = "视图参数" });
            //return ViewComponent("TestViewCompont");
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
