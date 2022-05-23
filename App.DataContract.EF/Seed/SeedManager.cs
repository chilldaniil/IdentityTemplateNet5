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
                    var seeder = new DevSeeder();
                    seeder.Run(context);
                }
                if (string.Equals(environment, "test", StringComparison.InvariantCultureIgnoreCase))
                {
                    var seeder = new TestSeeder();
                    seeder.Run(context);
                }
                if (string.Equals(environment, "production", StringComparison.InvariantCultureIgnoreCase))
                {
                    var seeder = new ProdSeeder();
                    seeder.Run(context);
                }

                context.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
    }
}
