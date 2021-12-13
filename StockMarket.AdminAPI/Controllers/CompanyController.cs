using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StockMarket.AdminAPI.Services;
using StockMarket.AdminAPI.Models;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StockMarket.AdminAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize()]
    public class CompanyController : ControllerBase
    {
        ICompanyService companyService;
        public CompanyController(ICompanyService _service)
        {
            companyService = _service;
        }
        //CompanyService companyService = new CompanyService();
        // GET: api/<CompanyController>
        // GET All Users
        [HttpGet]
        [Route("GetAllCompany")]
        public IActionResult GetAllCompany()
        {
            return Ok(companyService.GetAllCompany());
        }

        // GET by ID user
        [HttpGet]
        [Route("GetCompany/{name}")]
        public IActionResult GetCompanyByName(string name)
        {
            return Ok(companyService.GetCompanyByName(name));
        }

        // POST Add user
        [HttpPost]
        [Route("AddCompany")]
        public IActionResult AddUser(Company value)
        {
            companyService.AddCompany(value);
            return Ok("Record Added Successfully");
        }

        // PUT Update User
        [HttpPut]
        [Route("UpdateCompany")]
        public IActionResult UpdateCompany(Company value)
        {
            companyService.UpdateCompany(value);
            return Ok("Record Updated");
        }

        // DELETE Data
        [HttpDelete]
        [Route("DeleteCompany/{name}")]
        public IActionResult DeleteCompany(string name)
        {
            companyService.DeleteCompany(name);
            return Ok("Record Deleted");
        }
    }
}
