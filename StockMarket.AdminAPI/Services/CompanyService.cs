using StockMarket.AdminAPI.Models;
using StockMarket.AdminAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockMarket.AdminAPI.Services
{
    public class CompanyService:ICompanyService
    {
        private ICompanyRepository companyRepo;
        public CompanyService() { }
        public CompanyService(ICompanyRepository _userRepo)
        {
            this.companyRepo = _userRepo;
        }

        //CompanyRepository companyRepo = new CompanyRepository();

        public void AddCompany(Company value)
        {
            companyRepo.AddCompany(value);
        }

        public void DeleteCompany(string id)
        {
            companyRepo.DeleteCompany(id);
        }

        public List<Company> GetAllCompany()
        {
            return companyRepo.GetAllCompany();
        }

        public Company GetCompanyByName(string name)
        {
            return companyRepo.GetCompanyByName(name);
        }

        public void UpdateCompany(Company value)
        {
            companyRepo.UpdateCompany(value);
        }
    }
}
