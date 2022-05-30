using System;
using System.Threading.Tasks;
using App.DataContract.Entities;
using App.DataContract.Entities.Enums;
using App.DataContract.Entities.Identity;
using App.Identity.Implementation;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace App.DataContract.EF.Seed
{
    public abstract class BaseSeeder
    {
        protected static async Task CreateAdminAsync(ApplicationDbContext context, IServiceProvider serviceProvider, string email, string firstName, string lastName, string password)
        {
            var adminId = await EnsureAdminAsync(serviceProvider, password, email);
            await EnsureRoleAsync(serviceProvider, adminId, ApplicationRoles.Admin.ToString());

            var admin = await context.Admins.FirstOrDefaultAsync(_ => _.Id == adminId);
            admin.FirstName = firstName;
            admin.LastName = lastName;
        }

        protected static async Task CreateCustomerAsync(ApplicationDbContext context, IServiceProvider serviceProvider, string email, string password, string phone)
        {
            var customerId = await EnsureCustomerAsync(serviceProvider, password, email);
            await EnsureRoleAsync(serviceProvider, customerId, ApplicationRoles.Customer.ToString());

            var admin = await context.Customers.FirstOrDefaultAsync(_ => _.Id == customerId);
            admin.Phone = phone;
        }

        private static async Task<Guid> EnsureAdminAsync(IServiceProvider serviceProvider, string password, string email)
        {
            var userManager = serviceProvider.GetService<ApplicationUserManager>();

            var user = await userManager.FindByEmailAsync(email);
            if (user == null)
            {
                user = new Admin
                {
                    UserName = email,
                    NormalizedUserName = email.ToUpper(),
                    Email = email,
                    NormalizedEmail = email.ToUpper(),
                    EmailConfirmed = true,
                    Created = DateTime.UtcNow,
                };
                await userManager.CreateAsync(user, password);
            }

            return user.Id;
        }

        private static async Task<Guid> EnsureCustomerAsync(IServiceProvider serviceProvider, string password, string email)
        {
            var userManager = serviceProvider.GetService<ApplicationUserManager>();

            var user = await userManager.FindByEmailAsync(email);
            if (user == null)
            {
                user = new Customer
                {
                    UserName = email,
                    NormalizedUserName = email.ToUpper(),
                    Email = email,
                    NormalizedEmail = email.ToUpper(),
                    EmailConfirmed = true,
                    Created = DateTime.UtcNow,
                };
                await userManager.CreateAsync(user, password);
            }

            return user.Id;
        }

        private static async Task<IdentityResult> EnsureRoleAsync(IServiceProvider serviceProvider, Guid userId, string role)
        {
            var roleManager = serviceProvider.GetRequiredService<ApplicationRoleManager>();

            if (!await roleManager.RoleExistsAsync(role))
            {
                await roleManager.CreateAsync(new ApplicationRole(role));
            }

            var userManager = serviceProvider.GetService<ApplicationUserManager>();

            var user = await userManager.FindByIdAsync(userId.ToString());

            var identityResult = await userManager.AddToRoleAsync(user, role);

            return identityResult;
        }
    }
}
