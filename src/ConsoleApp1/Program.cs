using Microsoft.Extensions.Configuration;
using System;
using ConsoleApp1.Define;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            IConfiguration Configuration = new ConfigurationBuilder()
                .SetBasePath(Environment.CurrentDirectory)
                .AddJsonFile("appsettings.json", optional:true,reloadOnChange:true)
                .AddPropertiesFile("1.properties")//加载自定义文件
                .Build();

            Appsettings appsettings = new Appsettings();
            Configuration.Bind(appsettings);

            Console.WriteLine(appsettings.mysql.port);

            Console.WriteLine(Configuration["mysql:port"]);

            Console.WriteLine(Configuration.GetValue<int>("mysql:port"));

            Console.WriteLine(Configuration.GetSection("mysql").GetSection("port").Value);
            //读取自定义文件
            Console.WriteLine(Configuration["host"]);

            Console.Read();
        }
    }


    public class Appsettings
    {
        public Mysql mysql { get; set; }
        public Shopidlist[] shopidlist { get; set; }
    }

    public class Mysql
    {
        public string host { get; set; }
        public int port { get; set; }
    }

    public class Shopidlist
    {
        public int entid { get; set; }
    }

}
