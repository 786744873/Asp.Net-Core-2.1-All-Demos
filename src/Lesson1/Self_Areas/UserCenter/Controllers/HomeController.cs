using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Lesson1.Areas.UserCenter.Controllers
{
    [Area("UserCenter")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        { 
            return View();
        }
    }
}