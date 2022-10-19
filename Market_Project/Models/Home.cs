using System;
using System.Collections.Generic;

#nullable disable

namespace Market_Project.Models
{
    public partial class Home
    {
        public Home()
        {
            User1s = new HashSet<User1>();
        }

        public decimal Homeid { get; set; }
        public string Email { get; set; }
        public string Freeshippinglimit { get; set; }
        public string Phonenumber { get; set; }
        public string Supportworktime { get; set; }
        public string Logoimg { get; set; }
        public string Homeimg { get; set; }
        public string Address { get; set; }

        public virtual ICollection<User1> User1s { get; set; }
    }
}
