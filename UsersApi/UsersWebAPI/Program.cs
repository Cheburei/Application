using System;
using System.Web.Http.SelfHost;

namespace UsersWebAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            using (HttpSelfHostServer server = new HttpSelfHostServer(SelfHostConfigBuilder.BuildConfig(Settings.HostUrl, Settings.OriginUrl)))
            {
                server.OpenAsync().Wait();
                Console.WriteLine("Press Enter to quit.");
                Console.ReadLine();
            }
        }
    }
}
