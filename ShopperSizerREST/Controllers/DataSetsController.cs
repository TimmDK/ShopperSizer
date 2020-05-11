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
