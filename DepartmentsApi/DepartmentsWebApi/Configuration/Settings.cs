using System.Configuration;

namespace DepartmentsWebApi
{
    public class Settings
    {
        public static string HostUrl => ConfigurationManager.AppSettings["HostUrl"];
        public static string OriginUrl => ConfigurationManager.AppSettings["OriginUrl"];
    }
}
