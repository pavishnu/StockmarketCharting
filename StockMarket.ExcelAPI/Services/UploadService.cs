using StockMarket.ExcelAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockMarket.ExcelAPI.Services
{
    public class UploadService
    {
        UploadRepository repository = new UploadRepository();
        public void UploadData(string path)
        {
            repository.ImportStockPrice(path);
        }
        public void ExportData(string path)
        {
            repository.ExportStockPrice(path);
        }
    }
}
