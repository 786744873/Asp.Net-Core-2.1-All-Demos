using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Lesson2.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.show = true;
            return View();
        }
    }
}