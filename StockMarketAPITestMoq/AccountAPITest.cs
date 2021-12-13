using Moq;
using StockMarket.AccountAPI.Models;
using StockMarket.AccountAPI.Repositories;
using StockMarket.AccountAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace StockMarketAPITestMoq
{
    public class AccountAPITest
    {
        private readonly UserService _service;

        public AccountAPITest()
        {
            var mockRepo = new Mock<IUserRepository>();
            IList<Users> users = new List<Users>() {
            new Users(){Id = 1, UserName = "DDD", Password = "DDDDDD", UserType = "User", Email = "DDD@gmail.com", MobileNo = "1234567891", Confirmed = "Yes"},
            new Users(){Id = 2, UserName = "DDD", Password = "DDDDDD", UserType = "User", Email = "DDD@gmail.com", MobileNo = "1234567891", Confirmed = "Yes"},
            new Users(){Id = 3, UserName = "DDD", Password = "DDDDDD", UserType = "User", Email = "DDD@gmail.com", MobileNo = "1234567891", Confirmed = "Yes"},
            new Users(){Id = 4, UserName = "DDD", Password = "DDDDDD", UserType = "User", Email = "DDD@gmail.com", MobileNo = "1234567891", Confirmed = "Yes"},
            new Users(){Id = 5, UserName = "DDD", Password = "DDDDDD", UserType = "User", Email = "DDD@gmail.com", MobileNo = "1234567891", Confirmed = "Yes"},
            };
            mockRepo.Setup(repo => repo.GetAllUser()).Returns(users.ToList());
            mockRepo.Setup(repo => repo.GetUserById(It.IsAny<int>())).Returns((int i) => users.SingleOrDefault(x => x.Id == i));
            mockRepo.Setup(repo => repo.AddUser(It.IsAny<Users>())).Callback((Users item) =>
            {
                item = new Users() { Id = 6, UserName = "DDD", Password = "DDDDDD", UserType = "User", Email = "DDD@gmail.com", MobileNo = "1234567891", Confirmed = "Yes" };
                users.Add(item);
            }).Verifiable();
            mockRepo.Setup(repo => repo.DeleteUser(It.IsAny<int>())).Callback((int item) =>
            {
                item = 5;
                users.Remove(users.SingleOrDefault(x => x.Id == item));
            }).Verifiable();
            mockRepo.SetupAllProperties();
            _service = new UserService(mockRepo.Object);
        }

        [Fact]
        public void TestGetUsers()
        {
            //Arrange
            int expected = 5;
            //Act
            var userlist = _service.GetAllUsers();
            //Assert
            Assert.Equal(expected, userlist.Count);
        }
        [Fact]
        public void TestGetUser()
        {
            //Arrange
            int expected = 3;
            //Act
            Users user = _service.GetUserById(3);
            Assert.Equal(expected, user.Id);
        }
        [Fact]
        public void TestAddUser()
        {
            Users userdetails = new Users() { Id = 6, UserName = "DDD", Password = "DDDDDD", UserType = "User", Email = "DDD@gmail.com", MobileNo = "1234567891", Confirmed = "Yes" };

            _service.AddUser(userdetails);

            int expected = 6;
            //Act
            Users user = _service.GetUserById(6);
            Assert.Equal(expected, user.Id);
        }
        [Fact]
        public void TestDeleteProduct()
        {
            int id = 5;

            _service.DeleteUser(id);

            //Act
            Users user = _service.GetUserById(5);
            Assert.Null(user);
        }
    
    }
}
