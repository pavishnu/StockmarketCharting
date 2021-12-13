using StockMarket.AdminAPI.Models;
using StockMarket.AdminAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockMarket.AdminAPI.Services
{
    public class StockExchangeService : IStockExchangeService
    {
        private IStockExchangeRepository seRepo;
        public StockExchangeService() { }
        public StockExchangeService(IStockExchangeRepository _userRepo)
        {
            this.seRepo = _userRepo;
        }
        //StockExchangeRepository seRepo = new StockExchangeRepository();
        public void AddSE(StockExchange value)
        {
            seRepo.AddSE(value);
        }

        public void DeleteSE(int id)
        {
            seRepo.DeleteSE(id);
        }

        public void DeleteSEByName(string name)
        {
            seRepo.DeleteSEByName(name);
        }

        public List<StockExchange> GetAllSE()
        {
            return seRepo.GetAllSE();
        }

        public StockExchange GetSE(int id)
        {
            return seRepo.GetSE(id);
        }

        public StockExchange GetSEByName(string name)
        {
            return seRepo.GetSEByName(name);
        }

        public void UpdateSE(StockExchange value)
        {
            seRepo.UpdateSE(value);
        }
    }
}
