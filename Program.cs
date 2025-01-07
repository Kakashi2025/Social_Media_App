using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System.Text.RegularExpressions;
using WebApplicationSocialMediaApp;

namespace WebApplicationSocialMediaApp
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            //var target = new Uri(args[0]);
            //var handler = new ClearanceHandler();
            ////handler.MaxRetries = ClearanceHandler.DefaultMaxRetries;
            //var client = new HttpClient(handler);

            //try
            //{
            //    var content = client.GetStringAsync(target).Result;
            //    var title = Regex.Match(content, "<title>(?<Title>[^<]+)").Groups["Title"].Value.Trim();
            //    Console.WriteLine(title);
            //}
            //catch (AggregateException ex) when (ex.InnerException is CloudFlareClearanceException)
            //{
            //    Console.WriteLine(ex.InnerException.Message);
            //}
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