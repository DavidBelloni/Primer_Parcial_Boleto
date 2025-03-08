using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOMAIN
{
    public class Ejecutivo : Base
    {
        public float CostoEjecutivo { get; set; }

        public Ejecutivo()
        {
            CostoEjecutivo = 9800;
        }
    }
}
