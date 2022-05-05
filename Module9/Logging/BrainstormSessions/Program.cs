using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Serilog.Events;
using Serilog;
using System;

namespace BrainstormSessions
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Create the Serilog logger, and configure the sinks   
            Log.Logger = new LoggerConfiguration()
                 .MinimumLevel.Debug()
                 .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
                 .Enrich.FromLogContext()
                 .WriteTo.File("log.txt", rollingInterval: RollingInterval.Day,
                 rollOnFileSizeLimit: true, fileSizeLimitBytes: 123456)
                 .CreateLogger();

            try
            {
                Log.Information("Starting web host");
                CreateHostBuilder(args).Build().Run();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Application start-up failed");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .UseSerilog()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
