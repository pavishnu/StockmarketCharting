using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StockMarket.AdminAPI.Models;

namespace StockMarket.AdminAPI.Repositories
{
    public class IpoRepository : IIpoRepository
    {
        StockMarketDBContext db = new StockMarketDBContext();
        public void AddIpo(Ipo value)
        {
            db.Ipo.Add(value);
            db.SaveChanges();
        }

        public void DeleteByName(string name)
        {
            db.Ipo.Remove(db.Ipo.SingleOrDefault(c => c.CompanyName == name));
            db.SaveChanges();
        }

        public void DeleteIpo(int id)
        {
            db.Ipo.Remove(db.Ipo.Find(id));
            db.SaveChanges();
        }

        public List<Ipo> GetAllIpo()
        {
            return db.Ipo.ToList();
        }

        public Ipo GetIpoById(int id)
        {
            return db.Ipo.Find(id);
        }

        public Ipo GetIpoByName(string name)
        {
            return db.Ipo.SingleOrDefault(c => c.CompanyName == name);
        }

        public void UpdateIpo(Ipo value)
        {
            db.Ipo.Update(value);
            db.SaveChanges();
        }
    }
}
