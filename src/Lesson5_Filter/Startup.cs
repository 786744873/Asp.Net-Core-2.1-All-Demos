using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lesson5_Filter.Filters;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Lesson5_Filter
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


            services
                //.AddMvc(options => {//注册全局过滤器
                //    options.Filters.Add(new TestPageFilter());
                //})

                //.AddMvc().AddRazorPagesOptions(options=> {//注册非全局过滤器
                //    options.Conventions.AddFolderApplicationModelConvention("/product", model => model.Filters.Add(new TestPageFilter()));//文件夹级别
                //    options.Conventions.AddAreaFolderApplicationModelConvention("admin","/product", model => model.Filters.Add(new TestPageFilter()));//area级别
                //    options.Conventions.AddPageApplicationModelConvention("/Index", model => model.Filters.Add(new TestPageFilter()));//页面级别
                //})
                .AddMvc()//不在Service中注册，可以使用特性或者重写PageModel
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
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
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc();
        }
    }
}
