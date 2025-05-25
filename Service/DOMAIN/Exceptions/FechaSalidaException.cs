using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DOMAIN.Exceptions
{
    public class FechaSalidaException : Exception
    {
        public FechaSalidaException() : base("[ATENCIÓN] Respete el formado de fecha solicitado")
        {

        }
    }
}
