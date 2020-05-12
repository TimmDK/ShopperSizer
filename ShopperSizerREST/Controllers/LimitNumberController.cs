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
    public class LimitNumberController : Controller
    {
        private static List<LimitNumber> lnumbers = new List<LimitNumber>()
        {
            new LimitNumber(1, 200)
        };
        // GET: api/<controller>
        [HttpGet]
        public List<LimitNumber> Get()
        {
            return lnumbers;
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public LimitNumber Get(int id)
        {
            return lnumbers.Find(i => i.Id == id);
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public LimitNumber Put(int id, [FromBody] LimitNumber value)
        {
            LimitNumber i = Get(id);
            if (i != null)
            {
                var result = value.LimitTal;
                if (result > -1) i.LimitTal = result;
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
