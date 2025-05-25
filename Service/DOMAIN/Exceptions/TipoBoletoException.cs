using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOMAIN.Exceptions.Service
{
    public class TipoBoletoException : Exception
    {
        public TipoBoletoException() : base("[ATENCIÓN] Tipo de boleto no disponible")
        {

        }


    }
}
