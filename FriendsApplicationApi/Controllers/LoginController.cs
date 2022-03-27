using FriendsApplicationApi.Models;
using FriendsApplicationApi.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FriendsApplicationApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IUsers userServices;

        public LoginController(IUsers a)
        {
            userServices = a;
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login(string email, string password)
        {
            if (userServices.login(email, password))
            {
                return Ok(true);
            }
            return NotFound("User not found");
        }

        [HttpPost]
        [Route("register")]
        public IActionResult Register([FromBody] Users user)
        {
            userServices.addUser(user);
            return Ok("Successfully created" + user);

        }
    }
}
