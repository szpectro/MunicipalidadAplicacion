﻿using System;
using System.Collections.Generic;

#nullable disable

namespace MySqlDotnetCore.Models
{
    public partial class Userrole
    {
        public string UserId { get; set; }
        public string RoleId { get; set; }

        public virtual Role Role { get; set; }
        public virtual User User { get; set; }
    }
}
