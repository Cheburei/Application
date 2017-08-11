using Autofac;
using Autofac.Integration.WebApi;
using DepartmentsWebApi.Data;
using System.Reflection;

namespace DepartmentsWebApi
{
    public class ContainerConfig
    {
        public static IContainer CreateContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterType<DepartmentRepository>().As<IDepartmentRepository>().InstancePerRequest();
            return builder.Build();
        }
    }
}
