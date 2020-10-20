using System;
using System.Collections.Generic;

namespace CoreApp.Entities
{
    public partial class Products
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string QuantityPerUnit { get; set; }
        public int CategoryId { get; set; }
        public int StoreId { get; set; }
        public int? Available { get; set; }

        public virtual Category Category { get; set; }
        public virtual Store Store { get; set; }
    }
}
