using StockMarket.AdminAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockMarket.AdminAPI.Repositories
{
    public class StockPriceRepository : IStockPriceRepository
    {
        StockMarketDBContext db = new StockMarketDBContext();
        public void AddStockPrice(StockPrice value)
        {
            db.StockPrice.Add(value);
            db.SaveChanges();
        }

        public void DeleteStockPrice(string name)
        {
            db.StockPrice.Remove(db.StockPrice.Find(name));
            db.SaveChanges();
        }

        public List<StockPrice> GetAllStockPrice()
        {
            return db.StockPrice.ToList();
        }

        public StockPrice GetStockPriceByName(string name)
        {
            return db.StockPrice.Find(name);
        }

        public void UpdateStockPrice(StockPrice value)
        {
            db.StockPrice.Update(value);
            db.SaveChanges();
        }
    }
}
