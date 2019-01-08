using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BlogDemo.Api.Extensions;
using BlogDemo.Core.Interfaces;
using BlogDemo.Infrastructure.Database;
using BlogDemo.Infrastructure.Repositories;
using BlogDemo.Infrastructure.Resources;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;

namespace BlogDemo.Api
{
    public class StartupDevelopment
    {
        public IConfiguration Configuration { get; set; }

        public StartupDevelopment(IConfiguration configuration)
        {
            Configuration = configuration;

            //配置Serilog
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .MinimumLevel.Override("Microsoft",LogEventLevel.Information)//如果日志是Microsoft开头的，则最小权限为Info
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .WriteTo.File(Path.Combine("logs",@"log.txt"),rollingInterval:RollingInterval.Day)//每天生成一个文件
                .CreateLogger();
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // 使用Serilog
            services.AddLogging(loggingBuilder =>
            {
                loggingBuilder.ClearProviders();// 清除内置的Log提供程序
                loggingBuilder.AddSerilog(dispose: true);
            });

            services.AddMvc(options =>
            {
                options.ReturnHttpNotAcceptable = true;//允许406
                options.OutputFormatters.Add(new XmlSerializerOutputFormatter());//允许返回XML格式数据（不设置的话会返回406）

            }).AddFluentValidation();//使用FluentValidation验证

            services.AddDbContext<MyContext>(options =>
            {
                //options.UseSqlServer("Server=127.0.0.1;Database=BlogDemo;User Id=sa;Password=123456;Trusted_Connection=True;");
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"),b=>b.UseRowNumberForPaging(true));
            });

            services.AddHttpsRedirection(options =>
            {
                options.RedirectStatusCode = StatusCodes.Status307TemporaryRedirect;
                options.HttpsPort = 5001;
            });

            services.AddScoped<IPostRepository, PostRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            //添加对AutoMapper的支持
            services.AddAutoMapper();

            // 加入FluentValidation验证规则
            services.AddTransient<IValidator<PostResource>, PostResourceValidator>();

            //添加UrlHelper(来生成分页)
            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
            services.AddScoped<IUrlHelper>(factory =>
            {
                var actionContext = factory.GetService<IActionContextAccessor>().ActionContext;
                return new UrlHelper(actionContext);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env,ILoggerFactory loggerFactory)
        {

            if (env.IsDevelopment())
            {
                //app.UseDeveloperExceptionPage();
                app.UseMyExceptionHandler(loggerFactory);
            }

            app.UseHttpsRedirection();

            app.UseMvc();
        }
    }
}
