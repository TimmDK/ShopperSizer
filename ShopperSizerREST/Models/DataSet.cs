using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopperSizerREST.Models
{
    public class DataSet
    {
        private int _id;
        private int _count;
        private DateTime _date;

        public DataSet()
        {
            Date = DateTime.Now;
        }

        public int Id
        {
            get => _id;
            set => _id = value;
        }

        public int Count
        {
            get => _count;
            set => _count = value;
        }

        public DateTime Date
        {
            get => _date;
            set => _date = value;
        }
    }
}
