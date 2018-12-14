using Lesson7.Services;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lesson7.Middlewares
{
    public class TestCounterMiddleware: IMiddleware//基于工厂模式的中间件继承的接口
    {
        //private RequestDelegate _next;
        ////Scoped模式不能再中间件中的构造函数中注入，要在InvokeAsync中注入
        //public TestCounterMiddleware(RequestDelegate next)
        //{
        //    _next = next;
        //}

        //public async Task InvokeAsync(HttpContext context,ICounter _counter)
        //{
        //    var count= _counter.Get();
        //    if (count>3)
        //    {
        //        await context.Response.WriteAsync(count.ToString());
        //    }
        //    else
        //    {
        //        await _next(context);
        //    }
        //}

        //-----------工厂模式------------------------------------------------------------------------------------------------------
        //这时候中间件也要注入到Service中，因为继承了IMiddleware接口嘛

        private ICounter _counter;
        public TestCounterMiddleware(ICounter counter)
        {
            _counter = counter;
        }

        //基于工厂模式的中间件
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            var count = _counter.Get();
            if (count > 3)
            {
                await context.Response.WriteAsync(count.ToString());
            }
            else
            {
                await next(context);
            }
        }
    }
}
