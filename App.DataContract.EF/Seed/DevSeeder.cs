using BCryptNet = BCrypt.Net.BCrypt;

namespace App.DataContract.EF.Seed
{
    public sealed class DevSeeder : BaseSeeder
    {
        private DevSeeder()
        {

        }

        public static void Run(ApplicationDbContext context)
        {
            var password = "!234Qwer";
            var passwordHash = BCryptNet.HashPassword(password);
            var adminEmail = "admin@test.com";

            CreateAdmin(context, adminEmail, "Super", "Admin", passwordHash);
        }
    }
}
