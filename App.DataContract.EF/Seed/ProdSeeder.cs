namespace App.DataContract.EF.Seed
{
    public sealed class ProdSeeder : BaseSeeder
    {
        public void Run(ApplicationDbContext context)
        {
            SeedRoles(context);
        }
    }
}
