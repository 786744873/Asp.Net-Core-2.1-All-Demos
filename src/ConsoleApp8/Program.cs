using System;

namespace ConsoleApp8
{
    class Program
    {
        static void Main(string[] args)
        {
            //浏览器访问127.0.0.1:8200/1.html
            WebServer.Start();

            Console.ReadKey();
        }
    }
}
