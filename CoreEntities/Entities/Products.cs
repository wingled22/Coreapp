using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CoreEntities.Entities
{
    public partial class Products
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public string QuantityPerUnit { get; set; }
        [Required]
        public int CategoryId { get; set; }
        [Required]
        public int StoreId { get; set; }
        public int? Available { get; set; }

        public virtual Category Category { get; set; }
        public virtual Store Store { get; set; }
    }
}
