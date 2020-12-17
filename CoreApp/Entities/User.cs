using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CoreApp.Entities
{
    public partial class User
    {
        public User()
        {
            Category = new HashSet<Category>();
            Products = new HashSet<Products>();
            Stocks = new HashSet<Stocks>();
            StocksHistory = new HashSet<StocksHistory>();
            Store = new HashSet<Store>();
        }

        public int Id { get; set; }
        [Required]
        public string Firstname { get; set; }
        [Required]
        public string Lastname { get; set; }
      
        public string Gender { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public int UserType { get; set; }

        public virtual UserType UserTypeNavigation { get; set; }
        public virtual ICollection<Category> Category { get; set; }
        public virtual ICollection<Products> Products { get; set; }
        public virtual ICollection<Stocks> Stocks { get; set; }
        public virtual ICollection<StocksHistory> StocksHistory { get; set; }
        public virtual ICollection<Store> Store { get; set; }
    }
}
