using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopperSizerREST.Models
{
    public class LimitNumber
    {
        private int _tal;

        public int Tal 
        {
            get { return _tal; }
            set { _tal = value; }
        }

        public LimitNumber(int tal)
        {
            tal = Tal;
        }

        public LimitNumber()
        {

        }
    }
}
