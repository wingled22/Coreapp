﻿using System;
using System.Collections.Generic;

namespace CoreApp.Models
{
    public partial class Store
    {
        public Store()
        {
            Category = new HashSet<Category>();
        }

        public int StoreId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string Photo { get; set; }

        public virtual ICollection<Category> Category { get; set; }
    }
}
