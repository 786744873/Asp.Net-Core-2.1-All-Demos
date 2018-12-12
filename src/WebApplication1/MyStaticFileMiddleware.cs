using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1
{
    public class MyStaticFileMiddleware
    {
        private readonly RequestDelegate _next;

        public MyStaticFileMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext context)
        {
            //1.logic   如果我当前的Context中有png，那么就直接从文件中读取，否则放下传递
            var path = context.Request.Path.Value;
            if (path.Contains(".png"))
            {
                var mypath = path.Trim('/');
                return context.Response.SendFileAsync(mypath);
            }

            var task = _next(context);
            return task;
        }
    }
}
