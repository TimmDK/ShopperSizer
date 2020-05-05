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

        public int Id { get => _id;  }
        public int Number
        {
            get { return _number; }
            set
            {
                _number = value;
                if (Number == 0 && value <= 0)
                {
                    _number = value;
                }
                else if(Number > 0)
                {
                    _number = value;
                }
            }
        }
    }
}
