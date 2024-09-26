using System.Net;

public class Program
{
    public static void Main(string[] args)
    {

        var config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddEnvironmentVariables()
                .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json", optional: true, reloadOnChange: true)
            .Build();
        var httpsPort = config.GetValue<int>("ASPNETCORE_HTTPS_PORT");
        var httpsUrl = config.GetValue<string>("ASPNETCORE_URLS");
        var env = config["ASPNETCORE_ENVIRONMENT"] ?? "Development";//Production

        Console.WriteLine(httpsPort);
        Console.WriteLine(httpsUrl);
        Console.WriteLine(env);

        var host = new WebHostBuilder()
            .UseKestrel(opt => { opt.Listen(IPAddress.Any, httpsPort); })
            .UseUrls(httpsUrl)
            .UseConfiguration(config)
            .UseEnvironment(env)
            .UseContentRoot(Directory.GetCurrentDirectory())
            .UseIISIntegration()
            .UseStartup< LibraryToDo.Api.Startup>()
            .Build();
        host.Run();

    }
}