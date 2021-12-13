using Moq;
using StockMarket.AccountAPI.Services;
using StockMarket.UserAPI.Models;
using System;
using System.Collections.Generic;
using System.Text;
using StockMarket.UserAPI.Repositories;
using System.Linq;
using StockMarket.UserAPI.Services;
using Xunit;

namespace StockMarketAPITestMoq
{
    public class UserAPITest
    {
        private readonly StockPriceService _service;

        public UserAPITest()
        {
            var mockRepo = new Mock<IStockPriceRepository>();
            IList<StockPrice> stockPrice = new List<StockPrice>() {
            new StockPrice(){StockId = 1, CompanyCode = "AAA", StockExchange = "NSE", CurrentPrice = 10, Date = Convert.ToDateTime("2019-06-08T00:00:00"), Time = "9:00:00"},
            new StockPrice(){StockId = 2, CompanyCode = "BBB", StockExchange = "NSE", CurrentPrice = 10, Date = Convert.ToDateTime("2019-06-08T00:00:00"), Time = "9:00:00"},
            new StockPrice(){StockId = 3, CompanyCode = "CCC", StockExchange = "NSE", CurrentPrice = 10, Date = Convert.ToDateTime("2019-06-08T00:00:00"), Time = "9:00:00"},
            new StockPrice(){StockId = 4, CompanyCode = "DDD", StockExchange = "NSE", CurrentPrice = 10, Date = Convert.ToDateTime("2019-06-08T00:00:00"), Time = "9:00:00"},
            new StockPrice(){StockId = 5, CompanyCode = "EEE", StockExchange = "NSE", CurrentPrice = 10, Date = Convert.ToDateTime("2019-06-08T00:00:00"), Time = "9:00:00"},
            };
            mockRepo.Setup(repo => repo.GetAllStockPrice()).Returns(stockPrice.ToList());
            mockRepo.Setup(repo => repo.GetStockPriceByName(It.IsAny<string>())).Returns((string i) => stockPrice.SingleOrDefault(x => x.CompanyCode == i));
            mockRepo.Setup(repo => repo.AddStockPrice(It.IsAny<StockPrice>())).Callback((StockPrice item) =>
            {
                item = new StockPrice() { StockId = 6, CompanyCode = "FFF", StockExchange = "NSE", CurrentPrice = 10, Date = Convert.ToDateTime("2019-06-08T00:00:00"), Time = "9:00:00" };
                stockPrice.Add(item);
            }).Verifiable();
            mockRepo.Setup(repo => repo.DeleteStockPrice(It.IsAny<string>())).Callback((string item) =>
            {
                item = "BBB";
                stockPrice.Remove(stockPrice.SingleOrDefault(x => x.CompanyCode == item));
            }).Verifiable();
            mockRepo.SetupAllProperties();
            _service = new StockPriceService(mockRepo.Object);
        }

        [Fact]
        public void TestGetUsers()
        {
            //Arrange
            int expected = 5;
            //Act
            var userlist = _service.GetAllStockPrice();
            //Assert
            Assert.Equal(expected, userlist.Count);
        }
        [Fact]
        public void TestGetUser()
        {
            //Arrange
            string expected = "AAA";
            //Act
            StockPrice stockPrice = _service.GetStockPriceByName("AAA");
            Assert.Equal(expected, stockPrice.CompanyCode);
        }
        [Fact]
        public void TestAddUser()
        {
            StockPrice userdetails = new StockPrice() { StockId = 6, CompanyCode = "FFF", StockExchange = "NSE", CurrentPrice = 10, Date = Convert.ToDateTime("2019-06-08T00:00:00"), Time = "9:00:00" };

            _service.AddStockPrice(userdetails);

            int expected = 6;
            //Act
            StockPrice user = _service.GetStockPriceByName("FFF");
            Assert.Equal(expected, user.StockId);
        }
        [Fact]
        public void TestDeleteProduct()
        {
            string id = "BBB";

            _service.DeleteStockPrice(id);

            //Act
            StockPrice user = _service.GetStockPriceByName(id);
            Assert.Null(user);
        }

    }
}
