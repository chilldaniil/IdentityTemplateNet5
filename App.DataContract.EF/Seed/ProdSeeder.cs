using System;
using System.Threading.Tasks;

namespace App.DataContract.EF.Seed
{
    public sealed class ProdSeeder : BaseSeeder
    {
        private ProdSeeder()
        {

        }

        public static async Task RunAsync(ApplicationDbContext context, IServiceProvider serviceProvider)
        {
            var adminPassword = "!234Qwer!234Qwer";
            var adminEmail = "admin@test.com";

            await CreateAdminAsync(context, serviceProvider, adminEmail, "Super", "Admin", adminPassword);
        }
    }
}
