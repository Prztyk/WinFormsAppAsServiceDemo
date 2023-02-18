using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace WinFormsAppAsService1
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            var host = Host.CreateDefaultBuilder()
                     .ConfigureAppConfiguration((context, builder) =>
                     {
                         // Add other configuration files...
                         builder.AddJsonFile("appsettings.local.json", optional: true);
                     })
                     .ConfigureServices((context, services) =>
                     {
                         ConfigureServices(context.Configuration, services);
                     })
                     .ConfigureLogging(logging =>
                     {
                         // Add other loggers...
                     })
                     .Build();

            var services = host.Services;
            var mainForm = services.GetRequiredService<MainForm>();
            Application.Run(mainForm);
        }

        private static void ConfigureServices(
            IConfiguration configuration,
            IServiceCollection services)
        {
            services.Configure<AppSettings>(configuration.GetSection(nameof(AppSettings)));
            services.AddScoped<IDateService, DateService>();
            // ...
            services.AddSingleton<MainForm>();
        }

    }
}