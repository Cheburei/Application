using System.Web.Http.Cors;

namespace DepartmentsWebApi
{
    public class CorsConfig
    {
        public static EnableCorsAttribute EnableCors(string originUrl)
        {
            return new EnableCorsAttribute(originUrl, "*", "*");
        }
    }
}
