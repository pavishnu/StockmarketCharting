using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StockMarket.AccountAPI.Models;

namespace StockMarket.AccountAPI.Services
{
    public interface IUserService
    {
        public Users Login(string email, string password);
        public List<Users> GetAllUsers();
        public Users GetUserById(int id);
        public void AddUser(Users user);
        public void DeleteUser(int id);
        public void UpdateUser(Users user);
    }
}
