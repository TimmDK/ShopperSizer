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
        //public static List<PublicOrNot> list = new List<PublicOrNot>()
        //{
        //    new PublicOrNot(false)
        //};

        private static bool status;

        // GET: api/<controller>
        //[HttpGet]
        //public IEnumerable<PublicOrNot> Get()
        //{
        //    return list;
        //}
        [HttpGet]
        public bool Get()
        {
            //return list[0].Status;
            return status;
        }


        // GET api/<controller>/5
        //[HttpGet("{id}")]
        //public PublicOrNot Get(int id)
        //{
        //    return list[0];
        //}

        // PUT api/<controller>/5 
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody]PublicOrNot value)
        //{
        //    if (list[0] != null)
        //    {
        //        list[0] = value;
        //    }
        //}
        [HttpPut]
        public bool Put(int id, [FromBody]bool value)
        {
            //if (list[0] != null)
            //{
            //    list[0].Status = value;
            //}

            //return list[0].Status;
            status = value;
            return Get();
        }

        // PUT api/<controller>/5
        //[HttpPut]
        //public bool Put([FromBody]string value)
        //{
        //    if (list[0] != null)
        //    {
        //        bool hej = bool.Parse(value);
        //        list[0].Status = hej;
        //    }

        //    return list[0].Status;
        //}
    }
}
