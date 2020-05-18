using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShopperSizerREST.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ShopperSizerREST.Controllers
{
    [Route("api/[controller]")]
    public class StoreHoursController : Controller
    {
        private static StoreHours Hours = new StoreHours(1, 22);

        // GET: api/<controller>
        [HttpGet]
        public StoreHours Get()
        {
            return Hours;
        }

        // PUT api/<controller>/5
        //[HttpPut]
        //public StoreHours Put([FromBody]StoreHours value)
        //{
        //    Hours = value;
        //    return Get();
        //}
        [HttpPut]
        [Route("open/{hour}")]
        public StoreHours PutOpen(int hour)
        {
            Hours.OpeningHour = hour;
            return Get();
        }
        [HttpPut]
        [Route("close/{hour}")]
        public StoreHours PutClose(int hour)
        {
            Hours.ClosingHour = hour;
            return Get();
        }

    }
}
