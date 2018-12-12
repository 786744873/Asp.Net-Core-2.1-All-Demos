/// ***********************************************************************
///
/// =================================
/// CLR版本	：4.0.30319.42000
/// 命名空间	：ConsoleApp9
/// 文件名称	：FallbackTest.cs
/// =================================
/// 创 建 者	：wyt
/// 创建日期	：2018/12/12 10:12:12 
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
    /// <see cref="FallbackTest" langword="" />
    /// </summary>
    public class FallbackTest
    {
        public static void Run()
        {
            var result = Policy<string>.Handle<WebException>()
                                    .Fallback(() =>
                                    {
                                        return "接口失败，这个fake的值给你！";
                                    })
                                    .Execute(() =>
                                    {
                                        return GetHtml("http://1cnblogs.com");
                                    });

            Console.WriteLine(result);

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
            }
            catch (Exception ex)
            {
                throw;
            }

            return html;
        }
    }
}
