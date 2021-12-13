using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Data.OleDb;
using System.Data;
using StockMarket.ExcelAPI.Models;
using OfficeOpenXml;
using Microsoft.AspNetCore.Hosting;

namespace StockMarket.ExcelAPI.Repositories
{
    public class UploadRepository : IUploadRepository
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        StockMarketDBContext _db = new StockMarketDBContext();
        
        public IList<StockPrice> ImportStockPrice(string filePath)
        {

            FileInfo file = new FileInfo(filePath);
            string fileName = file.Name;
            using (ExcelPackage package = new ExcelPackage(file))
            {
                ExcelWorksheet workSheet = package.Workbook.Worksheets["Sheet1"];
                int totalRows = workSheet.Dimension.Rows;

                List<StockPrice> stockPrices = new List<StockPrice>();

                for (int i = 2; i <= totalRows; i++)
                { 
                    stockPrices.Add(new StockPrice
                    {
                        CompanyCode = workSheet.Cells[i, 1].Value.ToString(),
                        StockExchange = workSheet.Cells[i, 2].Value.ToString(),
                        CurrentPrice = Convert.ToDecimal(workSheet.Cells[i, 3].Value.ToString()),
                        Date = Convert.ToDateTime(workSheet.Cells[i, 4].Value.ToString()),
                        Time = workSheet.Cells[i, 5].Value.ToString(),
                    });
                }

                _db.StockPrice.AddRange(stockPrices);
                _db.SaveChanges();

                return stockPrices;
            }
        }

        
        public string ExportStockPrice(string filePath)
        { 
            FileInfo file = new FileInfo(filePath);
            string fileName = file.Name;
            using (ExcelPackage package = new ExcelPackage(file))
            {
                IList<StockPrice> stockPriceList = _db.StockPrice.ToList();

                ExcelWorksheet workSheet = package.Workbook.Worksheets["Sheet1"];
                int totalRows = stockPriceList.Count();

                workSheet.Cells[1, 1].Value = "Company Code";
                workSheet.Cells[1, 2].Value = "Stock Exchange";
                workSheet.Cells[1, 3].Value = "Price Per Share";
                workSheet.Cells[1, 4].Value = "Date";
                workSheet.Cells[1, 5].Value = "Time";

                List<StockPrice> stockPrices = new List<StockPrice>();

                for (int i = 2; i <= totalRows+1; i++)
                {
                    workSheet.Cells[i, 1].Value = stockPriceList[i-2].CompanyCode;
                    workSheet.Cells[i, 2].Value = stockPriceList[i-2].StockExchange;
                    workSheet.Cells[i, 3].Value = stockPriceList[i-2].CurrentPrice;
                    workSheet.Cells[i, 4].Value = stockPriceList[i-2].Date;
                    workSheet.Cells[i, 5].Value = stockPriceList[i-2].Time;
                }

                package.Save();

            }
            return "Stock Price Exported Successfully";

        }
    }
}
