using App.DataContract.EF.Seed;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace App.DataContract.EF
{
    public static class DatabaseInitializer
    {
        public static IHost MigrateAndSeedDatabase(this IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                using (var appContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>())
                {
                    try
                    {
                        appContext.Database.Migrate();
                        appContext.RunSeed();
                    }
                    catch
                    {
                        throw;
                    }
                }
            }
            return host;
        }
    }
}
