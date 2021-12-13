using System;
using System.Collections.Generic;

namespace StockMarket.AdminAPI.Models
{
    public partial class Sectors
    {
        public int Id { get; set; }
        public string SectorName { get; set; }
        public string Brief { get; set; }
    }
}
