using System;
using System.Collections.Generic;

namespace StockMarket.AdminAPI.Models
{
    public partial class Ipo
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string StockExchange { get; set; }
        public int PricePerShare { get; set; }
        public string NoOfShares { get; set; }
        public DateTime OpenDateTime { get; set; }
        public string Remarks { get; set; }
    }
}
