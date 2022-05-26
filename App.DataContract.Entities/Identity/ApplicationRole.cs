using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace App.DataContract.Entities.Identity
{
    public class ApplicationRole : IdentityRole<Guid>
    {
        public ApplicationRole()
        {

        }

        public ApplicationRole(string name)
        {
            this.Name = name;
        }

        public virtual ICollection<ApplicationUserRole> UserRoles { get; set; }
        public virtual ICollection<ApplicationRoleClaim> RoleClaims { get; set; }
    }
}
