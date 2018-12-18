using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Lesson12.Models;
using Microsoft.Extensions.Logging;

namespace Lesson12.Controllers
{
    public class HomeController : Controller
    {
        private ILogger _logger;

        public HomeController(ILoggerFactory factory,ILogger<HomeController> logger)
        {
            _logger = factory.CreateLogger(nameof(HomeController));
            _logger = logger;
        }

        public IActionResult Index(int id,string name)
        {
            _logger.LogDebug("这是日志示例代码");
            //_logger.LogDebug("这是数据展示{name}{id}", id,name);//日志模板
            //_logger.LogDebug(CustomEventIDs.AddCustom, "这是EventId展示");//日志模板
            _logger.LogWarning("这是LogLevel.Warning日志");

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
