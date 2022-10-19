using System;
using System.Collections.Generic;

#nullable disable

namespace Market_Project.Models
{
    public partial class Testimonial
    {
        public string Rating { get; set; }
        public decimal TestId { get; set; }
        public string Message { get; set; }
        public decimal Status { get; set; }
        public decimal Publishdate { get; set; }
        public decimal Userid { get; set; }

        public virtual User1 User { get; set; }
    }
}
