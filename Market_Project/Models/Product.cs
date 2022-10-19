using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Market_Project.Models
{
    public partial class Product
    {
        public Product()
        {
            ProductOrders = new HashSet<ProductOrder>();
        }

        public decimal Productid { get; set; }
        public string Productname { get; set; }
        public string ImagePath { get; set; }
        public decimal Quntitiy { get; set; }
        public decimal Propricse { get; set; }
        public decimal Prosale { get; set; }
        public decimal Discount { get; set; }
        public string Productdescription { get; set; }
        public decimal Categoryid { get; set; }

        public virtual Category1 Category { get; set; }
        public virtual ICollection<ProductOrder> ProductOrders { get; set; }
        [NotMapped]
        public virtual IFormFile ImageFile { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}

