namespace App.DataContract.EF.Seed
{
    public sealed class TestSeeder : BaseSeeder
    {
        public void Run(ApplicationDbContext context)
        {
            SeedRoles(context);
        }
    }
}
