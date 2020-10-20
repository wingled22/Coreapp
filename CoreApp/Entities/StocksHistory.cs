using System;
using System.Collections.Generic;

namespace CoreApp.Entities
{
    public partial class StocksHistory
    {
        public int Id { get; set; }
        public int? StockId { get; set; }
        public int? AddedStocks { get; set; }
        public DateTime? DateAdded { get; set; }
    }
}
