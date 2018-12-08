using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using Microsoft.Extensions.Logging.Configuration;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            //IOC容器
            ServiceCollection services = new ServiceCollection();

            //注册服务
            services.AddScoped<IFlay, Pig>();

            //注册日志服务
            services.AddLogging();

            var provider = services.BuildServiceProvider();

            provider.GetService<ILoggerFactory>().AddConsole(LogLevel.Debug);

            var fly = provider.GetService<IFlay>();

            fly.Flay();

        }
    }

    public interface IFlay
    {
        void Flay();
    }

    public class Pig : IFlay
    {
        ILogger<Pig> logger = null;

        public Pig(ILoggerFactory loggerFactory)
        {
            logger=loggerFactory.CreateLogger<Pig>();
        }

        public void Flay()
        {
            logger.LogInformation("这是Console日志");
            Console.WriteLine("风口来了，猪都会飞了！");
        }
    }

}
