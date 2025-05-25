using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DOMAIN.Exceptions
{
    public class FormatoGuidException :Exception
    {
        public FormatoGuidException() : base("El formato del GUID no es válido.")
        {

        }
    }
}
