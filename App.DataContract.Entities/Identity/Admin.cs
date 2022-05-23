using System;
using App.DataContract.Contract;

namespace App.DataContract.Entities.Identity
{
    public class Admin : ApplicationUser, IAggregateRoot
    {
        public string Phone { get; set; }
        public bool IsDeleted { get; set; }
        public int Version { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
    }
}
