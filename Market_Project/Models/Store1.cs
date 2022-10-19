using System;
using System.Collections.Generic;

#nullable disable

namespace Market_Project.Models
{
    public partial class Store1
    {
        public Store1()
        {
            CategoryStores = new HashSet<CategoryStore>();
        }

        public decimal Storeid { get; set; }
        public string Namestore { get; set; }
        public string Email { get; set; }
        public string Phonenumber { get; set; }
        public string Opentime { get; set; }
        public string Address { get; set; }
        public string ImagePath { get; set; }

        public virtual ICollection<CategoryStore> CategoryStores { get; set; }
    }
}
