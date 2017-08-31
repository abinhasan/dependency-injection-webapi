using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Cors;
using System.Web.Http.Cors;

namespace AjkerdealAdmin.Admin.Filters
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = false)]
    public class CorsPolicyAttribute : Attribute, ICorsPolicyProvider
    {
        private readonly CorsPolicy _corsPolicy;
        public CorsPolicyAttribute()
        {
            _corsPolicy = new CorsPolicy()
            {
                AllowAnyHeader = true,
                AllowAnyMethod = false,
                AllowAnyOrigin = false,
                Methods = { "get", "post" },
                Origins =
                {
                    "http://www.ajkerdeal.com",
                    "https://www.ajkerdeal.com",
                    "http://ajkerdeal.com",
                    "https://ajkerdeal.com",
                    "http://m.ajkerdeal.com",
                    "https://m.ajkerdeal.com"
                }
            };
        }

        public Task<CorsPolicy> GetCorsPolicyAsync(HttpRequestMessage request
            , CancellationToken cancellationToken)
        {
            return Task.FromResult(_corsPolicy);
        }
    }
}