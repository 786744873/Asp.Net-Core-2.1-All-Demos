using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lesson6.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Lesson6
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            //app.Map("/api", builder =>//使用中间件分支(map后面的将不会再执行了)
            //{
            //    builder.UseMiddleware<SignMiddleware>();
            //});

            app.MapWhen(context =>
            {
                string agent= context.Request.Headers["user-agent"];
                if (agent.IndexOf("mobile")!=-1|| agent.IndexOf("iphone") != -1 || agent.IndexOf("android")!= -1)
                {
                    return true;
                }
                return false;
            }, builder =>//使用中间件分支(map后面的将不会再执行了)
            {
                builder.UseMiddleware<SignMiddleware>();
            });


            app.UseStaticFiles();

            //app.UseMiddleware<SignMiddleware>(); //使用自定义中间件
            //app.Use(next =>
            //{
            //    return context =>
            //    {
            //        //return context.Response.WriteAsync("直接定义在Startup中的中间件");
            //        return next(context);
            //    };
            //});
            //app.Run(context =>//使用Run表示最后一个中间件
            //{
            //    return context.Response.WriteAsync("这是最后的中间件");
            //});

            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
