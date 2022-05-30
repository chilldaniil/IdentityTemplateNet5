using System;
using App.DataContract.EF.Seed;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace App.DataContract.EF
{
    public static class DatabaseInitializer
    {
        /// <summary>
        /// You can split this into two methods but use database twice - looking overworking :)
        /// </summary>
        public static IHost MigrateAndSeedDatabase(this IHost host)
        {
            using var scope = host.Services.CreateScope();

            var services = scope.ServiceProvider;

            using (var appContext = services.GetRequiredService<ApplicationDbContext>())
            {
                try
                {
                    appContext.Database.Migrate();

                    var configuration = host.Services.GetRequiredService<IConfiguration>();

                    if (string.Equals(configuration.GetSection("AppSettings:RunSeedOnStartup").Value, "true", StringComparison.InvariantCultureIgnoreCase))
                    {
                        appContext.RunSeedAsync(services).Wait();
                    }
                }
                catch
                {
                    throw;
                }
            }

            return host;
        }
    }
}
