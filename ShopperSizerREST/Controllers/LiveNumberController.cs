using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopperSizerREST.Models;

namespace ShopperSizerREST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LiveNumberController : ControllerBase
    {
        //private static int _idCounter = 1;
        private static List<LiveNumber> numbers = new List<LiveNumber>()
        {
            new LiveNumber(1,0)
        };
        
        // GET: api/LiveNumber
        [HttpGet]
        public List<LiveNumber> Get()
        {
            return numbers;
        }

        // GET: api/LiveNumber/5
        [HttpGet("{id}", Name = "Get")]
        public LiveNumber Get(int id)
        {
            return numbers.Find(i => i.Id == id);
        }

        // POST: api/LiveNumber
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/LiveNumber/5
        [HttpPut("{id}")]
        public LiveNumber Put(int id, [FromBody] LiveNumber value)
        {
            LiveNumber i = Get(id);
            if(i != null)
            {
                var result = i.Number + value.Number;
                if (result > -1) i.Number = result;

               
            }
            return Get(id);
        }
            
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
