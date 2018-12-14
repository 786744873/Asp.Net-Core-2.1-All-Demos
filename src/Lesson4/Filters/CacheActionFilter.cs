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
    public class CacheActionFilterAttribute :Attribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            //获取动作结果
            ContentResult contentResult = context.Result as ContentResult;
            if (contentResult != null)
            {
                string content = contentResult.Content;
                //缓存数据
                string path = context.HttpContext.Request.Path.ToString();
                IMemoryCache cache = context.HttpContext.RequestServices.GetService<IMemoryCache>();
                cache.Set(path, "缓存中的数据：" + content); 
            }
            //判断是否是一个ContentResult,如果是，获取数据并缓存

        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
        }
    }
}
