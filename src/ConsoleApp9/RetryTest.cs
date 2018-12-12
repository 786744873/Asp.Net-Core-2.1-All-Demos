/// ***********************************************************************
///
/// =================================
/// CLR版本	：4.0.30319.42000
/// 命名空间	：ConsoleApp9
/// 文件名称	：RetryTest.cs
/// =================================
/// 创 建 者	：wyt
/// 创建日期	：2018/12/12 9:24:32 
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

namespace ConsoleApp9
{
    /// <summary>
    /// 
    /// <see cref="RetryTest" langword="" />
    /// </summary>
    public class RetryTest
    {
        //重试策略的设定
        public static void Run()
        {
            var retrayPloicy = Policy.Handle<WebException>()
                .WaitAndRetry(new List<TimeSpan>() {
                    TimeSpan.FromSeconds(1),
                                        TimeSpan.FromSeconds(3),
                                        TimeSpan.FromSeconds(5)
                }, (ex, dt) =>
                {
                    Console.WriteLine($"{DateTime.Now} {ex.Message}  {dt} ");
                });

            int count = 0;

            var html = retrayPloicy.Execute(() =>
            {
                var url = "http://1cnblogs.com";

                if (count == 3) url = "http://cnblogs.com";

                return GetHtml(url, ref count);
            });

            //这个是我调用第三次获取到的内容。。
            Console.WriteLine(html);
        }


        /// <summary>
        /// 获取页面内容
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static string GetHtml(string url, ref int count)
        {
            var html = string.Empty;
            try
            {
                var webClient = new WebClient();

                html = webClient.DownloadString(url);
            }
            catch (Exception ex)
            {
                count++;
                throw;
            }

            return html;
        }
    }
}
