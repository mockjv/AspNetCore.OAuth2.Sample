using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace AspNetCore.OAuth2.Sample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            return WebHost
                .CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    var env = hostingContext.HostingEnvironment;
                    config
                        .SetBasePath(env.ContentRootPath)
                        .AddJsonFile("appsettings.json", false, true)
                        .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true, true)
                        .AddUserSecrets<Startup>()
                        .AddEnvironmentVariables()
                        .AddCommandLine(args);
                })
                .UseStartup<Startup>();
        }
    }
}