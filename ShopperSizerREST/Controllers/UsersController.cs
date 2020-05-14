using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShopperSizerREST.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ShopperSizerREST.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {

        private static List<User> users = new List<User>()
        {
            new User(1, "admin", "admin")
        };

        // GET: api/<controller>
        [HttpGet]
        public List<User> Get()
        {
            return users;
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public User Get(int id)
        {
            return users.Find(i => i.Id == id);
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public User Put(int id, [FromBody] User value)
        {
            User i = Get(id);

            if (i != null)
            {
                if (value.Username != null)
                {
                    i.Username = value.Username;
                }

                if (value.Password != null)
                {
                    i.Password = value.Password;
                }
            }

            return Get(id);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
