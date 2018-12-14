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
                //.AddMvc(options => {//ע��ȫ�ֹ�����
                //    options.Filters.Add(new TestPageFilter());
                //})

                //.AddMvc().AddRazorPagesOptions(options=> {//ע���ȫ�ֹ�����
                //    options.Conventions.AddFolderApplicationModelConvention("/product", model => model.Filters.Add(new TestPageFilter()));//�ļ��м���
                //    options.Conventions.AddAreaFolderApplicationModelConvention("admin","/product", model => model.Filters.Add(new TestPageFilter()));//area����
                //    options.Conventions.AddPageApplicationModelConvention("/Index", model => model.Filters.Add(new TestPageFilter()));//ҳ�漶��
                //})
                .AddMvc()//����Service��ע�ᣬ����ʹ�����Ի�����дPageModel
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
