using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Csla.Configuration;
using Microsoft.Extensions.Configuration;
using Outliner.Dal.EF.Extensions;
using Outliner.UI.CLI;

var configBuilder = new ConfigurationBuilder();
BuildConfig(configBuilder);

using var host = CreateHostBuilder(args, configBuilder.Build()).Build();
using var scope = host.Services.CreateScope();

var services = scope.ServiceProvider;

try
{
    services.GetRequiredService<App>().Run(args);
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}

static IHostBuilder CreateHostBuilder(string[] args, IConfiguration config)
{
    return Host.CreateDefaultBuilder(args)
        .ConfigureServices((_, services) =>
        {
            services.AddCsla();
            services.AddDalEfCore(config);
            services.AddSingleton<App>();
            services.AddSingleton<MainMenu>();
        });
}

static void BuildConfig(IConfigurationBuilder builder)
{
    builder.SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
        .AddJsonFile(string.Format(
                "appsettings.{0}.json",
                Environment.GetEnvironmentVariable("ASPNETCORE_ENVIROMENT") ?? "Production"
            ),
            optional: true
        )
        .AddEnvironmentVariables()
        .AddUserSecrets<Program>();
}