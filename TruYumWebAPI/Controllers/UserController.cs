using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TruYum.Models;

namespace TruYum.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private static List<User> users = new List<User>
        {
            new User{userId=2,password="123"},
            new User{userId=3,password="abcde"},
            new User{userId=4,password="xyz"},
            new User{userId=5,password="1234"}
        };
        [HttpGet("{id}")]
        public bool Get(int id,[FromBody]User user)
        {
            var data = users;
            foreach(var cred in data)
            {
                if (cred.userId == id && cred.password == user.password)
                    return true;                
            }
            return false;
        }
        [HttpPost]
        public string Post([FromBody]User cred)
        {
            users.Add(cred);
            return "Successfully Registered";
        }
    }
}