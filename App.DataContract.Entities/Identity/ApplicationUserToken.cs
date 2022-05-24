using System;
using Microsoft.AspNetCore.Identity;

namespace App.DataContract.Entities.Identity
{
    public class ApplicationUserToken : IdentityUserToken<Guid>
    {
        public virtual ApplicationUser User { get; set; }
    }
}
