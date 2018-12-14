using Lesson7.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lesson7.Filters
{
    public class TestFilterAttribute :Attribute, IActionFilter
    {
        private ICounter _counter;
        public TestFilterAttribute(ICounter counter)
        {
            _counter = counter;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            int count = _counter.Get();
            if (count > 3)
            {
                context.Result = new ContentResult() { Content = count.ToString() };
            }
        }
    }
}
