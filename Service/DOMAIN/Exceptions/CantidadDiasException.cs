using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DOMAIN.Exceptions
{
    public class CantidadDiasException : Exception
    {
        public CantidadDiasException() : base("[ATENCIÓN] La cantidad de días debe ser un número entero positivo")
        {

        }
    }
}
