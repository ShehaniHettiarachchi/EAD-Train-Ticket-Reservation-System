using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransportManagmentSystemAPI.DBconfig;
using TransportManagmentSystemAPI.Models;
using TransportManagmentSystemAPI.Services;

namespace TransportManagmentSystemAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    // Constructor to initialize LoginService
    public class LoginController : ControllerBase
    {
        private readonly LoginService _loginservice;
        public LoginController(LoginService loginService)
        {
            _loginservice = loginService;
        }

        [HttpGet]
        //// GET: api/<LoginController>
        public Task<User> Get()
        {
            return null;
        }

        [HttpPost]
        // POST api/<LoginController>
        public ActionResult Post(User user)
        {
            // Checking if NIC and Password are provided
            if (user.Nic != null && user.Password != null)
            {
                // Calling LoginService to validate user
                var ValdatedAccount = _loginservice.MakeLogin(user);

                // Checking if user is validated
                if (ValdatedAccount != null)
                {
                    return Ok(ValdatedAccount);
                }
                else
                {
                    return Unauthorized();
                }
            }
            else {
               return  BadRequest("Please Enter Your NIC and Password!");// Missing NIC or Password
            }
            
        }
    }
}
