using AjkerdealAdmin.Admin.Filters;
using System.Net.Http;
using System.Web.Http.Cors;

namespace AjkerdealAdmin.Admin.App_Start
{
    public class CorsPolicyFactory : ICorsPolicyProviderFactory
    {
        private readonly ICorsPolicyProvider _corsPolicyProvider = new CorsPolicyAttribute();

        public ICorsPolicyProvider GetCorsPolicyProvider(HttpRequestMessage request)
        {
            return _corsPolicyProvider;
        }
    }
}