using StockMarket.AdminAPI.Models;
using StockMarket.AdminAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockMarket.AdminAPI.Services
{
    public class IpoService : IIpoService
    {
        private IIpoRepository ipoRepo;
        public IpoService() { }
        public IpoService(IIpoRepository _userRepo)
        {
            this.ipoRepo = _userRepo;
        }
        //IpoRepository ipoRepo = new IpoRepository();
        public void AddIpo(Ipo value)
        {
            ipoRepo.AddIpo(value);
        }

        public void DeleteByName(string name)
        {
            ipoRepo.DeleteByName(name);
        }

        public void DeleteIpo(int id)
        {
            ipoRepo.DeleteIpo(id);
        }

        public List<Ipo> GetAllIpo()
        {
            return ipoRepo.GetAllIpo();
        }

        public Ipo GetIpoById(int id)
        {
            return ipoRepo.GetIpoById(id);
        }

        public Ipo GetIpoByName(string name)
        {
            return ipoRepo.GetIpoByName(name);
        }

        public void UpdateIpo(Ipo value)
        {
            ipoRepo.UpdateIpo(value);
        }
    }
}
