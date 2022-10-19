using System;
using System.Collections.Generic;

#nullable disable

namespace Market_Project.Models
{
    public partial class Payment
    {
        public decimal Paymentid { get; set; }
        public decimal Status { get; set; }
        public decimal Orderid { get; set; }

        public virtual Order1 Order { get; set; }
    }
}
