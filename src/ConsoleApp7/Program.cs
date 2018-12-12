using ConsoleApp7_Common;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp7
{
    class Program
    {
        static void Main(string[] args)
        {
            var tokenSource = new CancellationTokenSource();

            Task.Factory.StartNew(() =>
            {
                while (!tokenSource.IsCancellationRequested)
                {
                    //Console.WriteLine($"{DateTime.Now}:业务逻辑处理中");
                    File.AppendAllText("1.txt", $"{DateTime.Now}:业务逻辑处理中");
                    Thread.Sleep(1000);
                }
            }).ContinueWith(t =>
            {
                File.AppendAllText("1.txt", "服务安全退出！");

                //Console.WriteLine("服务安全退出！");
                Environment.Exit(0);//强制退出
            });

            File.AppendAllText("1.txt", "服务成功开启");
            //Console.WriteLine("服务成功开启");

            while (!"Y".Equals(ConfigurationManager.Configuration["isquit"],StringComparison.InvariantCultureIgnoreCase))
            {
                Thread.Sleep(1000);
            }

            tokenSource.Cancel();
        }
    }
}
