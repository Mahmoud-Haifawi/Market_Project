using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Market_Project.Models
{
    public partial class User1
    {
        public User1()
        {
            Order1s = new HashSet<Order1>();
            Testimonials = new HashSet<Testimonial>();
        }

        public decimal Userid { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ImagePath { get; set; }
        public decimal Roleid { get; set; }
        public decimal? Homeid { get; set; }

        public virtual Home Home { get; set; }
        public virtual Role1 Role { get; set; }
        public virtual ICollection<Order1> Order1s { get; set; }
        public virtual ICollection<Testimonial> Testimonials { get; set; }
       
[NotMapped]
        public virtual IFormFile ImageFile { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}

