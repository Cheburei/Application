using System.Web.Http.Cors;

namespace UsersWebAPI
{
    public class CorsConfig
    {
        public static EnableCorsAttribute EnableCors(string originUrl)
        {
            return new EnableCorsAttribute(originUrl, "*", "*");
        }
    }
}
