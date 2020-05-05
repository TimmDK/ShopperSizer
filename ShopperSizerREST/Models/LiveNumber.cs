using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopperSizerREST.Models
{
    public class LiveNumber
    {
        private int _number;
        private int _id;

        public LiveNumber(int id, int number)
        {
            _id = id;
            _number = number;
        }

        public LiveNumber()
        {

        }

        public int Id { get => _id; set => _id = value; }
        public int Number { get => _number; set => _number = value; }


    }
}
