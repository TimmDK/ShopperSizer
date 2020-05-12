using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopperSizerREST.Models
{
    public class LimitNumber
    {
        private int _limittal;
        private readonly int _Id;

        public int LimitTal
        {
            get { return _limittal; }
            set { _limittal = value; }
        }

        public int Id => _Id;

        public LimitNumber(int Id, int limittal)
        {
            _limittal = limittal;
            _Id = Id;
        }

        public LimitNumber()
        {

        }

        //Anders mein fuhrer
    }
}
