using System;
using System.Collections.Generic;

#nullable disable

namespace MySqlDotnetCore.Models
{
    public partial class User
    {
        public User()
        {
            Userroles = new HashSet<Userrole>();
        }

        public string Id { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public string PasswordHash { get; set; }
        public string SecurityStamp { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public DateTime? LockoutEndDateUtc { get; set; }
        public bool LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }
        public string UserName { get; set; }

        public virtual ICollection<Userrole> Userroles { get; set; }
    }
}
