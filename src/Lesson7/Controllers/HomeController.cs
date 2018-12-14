using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Lesson7.Models;
using Microsoft.Extensions.DependencyInjection;
using Lesson7.Services;
using Lesson7.Filters;

namespace Lesson7.Controllers
{
    [TestFilterFactory]   //采用工厂模式注入带参数的Filter
    //[TypeFilter(typeof(TestFilterAttribute))]//使用这种的话不需要用在Service中注册TestFilterAttribute(支持传参)
    //[ServiceFilter(typeof(TestFilterAttribute))]//使用这种的话需要用在Service中注册TestFilterAttribute(不支持传参)
    public class HomeController : Controller
    {
        private ICounter _counter;
        private IServiceProvider _provider;

        public HomeController(ICounter counter, IServiceProvider provider)
        {
            _counter = counter;
            _provider = provider;
        }

        public IActionResult Index()
        {
            int count = _counter.Get();
            ViewBag.count = count;
            ICounter counter1 = _provider.GetService<ICounter>();
            ICounter counter2 = _provider.GetService<ICounter>();
            if (counter1.Equals(counter2))
            {

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
