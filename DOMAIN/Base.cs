using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOMAIN
{
    public class Base : Boleto
    {
        //public float CostoBase{ get; set; }
        public Base()
        {
            CostoEmbarque = 900;
            CostoBase = 9950;
        }
    }
}
