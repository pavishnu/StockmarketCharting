using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StockMarket.AdminAPI.Models;
using StockMarket.AdminAPI.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StockMarket.AdminAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize()]
    public class IpoController : ControllerBase
    {
        IIpoService ipoService;
        public IpoController(IIpoService _service)
        {
            ipoService = _service;
        }
        //IpoService ipoService = new IpoService();
        // GET All Ipo
        [HttpGet]
        [Route("GetAllIpo")]
        public IActionResult GetAllIpo()
        {
            return Ok(ipoService.GetAllIpo());
        }

        // GET by ID Ipo
        [HttpGet]
        [Route("GetIpoById/{id}")]
        public IActionResult GetIpoById(int id)
        {
            return Ok(ipoService.GetIpoById(id));
        }

        [HttpGet]
        [Route("GetIpo/{name}")]
        public IActionResult GetIpoByName(string name)
        {
            return Ok(ipoService.GetIpoByName(name));
        }



        // POST Add Ipo
        [HttpPost]
        [Route("AddIpo")]
        public IActionResult AddUser(Ipo value)
        {
            ipoService.AddIpo(value);
            return Ok("Record Added Successfully");
        }

        // PUT Update Ipo
        [HttpPut]
        [Route("UpdateIpo")]
        public IActionResult UpdateUser(Ipo value)
        {
            ipoService.UpdateIpo(value);
            return Ok("Record Updated");
        }

        // DELETE Data
        [HttpDelete]
        [Route("DeleteIpo/{id}")]
        public IActionResult DeleteUser(string id)
        {

            ipoService.DeleteIpo(Int32.Parse(id));
            return Ok("Record Deleted");
        }

        // DELETE Data
        [HttpDelete]
        [Route("DeleteIpoByName/{name}")]
        public IActionResult DeleteUserByName(string name)
        {
            ipoService.DeleteByName(name);
            return Ok("Record Deleted");
        }
    }
}
