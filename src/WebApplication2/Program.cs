﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace WebApplication2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            var builder= WebHost.CreateDefaultBuilder(args)
                //.UseUrls("http://127.0.0.1:9011")
                //.UseSetting(WebHostDefaults.ServerUrlsKey, "http://127.0.0.1:9012")
                .UseStartup<Startup>();

            //var configuration = new ConfigurationBuilder()
            //    .SetBasePath(Environment.CurrentDirectory)
            //    .AddJsonFile("host.json")
            //    .Build();

            //builder.UseConfiguration(configuration);

            return builder;
        }
            
    }
}
