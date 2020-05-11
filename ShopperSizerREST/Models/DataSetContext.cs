using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ShopperSizerREST.Models
{
    public class DataSetContext : DbContext
    {
        public DataSetContext(DbContextOptions<DataSetContext> options) : base(options)
        {

        }

        public DbSet<DataSet> DataSets { get; set; }
    }
}
