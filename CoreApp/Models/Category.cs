using System;
using System.Collections.Generic;

namespace CoreApp.Models
{
    public partial class Category
    {
        public int CatagoryId { get; set; }
        public string Name { get; set; }
        public int? StoreId { get; set; }

        public virtual Store Store { get; set; }
    }
}
