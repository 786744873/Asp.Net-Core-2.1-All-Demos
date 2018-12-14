using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lesson4.Filters
{
    public class CacheResourceFilter: IResourceFilter
    {
        public void OnResourceExecuted(ResourceExecutedContext context)
        {
        }

        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            //从缓存里读取对应数据信息
            IMemoryCache cache = context.HttpContext.RequestServices.GetService<IMemoryCache>();
            //key=>value
            //请求路径
            string path = context.HttpContext.Request.Path.ToString();
            if (cache.TryGetValue(path, out object value))
            {
                //如果存在，直接返回
                string result = value.ToString();
                context.Result = new ContentResult() { Content = result };
            }
        }
    }
}
