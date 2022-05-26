using System;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using App.DataContract.Contract;
using App.DataContract.Entities;
using App.DataContract.Entities.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace App.DataContract.EF
{
    public class ApplicationDbContext : IdentityDbContext<
        ApplicationUser, ApplicationRole, Guid,
        ApplicationUserClaim, ApplicationUserRole, ApplicationUserLogin,
        ApplicationRoleClaim, ApplicationUserToken>
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContextOptions)
            : base(dbContextOptions)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        private void UpdateEntitiesWithVersion()
        {
            foreach (var dbEntityEntry in ChangeTracker.Entries<IHaveVersion>())
            {
                dbEntityEntry.Entity.Version = dbEntityEntry.Entity.Version + 1;
                dbEntityEntry.Entity.Modified = DateTime.UtcNow;
                if (dbEntityEntry.State == EntityState.Added)
                {
                    dbEntityEntry.Entity.Created = DateTime.UtcNow;
                }
            }
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            UpdateEntitiesWithVersion();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            UpdateEntitiesWithVersion();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        public DbSet<Admin> Admins { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }
}