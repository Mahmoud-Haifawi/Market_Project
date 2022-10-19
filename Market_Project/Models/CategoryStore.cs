using System;
using System.Collections.Generic;

#nullable disable

namespace Market_Project.Models
{
    public partial class CategoryStore
    {
        public decimal CategoryStore1 { get; set; }
        public decimal? StoreId { get; set; }
        public decimal? CatId { get; set; }

        public virtual Category1 Cat { get; set; }
        public virtual Store1 Store { get; set; }
    }
}
