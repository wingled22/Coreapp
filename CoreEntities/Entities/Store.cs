using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CoreEntities.Entities
{
    public partial class Store
    {
        public Store()
        {
            Products = new HashSet<Products>();
        }

        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Address { get; set; }
        public string Photo { get; set; }

        public virtual ICollection<Products> Products { get; set; }
    }
}
