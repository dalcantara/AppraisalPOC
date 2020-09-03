using Microsoft.AspNetCore.Blazor.Hosting;

namespace Appraisal.BlazorClient
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IWebAssemblyHostBuilder CreateHostBuilder(string[] args)
        {
            var builder = BlazorWebAssemblyHost.CreateDefaultBuilder();
            builder.UseBlazorStartup<Startup>();
            return builder;
        }
    }
}
