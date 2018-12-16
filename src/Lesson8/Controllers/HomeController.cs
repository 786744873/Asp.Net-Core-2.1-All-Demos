using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Lesson8.Models;
using Microsoft.Extensions.Configuration;
using Lesson8.Configs;
using Microsoft.Extensions.Options;

namespace Lesson8.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfiguration _config;
        //private readonly IOptions<Database> _database;    //固定配置，配置更新了无法进行重新加载
        //private readonly IOptionsSnapshot<Database> _database;    //快照方式，每次使用都重新访问读取配置文件
        private readonly IOptionsMonitor<Database> _database;   //监听方式,配置文件发生改变时进行重新读取，并且可以监听配置文件改变

        //public HomeController(IConfiguration config, IOptions<Database> database)
        //public HomeController(IConfiguration config, IOptionsSnapshot<Database> database)
        public HomeController(IConfiguration config, IOptionsMonitor<Database> database)
        {
            _config = config;
            _database = database;
        }

        public IActionResult Index()
        {
            string value = _config["Section:key1"];
            string value1 = _config["Section:key2:subkey1"];
            ViewBag.value = value;
            ViewBag.value1 = value1;

            Database db = _database.Get("database2");
            ViewBag.database = $"server:{db.Server},name:{db.Name}";
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
