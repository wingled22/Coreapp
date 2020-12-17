using System;
using System.Collections.Generic;

namespace CoreApp.Entities
{
    public partial class StocksHistory
    {
        public int Id { get; set; }
        public int? Stock { get; set; }
        public int? AddedStocks { get; set; }
        public DateTime? DateAdded { get; set; }
        public int? UserId { get; set; }
        public int? Store { get; set; }

        public virtual Stocks StockNavigation { get; set; }
        public virtual Store StoreNavigation { get; set; }
        public virtual User User { get; set; }
    }
}
