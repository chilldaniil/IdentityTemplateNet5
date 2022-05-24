using System;
using System.Collections.Generic;
using App.DataContract.Entities.Enums;
using App.DataContract.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.DataContract.EF.Configurations
{
    public class ApplicationRoleConfigurations : IEntityTypeConfiguration<ApplicationRole>
    {
        public void Configure(EntityTypeBuilder<ApplicationRole> builder)
        {
            builder.ToTable("AspNetRoles");

            // Each Role can have many entries in the UserRole join table
            builder.HasMany(e => e.UserRoles)
                .WithOne(e => e.Role)
                .HasForeignKey(ur => ur.RoleId)
                .IsRequired();

            builder.HasData(
                new List<ApplicationRole>()
                { 
                    new ApplicationRole() 
                    {
                        Id = Guid.Parse("E0F803E3-5277-4F66-812B-85A4BF6836B7"),
                        Name = ApplicationRoles.Admin.ToString(),
                        NormalizedName = ApplicationRoles.Admin.ToString().ToUpper() 
                    },
                    new ApplicationRole()
                    {
                        Id = Guid.Parse("90F6DE07-03FE-4457-862C-1077987DE3F3"),
                        Name = ApplicationRoles.Customer.ToString(),
                        NormalizedName = ApplicationRoles.Customer.ToString().ToUpper()
                    }
                });

        }
    }
}
