using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOMAIN
{
    public class Turista : Base
    {
        public float CostoTurista { get; set; }
        public Turista()
        {
            CostoTurista = 8400;
        }
    }
}
