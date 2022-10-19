using System;
using System.Collections.Generic;

#nullable disable

namespace Market_Project.Models
{
    public partial class Role1
    {
        public Role1()
        {
            User1s = new HashSet<User1>();
        }

        public decimal Roleid { get; set; }
        public string Roletype { get; set; }

        public virtual ICollection<User1> User1s { get; set; }
    }
}
