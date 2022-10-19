using System;
using System.Collections.Generic;

#nullable disable

namespace Market_Project.Models
{
    public partial class ProductOrder
    {
        public decimal ProductOrderId { get; set; }
        public decimal Proid { get; set; }
        public decimal Orderid { get; set; }

        public virtual Order1 Order { get; set; }
        public virtual Product Pro { get; set; }
    }
}
