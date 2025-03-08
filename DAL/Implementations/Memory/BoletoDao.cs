using DAL.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DOMAIN;

namespace DAL.Implementations.Memory
{
    // Clase BoletoDao que implementa la interfaz IBoletoDao.
    // Esta clase gestiona los boletos en memoria sin necesidad de una base de datos real.
    // Se usa para pruebas, simulaciones o cuando no se necesita persistencia real.
    internal sealed class BoletoDao : IBoletoDao
    {

        #region singleton
        // Instancia única de la clase (patrón Singleton).
        private readonly static BoletoDao _instance = new BoletoDao();

        // Propiedad pública para obtener la única instancia de la clase.
        public static BoletoDao Current
        {
            get
            {
                return _instance;
            }
        }

        // Constructor privado para evitar que se creen instancias fuera de la clase.
        private BoletoDao()
        {
            _list = new List<Boleto>();// Inicializa la lista de boletos en memoria.
        }
        #endregion

        // Lista privada donde se almacenan los boletos en memoria.
        private static List<Boleto> _list;

        public void Add(Boleto obj)
        {
            obj.IdBoleto = Guid.NewGuid();
            _list.Add(obj);
        }

        public List<Boleto> GetAll()
        {
            return _list;
        }

        // Busca un boleto por su ID.
        public Boleto GetById(Guid idboleto)
        {

            Boleto boleto = default;

            foreach (var item in _list)
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
            _list.Remove(GetById(idboleto));
        }

        public void Update(Boleto obj)
        {
            // Aplicamos una pequeña validacion usando el operador de coalescencia nula
            Boleto boleto = GetById(obj.IdBoleto) ?? throw new Exception("El boleto no existe y no se puede actualizar.");
            boleto.CostoEmbarque = obj.CostoEmbarque;
            boleto.FechaSalida = obj.FechaSalida;
        }

        // Busca boleto por codigo
        public Boleto GetByCode(int code)
        {
           // return _list.Find(b => b.Codigo == code)
            throw new NotImplementedException();
        }

        // Busca boleto por nombre
        public List<Boleto> GetByName(string name)
        {
            //return _list.Where(b => b.Nombre != null && b.Nombre.Contains(name, StringComparison.OrdinalIgnoreCase)).ToList();
            throw new NotImplementedException();
        }
    }
}

