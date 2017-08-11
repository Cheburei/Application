using Autofac;
using Autofac.Integration.WebApi;
using System.Reflection;
using UsersWebAPI.Data;

namespace UsersWebAPI
{
    public class ContainerConfig
    {
        public static IContainer CreateContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterType<UserRepository>().As<IUserRepository>().InstancePerRequest();
            return builder.Build();
        }
    }
}
