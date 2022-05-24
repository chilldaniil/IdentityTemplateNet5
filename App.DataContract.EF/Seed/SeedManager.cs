using System;

namespace App.DataContract.EF.Seed
{
    public static class SeedManager
    {
        public static void RunSeed(this ApplicationDbContext context)
        {
            try
            {
                var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

                if (string.Equals(environment, "development", StringComparison.InvariantCultureIgnoreCase))
                {
                    DevSeeder.Run(context);
                }
                if (string.Equals(environment, "test", StringComparison.InvariantCultureIgnoreCase))
                {
                    TestSeeder.Run(context);
                }
                if (string.Equals(environment, "production", StringComparison.InvariantCultureIgnoreCase))
                {
                    ProdSeeder.Run(context);
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
