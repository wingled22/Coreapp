using System;
using System.Collections.Generic;

namespace CoreApp.Models
{
    public partial class Category
    {
        public Category()
        {
            Products = new HashSet<Products>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Products> Products { get; set; }
    }
}
