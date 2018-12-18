using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Lesson10.Models;
using Lesson10.ModelBinders;

namespace Lesson10.Controllers
{
    public class HomeController : Controller
    {
        //  http://localhost:5000/?user=1
        //public IActionResult Index([ModelBinder(BinderType =typeof(UserModelBinder))]UserInfo user)//可以绑定这参数这里也可以绑定在类上面
        public IActionResult Index(UserInfo user)//可以绑定这参数这里也可以绑定在类上面
        {

            if (ModelState.IsValid)
            {
                ViewBag.name = user.Name;
            }

            return View();
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
