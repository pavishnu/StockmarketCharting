using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StockMarket.AdminAPI.Models;

namespace StockMarket.AdminAPI.Services
{
    public interface IIpoService
    {
        public void AddIpo(Ipo value);
        public void DeleteIpo(int id);
        public void DeleteByName(string name);
        public void UpdateIpo(Ipo value);
        public List<Ipo> GetAllIpo();
        public Ipo GetIpoByName(string name);
        public Ipo GetIpoById(int id);
    }
}
