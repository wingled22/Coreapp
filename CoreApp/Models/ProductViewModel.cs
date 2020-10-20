using CoreApp.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApp.Models
{
    public class ProductViewModel
    {
        [Required]
        public int Id { get; set; }
   
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string QuantityPerUnit { get; set; }
        public int CategoryId { get; set; }
        public int StoreId { get; set; }
        public int? Available { get; set; }
        public int StockId { get; set; }
        public int TotalStocks { get; set; }
        [Required]
        public int StocksToAdd { get; set; }

        public virtual Products Product { get; set; }
        public virtual Category Category { get; set; }
        public virtual Store Store { get; set; }
    }
}
