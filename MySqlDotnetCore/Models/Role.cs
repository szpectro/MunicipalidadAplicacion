using System;
using System.Collections.Generic;

#nullable disable

namespace MySqlDotnetCore.Models
{
    public partial class Role
    {
        public Role()
        {
            Userroles = new HashSet<Userrole>();
        }

        public string Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Userrole> Userroles { get; set; }
    }
}
