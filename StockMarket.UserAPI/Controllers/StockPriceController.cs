using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StockMarket.UserAPI.Models;
using StockMarket.UserAPI.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StockMarket.UserAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize()]
    public class StockPriceController : ControllerBase
    {
        IStockPriceService stockService;
        public StockPriceController(IStockPriceService _service)
        {
            stockService = _service;
        }
        //StockPriceService stockService = new StockPriceService();
        [HttpGet]
        [Route("GetAllStockPrice")]
        public IActionResult GetAllStockPrice()
        {
            return Ok(stockService.GetAllStockPrice());
        }

        // GET by ID StockPrice
        [HttpGet]
        [Route("GetStockPrices/{cname}")]
        public IActionResult GetStockPrices(string cname)
        {
            var o= stockService.GetStockPrices(cname);
            if (o == null)
            {
                return NotFound("Data not present for this company");
            }
            return Ok(o);
        }

        // POST Add StockPrice
        [HttpPost]
        [Route("AddStockPrice")]
        public IActionResult AddStockPrice(StockPrice value)
        {
            stockService.AddStockPrice(value);
            return Ok("Record Added Successfully");
        }

        // PUT Update StockPrice
        [HttpPut]
        [Route("UpdateStockPrice")]
        public IActionResult UpdateStockPrice(StockPrice value)
        {
            stockService.UpdateStockPrice(value);
            return Ok("Record Updated");
        }

        // DELETE StockPrice
        [HttpDelete]
        [Route("DeleteStockPrice/{name}")]
        public IActionResult DeleteStockPrice(string name)
        {
            stockService.DeleteStockPrice(name);
            return Ok("Record Deleted");
        }
    }
}
