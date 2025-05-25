using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOMAIN
{
    public class Ejecutivo : Boleto
    {
        public float CostoEjecutivo { get; set; }

        public Ejecutivo()
        {
            TipoBoleto = TipoBoleto.Ejecutivo;
            CostoEjecutivo = 9800;
        }
    }
}
