using DAL.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DOMAIN;

namespace DAL.Implementations.Memory
{
    // Esta clase gestiona los boletos en memoria sin necesidad de una base de datos real.
    // Se usa para pruebas, simulaciones o cuando no se necesita persistencia real.
    internal sealed class BoletoRepository : IBoletoRepository
    {

        #region singleton
        // Instancia única de la clase (patrón Singleton).
        private readonly static BoletoRepository _instance = new BoletoRepository();

        // Propiedad pública para obtener la única instancia de la clase.
        public static BoletoRepository Current
        {
            get
            {
                return _instance;
            }
        }

        // Constructor privado para evitar que se creen instancias fuera de la clase.
        private BoletoRepository()
        {
            listaBoletos = new List<Boleto>();// Inicializa la lista de boletos en memoria.
        }
        #endregion

        // Lista privada donde se almacenan los boletos en memoria.
        private static List<Boleto> listaBoletos;

        public void Add(Boleto boleto)
        {
            listaBoletos.Add(boleto);
        }

        public List<Boleto> GetAll()
        {
            return listaBoletos;
        }

        // Busca un boleto por su ID.
        public Boleto GetById(Guid idboleto)
        {
            Boleto boleto = default;

            foreach (var item in listaBoletos)
            {
                if (item.IdBoleto == idboleto)
                {
                    boleto = item;
                    break;
                }
            }

            return boleto;
        }

        public void Remove(Guid idboleto)
        {
            listaBoletos.Remove(GetById(idboleto));
        }

        public void Update(Boleto obj)
        {
            throw new NotImplementedException();
        }

        public Boleto GetByNumeroBoleto(int num)
        {
            Boleto boleto = default;

            foreach (var item in listaBoletos)
            {
                if (item.Numero == num)
                {
                    boleto = item;
                    break;
                }
            }
            return boleto;
        }

    }
}

