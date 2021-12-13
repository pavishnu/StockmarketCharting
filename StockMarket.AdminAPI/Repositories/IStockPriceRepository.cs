using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StockMarket.AdminAPI.Models;

namespace StockMarket.AdminAPI.Repositories
{
    public interface IStockPriceRepository
    {
        public void AddStockPrice(StockPrice value);
        public void DeleteStockPrice(string name);
        public void UpdateStockPrice(StockPrice value);
        public StockPrice GetStockPriceByName(string name);
        public List<StockPrice> GetAllStockPrice();
    }
}
