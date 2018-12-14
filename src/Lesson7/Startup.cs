using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lesson7.Filters;
using Lesson7.Middlewares;
using Lesson7.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Lesson7
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


            //services.AddSingleton(typeof(Counter));
            //services.AddSingleton(typeof(ICounter), typeof(Counter));
            services.AddSingleton<ICounter, Counter>();
            //services.AddScoped(typeof(Counter));
            //services.AddScoped(typeof(ICounter), typeof(Counter));
            //services.AddScoped<ICounter, Counter>();
            //services.AddTransient(typeof(Counter));
            //services.AddTransient(typeof(ICounter), typeof(Counter));
            //services.AddTransient<ICounter, Counter>();

            services.AddSingleton<TestCounterMiddleware>();//注册中间件
            services.AddSingleton<TestFilterAttribute>();//注册过滤器

            services.AddMvc(options =>
            {
                //options.Filters.Add(new TestFilter());这种过滤器是实例化的，无法进行注入
                //options.Filters.Add(typeof(TestFilterAttribute));
                options.Filters.Add(new TestFilterFactoryAttribute());//过滤器工厂来给过滤器特性【Attribute】注入构造函数参数（所以过滤器工厂的最大作用是为了给过滤器传参数）
            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
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

            app.UseMiddleware<TestCounterMiddleware>();


            app.UseStaticFiles();
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
