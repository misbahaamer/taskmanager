using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task.API.Extensions;
using Task.Infrastructure.Persistance;
using Microsoft.Extensions.DependencyInjection;

namespace Task.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args)
                .Build()
                .MigrateDatabase<TaskContext>((context, services) =>
                {
                    var logger = services.GetService<ILogger<TaskContextSeed>>();
                    TaskContextSeed
                        .SeedAsync(context, logger)
                        .Wait();
                })
                .Run();

        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
