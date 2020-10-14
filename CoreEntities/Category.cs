using System;
using System.Collections.Generic;

namespace CoreEntities
{
    public partial class Category
    {
        public Category()
        {
            Product = new HashSet<Product>();
        }

        public int CatagoryId { get; set; }
        public string Name { get; set; }
        public int? StoreId { get; set; }

        public virtual Store Store { get; set; }
        public virtual ICollection<Product> Product { get; set; }
    }
}
