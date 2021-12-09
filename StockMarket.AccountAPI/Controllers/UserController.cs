using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;
using StockMarket.AccountAPI.Models;
using StockMarket.AccountAPI.Services;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StockMarket.AccountAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;
        private readonly IConfiguration configuration;
        public UserController(IUserService _service, IConfiguration configuration)
        {
            userService = _service;
            this.configuration = configuration;
        }
        // GET All Users
        [HttpGet]
        [Route("GetAllUsers")]
        public IActionResult GetAllUsers()
        {
            return Ok(userService.GetAllUsers());
        }

        // GET by ID user
        [HttpGet]
        [Route("GetUser/{id}")]
        public IActionResult GetUserById(int id)
        {
            return Ok(userService.GetUserById(id));
        }

        /*private readonly IConfiguration configuration;
        public UserController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }*/
        [HttpGet]
        [Route("Login/{email}/{password}")]
        public IActionResult Login(string email,string password)
        {
            Users user = userService.Login(email, password);
            if (user == null)
            {
                return NotFound("Invalid User Details");
            }
            else
            {
                return Ok(GenerateJwtToken(user.UserName,user.UserType));
            }
        }

        private Token GenerateJwtToken(string uname,string userType)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, uname),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, uname),
                new Claim(ClaimTypes.Role,uname)
            };
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtKey"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            // recommended is 5 min
            var expires = DateTime.Now.AddDays(Convert.ToDouble(configuration["JwtExpireDays"]));
            var token = new JwtSecurityToken(
                configuration["JwtIssuer"],
                configuration["JwtIssuer"],
                claims,
                expires: expires,
                signingCredentials: credentials
            );

            var response = new Token
            {
                userType = userType,
                uname = uname,
                token = new JwtSecurityTokenHandler().WriteToken(token)
            };
            return response;
        }


        // POST Add user
        [HttpPost]
        [Route("AddUser")]
        public IActionResult AddUser(Users value)
        {
            userService.AddUser(value);
            return Ok("Record Added Successfully");
        }

        // PUT Update User
        [HttpPut]
        [Route("UpdateUser")]
        //[Authorize()]
        public IActionResult UpdateUser(Users value)
        {
            userService.UpdateUser(value);
            return Ok("Record Updated");
        }

        // DELETE Data
        [HttpDelete]
        [Route("DeleteUser/{id}")]
        //[Authorize()]
        public IActionResult DeleteUser(int id)
        {
            userService.DeleteUser(id);
            return Ok("Record Deleted");
        }
    }
}
