/// ***********************************************************************
///
/// =================================
/// CLR版本	：4.0.30319.42000
/// 命名空间	：ConsoleApp9
/// 文件名称	：CircuitBreakderTest.cs
/// =================================
/// 创 建 者	：wyt
/// 创建日期	：2018/12/12 9:44:39 
/// 邮箱		：786744873@qq.com
/// 个人主站	：https://www.cnblogs.com/wyt007/
///
/// 功能描述	：
/// 使用说明	：
/// =================================
/// 修改者	：
/// 修改日期	：
/// 修改内容	：
/// =================================
///
/// ***********************************************************************


using Polly;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading;

namespace ConsoleApp9
{
    /// <summary>
    /// 
    /// <see cref="CircuitBreakderTest" langword="" />
    /// </summary>
    public class CircuitBreakderTest
    {
        public static void Run()
        {
            //如果当前连续有两个异常，那么触发熔断，10s内不能调用，10s之后重新调用。
            //一旦调用成功了，熔断就解除了。
            var policy = Policy.Handle<WebException>()
                .CircuitBreaker(2, TimeSpan.FromSeconds(10), (ex, timespan, context) =>
                {
                    //触发熔断
                    Console.WriteLine($"{DateTime.Now} 熔断触发：{timespan}");
                }, (context) =>
                {
                    //恢复
                    Console.WriteLine($"{DateTime.Now} 熔断恢复");
                });

            var errCount = 1;

            for (int i = 0; i < 100; i++)
            {
                try
                {
                    var msg = policy.Execute<string>((context, token) =>
                    {
                        var url = "http://cnblogs1.com";

                        //模拟，当一定的时间后，恢复正常
                        if (errCount > 10)
                        {
                            url = "http://cnblogs.com";
                        }

                        return GetHtml(url);

                    }, new Dictionary<string, object>() { { i.ToString(), i.ToString() } }, CancellationToken.None);

                    Console.WriteLine("logic：" + msg);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(string.Format("{0} 业务逻辑异常：'{1}'", DateTime.Now, ex.Message));

                    System.Threading.Thread.Sleep(2000);

                    errCount++;
                }
            }
        }

        /// <summary>
        /// 获取页面内容
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static string GetHtml(string url)
        {
            var html = string.Empty;
            try
            {
                var webClient = new WebClient();

                html = webClient.DownloadString(url).Substring(0, 10);

            }
            catch (Exception ex)
            {
                throw;
            }

            return html;
        }
    }
}
