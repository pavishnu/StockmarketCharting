using System;
using System.Collections.Generic;

namespace StockMarket.ExcelAPI.Models
{
    public partial class StockExchange
    {
        public int Id { get; set; }
        public string StockExchangeName { get; set; }
        public string Brief { get; set; }
        public string ContactAddress { get; set; }
        public string Remarks { get; set; }
    }
}
