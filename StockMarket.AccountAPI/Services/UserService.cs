using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StockMarket.AccountAPI.Repositories;
using StockMarket.AccountAPI.Models;


namespace StockMarket.AccountAPI.Services
{
    public class UserService:IUserService
    {
        //UserRepository userRepo = new UserRepository();
        private IUserRepository userRepo;
        public UserService() {}
        public UserService(IUserRepository _userRepo)
        {
            this.userRepo = _userRepo;
        }

        public Users Login(string email, string password)
        {
            return userRepo.Login(email, password);
        }

        public List<Users> GetAllUsers()
        {
            return userRepo.GetAllUser();
        }

        public Users GetUserById(int id)
        {
            return userRepo.GetUserById(id);
        }
        public void AddUser(Users user)
        {
            userRepo.AddUser(user);
        }
        public void DeleteUser(int id)
        {
            userRepo.DeleteUser(id);
        }
        public void UpdateUser(Users user)
        {
            userRepo.UpdateUser(user);
        }


    }
}
