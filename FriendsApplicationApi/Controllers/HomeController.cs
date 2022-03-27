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
    public class HomeController : Controller
    {
        private IUsers userServices;

        public HomeController(IUsers a)
        {
            userServices = a;
        }

        [HttpGet]
        [Route("all")]
        public IActionResult Index(string email)
        {
            return Ok(userServices.GetFriends(email));
        }

        [HttpGet]
        [Route("get/{email}")]
        public List<Users> search(String toSearch)
        {
            return userServices.search(toSearch);
        }

        [HttpDelete]
        [Route("delete/{email}")]
        public IActionResult DeleteUser(String email)
        {
            var user = userServices.getUser(email);
            if (user != null)
            {
                userServices.DeleteUser(user);
                return Ok("User Successfully removed");
            }
            return NotFound("User with email " + email + " is not found");
        }
    }
}
