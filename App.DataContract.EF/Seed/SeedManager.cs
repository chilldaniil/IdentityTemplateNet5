using System;
using System.Threading.Tasks;

namespace App.DataContract.EF.Seed
{
    public static class SeedManager
    {
        public static async Task RunSeedAsync(this ApplicationDbContext context, IServiceProvider serviceProvider)
        {
            try
            {
                var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

                if (string.Equals(environment, "development", StringComparison.InvariantCultureIgnoreCase))
                {
                    await DevSeeder.RunAsync(context, serviceProvider);
                }
                if (string.Equals(environment, "test", StringComparison.InvariantCultureIgnoreCase))
                {
                    await TestSeeder.RunAsync(context, serviceProvider);
                }
                if (string.Equals(environment, "production", StringComparison.InvariantCultureIgnoreCase))
                {
                    await ProdSeeder.RunAsync(context, serviceProvider);
                }

                await context.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }
    }
}
