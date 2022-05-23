using Microsoft.AspNetCore.Identity;
using System;

namespace App.DataContract.Entities.Identity
{
    public class ApplicationRole : IdentityRole<Guid>
    {
        public ApplicationRole()
        {

        }

        public ApplicationRole(string roleName)
        {
            this.Name = roleName;
            this.Id = Guid.NewGuid();
        }
    }
}
