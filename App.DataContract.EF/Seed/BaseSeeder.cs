using System.Linq;
using App.DataContract.Entities.Enums;
using App.DataContract.Entities.Identity;

namespace App.DataContract.EF.Seed
{
    public abstract class BaseSeeder
    {
        protected void SeedRoles(ApplicationDbContext context)
        {
            if (!context.Roles.Any(r => r.Name == AppRoleTypes.Admin.ToString()))
            {
                context.Roles.Add(new ApplicationRole(AppRoleTypes.Admin.ToString()));
            }
            if (!context.Roles.Any(r => r.Name == AppRoleTypes.User.ToString()))
            {
                context.Roles.Add(new ApplicationRole(AppRoleTypes.User.ToString()));
            }
        }
    }
}
