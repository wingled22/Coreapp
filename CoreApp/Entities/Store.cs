﻿using System;
using System.Collections.Generic;

namespace CoreApp.Entities
{
    public partial class Store
    {
        public Store()
        {
            Category = new HashSet<Category>();
            Products = new HashSet<Products>();
            Stocks = new HashSet<Stocks>();
            StocksHistory = new HashSet<StocksHistory>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string Photo { get; set; }
        public int? UserId { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<Category> Category { get; set; }
        public virtual ICollection<Products> Products { get; set; }
        public virtual ICollection<Stocks> Stocks { get; set; }
        public virtual ICollection<StocksHistory> StocksHistory { get; set; }
    }
}
