using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApp.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public int StoreId { get; set; }
        public Store Store { get; set; }

    }
}
