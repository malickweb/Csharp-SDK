using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

using Kameleoon;



namespace myWebApp
{
    public class Program
    {
        public static IKameleoonClient kameleoonClient;
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
