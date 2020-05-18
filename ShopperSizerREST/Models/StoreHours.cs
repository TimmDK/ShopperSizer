using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopperSizerREST.Models
{
    public class StoreHours
    {
        private int _openingHour;
        private int _closingHour;

        public StoreHours()
        {

        }
        public StoreHours(int a, int b)
        {
            _openingHour = a;
            _closingHour = b;
        }

        public int OpeningHour
        {
            get => _openingHour;
            set
            {
                if (value >= 0 && value <= 23 && value < ClosingHour) _openingHour = value;
            }
        }

        public int ClosingHour
        {
            get => _closingHour;
            set
            {
                if (value >= 0 && value <= 23 && value > OpeningHour) _closingHour = value;
            }
        }
    }
}
