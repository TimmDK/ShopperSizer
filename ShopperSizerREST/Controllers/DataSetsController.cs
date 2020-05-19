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
                for (int i = 1; i < 100; i++)
                {
                    Random rand = new Random();
                    DataSet dxx = new DataSet(rand.Next(i*5, i*8));
                    dxx.Date = dxx.Date.Subtract(TimeSpan.FromMinutes(rand.Next(25, 35) * i));
                    _context.Add(dxx);
                }
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

        // POST: api/DataSets
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<DataSet>> PostDataSet(DataSet dataSet)
        {
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
