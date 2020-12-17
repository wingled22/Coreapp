using System;
using System.Collections.Generic;

namespace CoreApp.Entities
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
        public int? UserId { get; set; }
        public int? Store { get; set; }

        public virtual Store StoreNavigation { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Products> Products { get; set; }
    }
}
