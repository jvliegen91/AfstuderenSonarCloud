using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Afstuderen2020.Data;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Afstuderen2020
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = BuildWebHost(args);
                RunSeeding(host);
                host.Run();
        }

        private static void RunSeeding(IWebHost host)
        {
            var scopeFactory = host.Services.GetService<IServiceScopeFactory>();

            using (var scope = scopeFactory.CreateScope())
            {
                var seeder = scope.ServiceProvider.GetService<Afstuderen2020Seeder>();
                seeder.Seed();
            }
            
        }

        private static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                    .ConfigureAppConfiguration(SetupConfiguration)
            .UseStartup<Startup>()
            .Build();

        private static void SetupConfiguration(WebHostBuilderContext ctx, IConfigurationBuilder builder)
        {
            builder.Sources.Clear();
            builder.AddJsonFile("configuration.json", false, true)
                .AddEnvironmentVariables();
        }
    }
}
