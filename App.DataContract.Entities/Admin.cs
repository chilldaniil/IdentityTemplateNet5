using System;
using App.DataContract.Contract;
using App.DataContract.Entities.Identity;

namespace App.DataContract.Entities
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
