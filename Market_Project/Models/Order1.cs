using System;
using System.Collections.Generic;

#nullable disable

namespace Market_Project.Models
{
    public partial class Order1
    {
        public Order1()
        {
            Payments = new HashSet<Payment>();
            ProductOrders = new HashSet<ProductOrder>();
        }

        public decimal OrderId { get; set; }
        public DateTime? Datee { get; set; }
        public decimal? Total { get; set; }
        public decimal? UserId { get; set; }

        public virtual User1 User { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
        public virtual ICollection<ProductOrder> ProductOrders { get; set; }
    }
}
