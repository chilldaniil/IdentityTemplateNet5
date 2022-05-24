using System;
using Microsoft.AspNetCore.Identity;

namespace App.DataContract.Entities.Identity
{
    public class ApplicationRoleClaim : IdentityRoleClaim<Guid>
    {
        public virtual ApplicationRole Role { get; set; }
    }
}
