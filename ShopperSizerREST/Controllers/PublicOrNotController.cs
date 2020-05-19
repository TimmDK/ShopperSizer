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
    public class PublicOrNotController : Controller
    {
        private static bool status;

        [HttpGet]
        public bool Get()
        {
            return status;
        }

        [HttpPut]
        public bool Put([FromBody]bool value)
        {
            status = value;
            return Get();
        }
    }
}
