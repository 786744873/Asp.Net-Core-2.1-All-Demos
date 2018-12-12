/// ***********************************************************************
///
/// =================================
/// CLR版本	：4.0.30319.42000
/// 命名空间	：ConsoleApp9
/// 文件名称	：BulkheadTest.cs
/// =================================
/// 创 建 者	：wyt
/// 创建日期	：2018/12/12 10:04:16 
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
using System.Threading.Tasks;

namespace ConsoleApp9
{
    /// <summary>
    /// 
    /// <see cref="BulkheadTest" langword="" />
    /// </summary>
    public class BulkheadTest
    {
        public static void Run()
        {
            var policy = Policy.Bulkhead(5, 1000);

            Parallel.For(0, 100, (i) =>
            {
                //这里只能做一次调用
                var result = policy.Execute<string>(() =>
                {
                    return GetHtml("http://cnblogs.com");
                });

                Console.WriteLine("已成功获取到数据:{0}", result);
            });


            Console.Read();
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

                html = webClient.DownloadString(url);

                html = html.Substring(0, 17);

                Console.WriteLine($"当前线程ID={Thread.CurrentThread.ManagedThreadId}");

                System.Threading.Thread.Sleep(2000);
            }
            catch (Exception ex)
            {
                throw;
            }

            return html;
        }
    }
}
