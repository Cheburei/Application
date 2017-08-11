using Autofac.Integration.WebApi;
using System.Web.Http;
using System.Web.Http.SelfHost;

namespace UsersWebAPI
{
    public class SelfHostConfigBuilder
    {
        public static HttpSelfHostConfiguration BuildConfig(string hostUrl, string originUrl)
        {
            HttpSelfHostConfiguration config = new HttpSelfHostConfiguration(hostUrl);
            RouteConfig.RegisterRoutes(config.Routes);
            config.DependencyResolver = new AutofacWebApiDependencyResolver(ContainerConfig.CreateContainer());
            config.EnableCors(CorsConfig.EnableCors(originUrl));
            return config;
        }
    }
}
