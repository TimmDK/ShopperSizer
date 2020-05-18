using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopperSizerREST.Models
{
    public class PublicOrNot
    {
        public PublicOrNot()
        {
            
        }
        public PublicOrNot(bool init)
        {
            Status = init;
        }

        public bool Status { get; set; }
    }
}
