/// ***********************************************************************
///
/// =================================
/// CLR版本	：4.0.30319.42000
/// 命名空间	：ConsoleApp9
/// 文件名称	：TimeoutTest.cs
/// =================================
/// 创 建 者	：wyt
/// 创建日期	：2018/12/12 9:55:55 
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
using System.Text;
using System.Threading;

namespace ConsoleApp9
{
    /// <summary>
    /// 
    /// <see cref="TimeoutTest" langword="" />
    /// </summary>
    public class TimeoutTest
    {
        public static void Run()
        {
            var cancellationToken = new CancellationToken();

            //10s后 cancellationToken过期
            var policy = Policy.Timeout(10);

            //通过cancellationToken进行传值，如果10s过去，IsCancellationRequested 自动变成取消状态
            policy.Execute((token) =>
            {
                for (int i = 0; i < 1000; i++)
                {
                    //大家需要根据这个状态来做具体的业务逻辑
                    Console.WriteLine(token.IsCancellationRequested);
                    System.Threading.Thread.Sleep(1000);
                }
            }, cancellationToken);

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

            Thread.Sleep(20);

            return html;
        }
    }
}
