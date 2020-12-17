using System;
using System.Collections.Generic;

namespace CoreApp.Entities
{
    public partial class Products
    {
        public Products()
        {
            Stocks = new HashSet<Stocks>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string QuantityPerUnit { get; set; }
        public int Category { get; set; }
        public int Store { get; set; }
        public int? Available { get; set; }
        public int? UserId { get; set; }

        public virtual Category CategoryNavigation { get; set; }
        public virtual Store StoreNavigation { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Stocks> Stocks { get; set; }
    }
}
