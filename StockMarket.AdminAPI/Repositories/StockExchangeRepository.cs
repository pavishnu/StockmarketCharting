using StockMarket.AdminAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockMarket.AdminAPI.Repositories
{
    public class StockExchangeRepository : IStockExchangeRepository
    {
        StockMarketDBContext db = new StockMarketDBContext();
        public void AddSE(StockExchange value)
        {
            db.StockExchange.Add(value);
            db.SaveChanges();
        }

        public void DeleteSE(int id)
        {
            db.StockExchange.Remove(db.StockExchange.Find(id));
            db.SaveChanges();
        }

        public void DeleteSEByName(string name)
        {
            db.StockExchange.Remove(db.StockExchange.SingleOrDefault(c => c.StockExchangeName == name));
        }

        public List<StockExchange> GetAllSE()
        {
            return db.StockExchange.ToList();
        }

        public StockExchange GetSE(int id)
        {
            return db.StockExchange.Find(id);
        }

        public StockExchange GetSEByName(string name)
        {
            return db.StockExchange.SingleOrDefault(c => c.StockExchangeName == name);
        }

        public void UpdateSE(StockExchange value)
        {
            db.StockExchange.Update(value);
            db.SaveChanges();
        }
    }
}
