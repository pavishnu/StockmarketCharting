using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StockMarket.AccountAPI.Models;

namespace StockMarket.AccountAPI.Repositories
{
    public interface IUserRepository
    {
        void AddUser(Users user);
        void DeleteUser(int id);
        void UpdateUser(Users user);
        List<Users> GetAllUser();
        Users GetUserById(int id);
        Users Login(string email, string password);
        Users GetUserByEmail(string email);
    }
}
