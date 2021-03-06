using System;
using Microsoft.AspNetCore.Identity;

namespace App.DataContract.Entities.Identity
{
    public class ApplicationUserLogin : IdentityUserLogin<Guid>
    {
        public virtual ApplicationUser User { get; set; }
    }
}
