﻿using System;
using System.Collections.Generic;

namespace CoreEntities
{
    public partial class Product
    {
        public int? ProductId { get; set; }
        public string Name { get; set; }
        public decimal? Price { get; set; }
        public byte[] Description { get; set; }
        public string QuantityPerUnit { get; set; }
        public int? CategoryId { get; set; }

        public virtual Category Category { get; set; }
    }
}
