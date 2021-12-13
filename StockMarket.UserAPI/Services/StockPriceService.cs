using StockMarket.UserAPI.Models;
using StockMarket.UserAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockMarket.UserAPI.Services
{
    public class StockPriceService : IStockPriceService
    {
        private IStockPriceRepository stockRepo;
        public StockPriceService() { }
        public StockPriceService(IStockPriceRepository _userRepo)
        {
            this.stockRepo = _userRepo;
        }
        //StockPriceRepository stockRepo = new StockPriceRepository();
        public void AddStockPrice(StockPrice value)
        {
            stockRepo.AddStockPrice(value);
        }

        public void DeleteStockPrice(string name)
        {
            stockRepo.DeleteStockPrice(name);
        }

        public List<StockPrice> GetAllStockPrice()
        {
            return stockRepo.GetAllStockPrice();
        }

        public StockPrice GetStockPriceByName(string name)
        {
            return stockRepo.GetStockPriceByName(name);
        }

        public void UpdateStockPrice(StockPrice value)
        {
            stockRepo.UpdateStockPrice(value);
        }
        public List<StockPrice> GetStockPrices(string cname)
        {
            return stockRepo.GetStockPrices(cname);
        }
    }
}
