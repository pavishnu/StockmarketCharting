using Moq;
using StockMarket.AdminAPI.Models;
using StockMarket.AdminAPI.Repositories;
using StockMarket.AdminAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace StockMarketAPITestMoq
{
    public class AdminAPITest
    {
        private readonly StockExchangeService _service;

        public AdminAPITest()
        {
            var mockRepo = new Mock<IStockExchangeRepository>();
            IList<StockExchange> stockExchange = new List<StockExchange>() {
            new StockExchange(){Id = 1, StockExchangeName = "Nse", Brief = "NSE", ContactAddress = "address", Remarks = "good"},
            new StockExchange(){Id = 2, StockExchangeName = "Nse", Brief = "NSE", ContactAddress = "address", Remarks = "good"},
            new StockExchange(){Id = 3, StockExchangeName = "Nse", Brief = "NSE", ContactAddress = "address", Remarks = "good"},
            new StockExchange(){Id = 4, StockExchangeName = "Nse", Brief = "NSE", ContactAddress = "address", Remarks = "good"},
            new StockExchange(){Id = 5, StockExchangeName = "Nse", Brief = "NSE", ContactAddress = "address", Remarks = "good"},
            };
            mockRepo.Setup(repo => repo.GetAllSE()).Returns(stockExchange.ToList());
            mockRepo.Setup(repo => repo.GetSE(It.IsAny<int>())).Returns((int i) => stockExchange.SingleOrDefault(x => x.Id == i));
            mockRepo.Setup(repo => repo.AddSE(It.IsAny<StockExchange>())).Callback((StockExchange item) =>
            {
                item = new StockExchange() { Id = 6, StockExchangeName = "Nse", Brief = "NSE", ContactAddress = "address", Remarks = "good" };
                stockExchange.Add(item);
            }).Verifiable();
            mockRepo.Setup(repo => repo.DeleteSE(It.IsAny<int>())).Callback((int item) =>
            {
                item = 2;
                stockExchange.Remove(stockExchange.SingleOrDefault(x => x.Id == item));
            }).Verifiable();
            mockRepo.SetupAllProperties();
            _service = new StockExchangeService(mockRepo.Object);
        }

        [Fact]
        public void TestGetUsers()
        {
            //Arrange
            int expected = 5;
            //Act
            var list = _service.GetAllSE();
            //Assert
            Assert.Equal(expected, list.Count);
        }
        [Fact]
        public void TestGetUser()
        {
            //Arrange
            int expected = 1;
            //Act
            StockExchange stockExchange = _service.GetSE(1);
            Assert.Equal(expected, stockExchange.Id);
        }
        [Fact]
        public void TestAddUser()
        {
            StockExchange userdetails = new StockExchange() { Id = 6, StockExchangeName = "Nse", Brief = "NSE", ContactAddress = "address", Remarks = "good" };

            _service.AddSE(userdetails);

            int expected = 6;
            //Act
            StockExchange stockExchange = _service.GetSE(6);
            Assert.Equal(expected, stockExchange.Id);
        }
        [Fact]
        public void TestDeleteProduct()
        {
            int id = 2;

            _service.DeleteSE(id);

            //Act
            StockExchange stockExchange = _service.GetSE(id);
            Assert.Null(stockExchange);
        }

    }
}
