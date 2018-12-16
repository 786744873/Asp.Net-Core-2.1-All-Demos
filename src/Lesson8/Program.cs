using System;

using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;

namespace Lesson8
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((context,config)=> {
                    config.SetBasePath(Environment.CurrentDirectory);
                    //config.AddEnvironmentVariables(); //添加环境变量，系统会默认添加
                    config.AddJsonFile("database.json");
                    string env = context.HostingEnvironment.EnvironmentName;
                    config.AddJsonFile($"database.{env}.json",optional:true);
                })
                .UseStartup<Startup>();
    }
}
