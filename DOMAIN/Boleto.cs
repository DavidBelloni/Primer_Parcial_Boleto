using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DOMAIN
{
    public abstract class Boleto
    {
        // Comienza en 1, incrementa cada vez que se crea un nuevo boleto
        private static int _contador = 1;
        public Guid IdBoleto { get; set; }
        public int Numero { get; private set; }
        public DateTime FechaSalida { get; set; }
        public int TiempoEnDias {  get; set; }
        public float CostoEmbarque {  get; set; }
        public float CostoBase { get; set; }
        public TipoBoleto TipoBoleto { get; protected set; }
        public float CostoTotal {  get; set; }
        public DateTime FechaRegreso { get; set; }

        public Boleto()
        {
            Numero = _contador++;
            IdBoleto = Guid.NewGuid(); // Si fuera SQL, el newid() se lo asgian la DB
            CostoEmbarque = 900;
            CostoBase = 9950;
        }
        
    }
}
