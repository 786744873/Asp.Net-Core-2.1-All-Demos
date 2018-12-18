using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Lesson11.Models;
using Microsoft.AspNetCore.Diagnostics;

namespace Lesson11.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            throw new Exception("这是测试的异常");
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
            //获取当前的异常信息
            IExceptionHandlerFeature exception = HttpContext.Features.Get<IExceptionHandlerFeature>();
            Exception ex = exception.Error;
            ViewBag.message = ex.Message;
            //return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            return View();
        }

        public IActionResult HttpError(int code)
        {
            return View(code);
        }
    }
}
