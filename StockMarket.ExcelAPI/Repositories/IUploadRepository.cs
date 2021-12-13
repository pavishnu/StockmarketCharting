using StockMarket.ExcelAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockMarket.ExcelAPI.Repositories
{
    public interface IUploadRepository
    {
        public IList<StockPrice> ImportStockPrice(string filePath);
        public string ExportStockPrice(string filePath);
    }
}
