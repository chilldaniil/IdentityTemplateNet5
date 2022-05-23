namespace App.DataContract.EF.Seed
{
    public sealed class DevSeeder : BaseSeeder
    {
        public void Run(ApplicationDbContext context)
        {
            SeedRoles(context);
        }
    }
}
