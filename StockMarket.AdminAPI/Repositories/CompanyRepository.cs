using StockMarket.AdminAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockMarket.AdminAPI.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        StockMarketDBContext db = new StockMarketDBContext();
        public void AddCompany(Company value)
        {
            db.Company.Add(value);
            db.SaveChanges();
        }

        public void DeleteCompany(string name)
        {
            db.Company.Remove(db.Company.Find(name));
            db.SaveChanges();
        }

        public List<Company> GetAllCompany()
        {
            return db.Company.ToList();
        }

        public Company GetCompanyByName(string name)
        {
            return db.Company.Find(name);
        }

        public void UpdateCompany(Company value)
        {
            db.Company.Update(value);
            db.SaveChanges();
        }
    }
}
