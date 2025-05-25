using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DOMAIN.Exceptions
{
    public class BoletoNoEncontradoException : Exception
    {
        public BoletoNoEncontradoException() : base("El boleto no fue encontrado")
        {

        }
    }
}
