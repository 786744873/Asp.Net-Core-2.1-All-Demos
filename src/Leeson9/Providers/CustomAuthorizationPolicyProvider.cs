using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Leeson9.Providers
{
    /// <summary>
    /// 自定义授权策略提供程序
    /// https://docs.microsoft.com/zh-cn/aspnet/core/security/authorization/iauthorizationpolicyprovider?view=aspnetcore-2.2
    /// </summary>
    public class CustomAuthorizationPolicyProvider : IAuthorizationPolicyProvider
    {
        private AuthorizationOptions _options;

        public CustomAuthorizationPolicyProvider(IOptions<AuthorizationOptions> options)
        {
            _options = options.Value;
        }

        public Task<AuthorizationPolicy> GetDefaultPolicyAsync()
        {
            return Task.FromResult(_options.DefaultPolicy);
        }

        public Task<AuthorizationPolicy> GetPolicyAsync(string policyName)
        {
            //先判断AuthorizationOptions里是否包含policyName
            AuthorizationPolicy policy= _options.GetPolicy(policyName);
            //如果有直接返回
            if (policy!=null)
            {
                return Task.FromResult(policy);
            }
            //如果没有，解析policyName，并加入到Options 
            string[] claims = policyName.Split(new char[] { '-' }, StringSplitOptions.None);
            _options.AddPolicy(policyName, policyBuilder =>
            {
                policyBuilder.RequireClaim(claims[0], claims[1]);
            });
            return Task.FromResult(_options.GetPolicy(policyName));
        }
    }
}
