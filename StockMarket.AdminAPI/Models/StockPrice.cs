using System;
using System.Collections.Generic;

namespace StockMarket.AdminAPI.Models
{
    public partial class StockPrice
    {
        public int StockId { get; set; }
        public string CompanyCode { get; set; }
        public string StockExchange { get; set; }
        public decimal CurrentPrice { get; set; }
        public DateTime Date { get; set; }
        public string Time { get; set; }
    }
}
