using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DOMAIN
{
    // Esta clase es abstracta, por lo que no se puede instanciar, se usa como una plantilla para otras clases.
    // Se usa cuando tienes una funcionalidad comun que se va a usar en otras clases.
    // Clase Base para luego crear subclases (Factory Method)
    public abstract class Boleto
    {
        // GUID significa: Globally Unique Identifier
        // Es un identificador unico que se genera automaticamente.
        public Guid IdBoleto { get; set; }
        public int Numero { get; }

        public DateTime FechaSalida { get; set; }

        public int TiempoEnDias {  get; set; }

        public float CostoEmbarque {  get; set; }

        public float CostoBase { get; set; }

        public TipoBoleto TipoBoleto { get; }

        public float Costo_total {  get; set; }

        public DateTime FechaRegreso { get; set; }

        public Boleto()
        {
           
        }
        
    }
}
