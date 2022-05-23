using System;
using Microsoft.AspNetCore.Identity;

namespace App.DataContract.Entities.Identity
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
