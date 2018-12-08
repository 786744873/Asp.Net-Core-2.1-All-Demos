/// ***********************************************************************
///
/// =================================
/// CLR版本	：4.0.30319.42000
/// 命名空间	：ConsoleApp7_Common
/// 文件名称	：ConfigurationManager.cs
/// =================================
/// 创 建 者	：wyt
/// 创建日期	：2018/12/8 18:08:34 
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


using Microsoft.Extensions.Configuration; 
//using Microsoft.Extensions.Configuration.
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace ConsoleApp7_Common
{
    /// <summary>
    /// 
    /// <see cref="ConfigurationManager" langword="" />
    /// </summary>
    public class ConfigurationManager
    {
        public static IConfigurationRoot Configuration
        {
            get
            {
                var configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile(string.Format("appsettings.{0}.json", Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")),optional:true,reloadOnChange:true)
                    .AddJsonFile(string.Format("ops.{0}.json", Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")),optional:true,reloadOnChange:true)
                    .Build();
                return configuration;
            }
        }
    }
}
