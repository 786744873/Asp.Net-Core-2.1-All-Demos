using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Lesson6.Middlewares
{
    public class SignMiddleware
    {
        private readonly RequestDelegate _next;

        public SignMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            //获取当前请求数据,从querystring集合中获取数据列表
            IQueryCollection query = context.Request.Query;

            //把数据按照一定规则+key进行加密
            string str = "";
            foreach (var key in query.Keys)
            {
                if (key=="sign")
                {
                    continue;
                }
                str += key + query[key];
            }
            str += "秘钥字符串";
            string md5Result = GetMD5(str);

            //把当前数据传递的sign的值与第二步签名数据对比
            string requestSign = query["sign"];
            if (md5Result==requestSign)
            {
                // Call the next delegate/middleware in the pipeline
                await _next(context);
            }
            else
            {
                //返回错误信息
                context.Response.WriteAsync("request not valid");
            }
        }


        private string GetMD5(string str)
        {
            using (MD5 md5=MD5.Create())
            {
                byte[] result= md5.ComputeHash(Encoding.UTF8.GetBytes(str));
                string strResult = BitConverter.ToString(result);
                return strResult.Replace("-",string.Empty).ToLower();
            }
        }
    }
}
