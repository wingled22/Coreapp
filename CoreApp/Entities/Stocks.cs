using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CoreApp.Entities
{
    public partial class Stocks
    {
        public int Id { get; set; }
        [Required]
        public int ProductId { get; set; }
        [Required]
        public int TotalStocks { get; set; }

        public virtual Products Product { get; set; }
    }
}
