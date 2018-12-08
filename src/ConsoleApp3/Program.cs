using AspectCore.DynamicProxy;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using AspectCore.Extensions.DependencyInjection;
using System.Collections.Generic;

namespace ConsoleApp3
{
    //https://github.com/dotnetcore/AspectCore-Framework
    class Program
    {
        static void Main(string[] args)
        {
            ServiceCollection services = new ServiceCollection();

            //注册AspectCore动态代理服务
            services.AddDynamicProxy();

            services.AddTransient<IMySql, MySql>();

            var provider= services.BuildDynamicProxyServiceProvider();

            var mysql = provider.GetService<IMySql>();

            //走业务逻辑
            var msg= mysql.GetData(10);
            Console.WriteLine(msg);

            //走缓存
            msg = mysql.GetData(10);
            Console.WriteLine(msg);

        }
    }

    public class MysqlInterceptorAttribute : AbstractInterceptorAttribute
    {
        private Dictionary<string, string> cacheDict = new Dictionary<string, string>();

        public override Task Invoke(AspectContext context, AspectDelegate next)
        {

            //用id作为cachekey
            var cacheKey = string.Join(",", context.Parameters);
            if (cacheDict.ContainsKey(cacheKey))
            {
                context.ReturnValue = cacheDict[cacheKey];
                return Task.CompletedTask;
            }

            var task = next(context);
            //ReturnValue实际上就是一个传递值的媒介
            var cacheValue = context.ReturnValue;

            cacheDict.Add(cacheKey, $"from Cache：{cacheValue.ToString()}");

            return task;

            //Console.WriteLine("开始记录日志。。。。");
            //var task = next(context);
            //Console.WriteLine("结束记录日志。。。。");
            //return task;
        }
    }

    public interface IMySql
    {
        [MysqlInterceptor]
        string GetData(int id);
    }

    public class MySql : IMySql
    {
        public string GetData(int id)
        {
            var msg = $"已经获取到id={id}的数据";
            //Console.WriteLine(msg);
            return msg;
        }
    }
}
