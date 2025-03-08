using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DOMAIN;

namespace DAL.Contracts
{
    // Aca IBoletoDao ya tiene los métodos de IGenericDao<T>, pero también puede definir métodos específicos para boletos
    // IBoletoDao es una especializacion de IGenericDao<Boleto>
    // Obtiene todos los métodos genéricos de IGenericDao<T>.
    public interface IBoletoDao : IGenericDao<Boleto>
    {
        //List<Boleto> GetBoletosByFecha(DateTime fecha);
    }
}
