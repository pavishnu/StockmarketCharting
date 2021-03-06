using StockMarket.AdminAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockMarket.AdminAPI.Services
{
    public interface IStockExchangeService
    {
        public void AddSE(StockExchange value);
        public void DeleteSE(int id);
        public void DeleteSEByName(string name);
        public void UpdateSE(StockExchange value);
        public List<StockExchange> GetAllSE();
        public StockExchange GetSE(int id);
        public StockExchange GetSEByName(string name);
    }
}
