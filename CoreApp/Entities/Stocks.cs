using System;
using System.Collections.Generic;

namespace CoreApp.Entities
{
    public partial class Stocks
    {
        public Stocks()
        {
            StocksHistory = new HashSet<StocksHistory>();
        }

        public int Id { get; set; }
        public int Product { get; set; }
        public int TotalStocks { get; set; }
        public int Store { get; set; }
        public int? UserId { get; set; }

        public virtual Products ProductNavigation { get; set; }
        public virtual Store StoreNavigation { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<StocksHistory> StocksHistory { get; set; }
    }
}
