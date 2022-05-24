using System;
using System.Linq;
using App.DataContract.Entities;
using App.DataContract.Entities.Enums;
using App.DataContract.Entities.Identity;

namespace App.DataContract.EF.Seed
{
    public abstract class BaseSeeder
    {
        protected static void CreateAdmin(ApplicationDbContext context, string email, string firstName, string lastName, string passwordHash)
        {
            var admin = new Admin
            {
                Id = Guid.Parse("ACAF036F-11A2-4BA7-A66C-31E7487453A4"),
                Email = email,
                FirstName = firstName,
                LastName = lastName,
                UserName = $"{firstName} {lastName}",
                NormalizedEmail = email.ToUpper(),
                SecurityStamp = Guid.NewGuid().ToString(),
                LockoutEnabled = true,
                PasswordHash = passwordHash
            };

            var role = context.Roles.First(r => r.Name == ApplicationRoles.Admin.ToString());

            var userRole = new ApplicationUserRole()
            {
                UserId = admin.Id,
                RoleId = role.Id
            };

            if (context.Admins.Any(_ => _.Id == admin.Id))
            {
                return;
            }

            context.Admins.Add(admin);
            context.UserRoles.Add(userRole);
        }

        //protected void CreateAgentUser(GroomDbContext context, Agent agent, string email, string hash)
        //{
        //    var domainUser = new AgentUser
        //    {
        //        Id = Guid.NewGuid(),
        //        AgentId = agent.Id,
        //        CreationDate = DateTime.UtcNow
        //    };

        //    CreateUser(context, domainUser, email, hash, GroomRole.Agent);
        //}
    }
}
