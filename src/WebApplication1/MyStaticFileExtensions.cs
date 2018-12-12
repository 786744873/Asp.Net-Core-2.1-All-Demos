using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1
{
    public static class MyStaticFileExtensions
    {
        public static IApplicationBuilder UseMyStaticFile(this IApplicationBuilder app)
        {
            if (app == null)
            {
                throw new ArgumentNullException("app");
            }
            return app.UseMiddleware<MyStaticFileMiddleware>(Array.Empty<object>());
        }
    }
}
