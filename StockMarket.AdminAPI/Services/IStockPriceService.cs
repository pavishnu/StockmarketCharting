using StockMarket.AdminAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockMarket.AdminAPI.Services
{
    public interface IStockPriceService
    {
        public void AddStockPrice(StockPrice value);
        public void DeleteStockPrice(string name);
        public void UpdateStockPrice(StockPrice value);
        public StockPrice GetStockPriceByName(string name);
        public List<StockPrice> GetAllStockPrice();
    }
}
