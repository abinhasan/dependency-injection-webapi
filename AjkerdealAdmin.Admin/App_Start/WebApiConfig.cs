using AjkerdealAdmin.Admin.App_Start;
using Microsoft.Practices.Unity.WebApi;
using System.Web.Http;

namespace AjkerdealAdmin.Admin
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            config.SetCorsPolicyProviderFactory(new CorsPolicyFactory());
            config.EnableCors();

            config.DependencyResolver = new UnityDependencyResolver(UnityConfig.GetConfiguredContainer());
            

            WebApiUnityActionFilterProvider.RegisterFilterProviders(config);

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
