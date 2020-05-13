using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopperSizerREST.Models;

namespace ShopperSizerREST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataSetsController : ControllerBase
    {
        private readonly DataSetContext _context;

        public DataSetsController(DataSetContext context)
        {
            _context = context;
            if (_context.DataSets.Count() == 0)
            {
                DataSet d1 = new DataSet(); d1.Date = DateTime.Now.Subtract(TimeSpan.FromHours(1)); d1.Count = 10;
                DataSet d2 = new DataSet(); d2.Date = DateTime.Now.Subtract(TimeSpan.FromHours(2)); d2.Count = 20;
                DataSet d3 = new DataSet(); d3.Date = DateTime.Now.Subtract(TimeSpan.FromHours(3)); d3.Count = 30;
                DataSet d4 = new DataSet(); d4.Date = DateTime.Now.Subtract(TimeSpan.FromHours(4)); d4.Count = 40;
                DataSet d5 = new DataSet(); d5.Date = DateTime.Now.Subtract(TimeSpan.FromHours(4)).Add(TimeSpan.FromMinutes(2)); d5.Count = 80;
                DataSet d6 = new DataSet(); d6.Date = DateTime.Now.Subtract(TimeSpan.FromDays(1)).Add(TimeSpan.FromMinutes(2)); d6.Count = 90;
                DataSet d7 = new DataSet(); d7.Date = DateTime.Now.Subtract(TimeSpan.FromDays(2)).Add(TimeSpan.FromMinutes(2)); d7.Count = 100;
                _context.DataSets.Add(d1);
                _context.DataSets.Add(d2);
                _context.DataSets.Add(d3);
                _context.DataSets.Add(d4);
                _context.DataSets.Add(d5);
                _context.DataSets.Add(d6);
                _context.DataSets.Add(d7);
                _context.SaveChanges();
            }
        }

        // GET: api/DataSets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DataSet>>> GetDataSets()
        {
            return await _context.DataSets.ToListAsync();
        }
        
        // GET: api/DataSets/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DataSet>> GetDataSet(int id)
        {
            var dataSet = await _context.DataSets.FindAsync(id);

            if (dataSet == null)
            {
                return NotFound();
            }

            return dataSet;
        }

        //GET: api/DataSets/date/
        [HttpGet]
        [Route("date/{date}")]
        public List<DataSet> GetDataSetFromDate(string date)
        {
            List<DataSet> listToReturn = new List<DataSet>();
            List<DataSet> listToWorkWith = new List<DataSet>();

            foreach (DataSet d in GetDataSets().Result.Value)
            {
                if (d.Date.Date == DateTime.Parse(date))
                {
                    listToWorkWith.Add(d);
                }
            }

            DateTime dummy = DateTime.MinValue;
            int testHour = 1;
            int[] testHours = new[]
                {0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23};

            foreach (int i in testHours)
            {
                List<DataSet> dummyList = listToWorkWith.FindAll(e => e.Date.Hour == i);
                DateTime dat = DateTime.MinValue;
                int idd = -1;
                foreach (DataSet d in dummyList)
                {
                    if (d.Date > dat)
                    {
                        dat = d.Date;
                        idd = d.Id;
                    }
                }
                listToReturn.Add(listToWorkWith.Find(e=>e.Id == idd));
            }

            return listToReturn;
        }

        /*
        // PUT: api/DataSets/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDataSet(int id, DataSet dataSet)
        {
            if (id != dataSet.Id)
            {
                return BadRequest();
            }

            _context.Entry(dataSet).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DataSetExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }*/


        // POST: api/DataSets
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<DataSet>> PostDataSet(DataSet dataSet)
        {
            //DataSet dataSet = new DataSet();
            //dataSet.Count = int.Parse(dataCount);
            _context.DataSets.Add(dataSet);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetDataSet), new { id = dataSet.Id }, dataSet);
        }

        // DELETE: api/DataSets/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DataSet>> DeleteDataSet(int id)
        {
            var dataSet = await _context.DataSets.FindAsync(id);
            if (dataSet == null)
            {
                return NotFound();
            }

            _context.DataSets.Remove(dataSet);
            await _context.SaveChangesAsync();

            return dataSet;
        }

        private bool DataSetExists(int id)
        {
            return _context.DataSets.Any(e => e.Id == id);
        }
    }
}
