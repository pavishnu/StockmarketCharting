using System;
using System.Collections.Generic;

namespace StockMarket.ExcelAPI.Models
{
    public partial class Company
    {
        public string CompanyName { get; set; }
        public string Turnover { get; set; }
        public string Ceo { get; set; }
        public string BoardOfDirectors { get; set; }
        public string ListedInSe { get; set; }
        public string Sector { get; set; }
        public string Brief { get; set; }
        public string StockCode { get; set; }
    }
}
