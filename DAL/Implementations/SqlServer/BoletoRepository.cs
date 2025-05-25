using System;
using DAL.Contracts;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DOMAIN;
using DAL.Helpers;
using static DAL.Helpers.SqlHelpers;

namespace DAL.Implementations.SqlServer
{
    internal sealed class BoletoRepository : IBoletoRepository
    {
        #region singleton
        // Instancia única de la clase
        // Aca estamos usando Eager Initialization, es decir, la instancia se crea en el momento de la definición de la variable.
        private readonly static BoletoRepository _instance = new BoletoRepository();

        public static BoletoRepository Current
        {
            get
            {
                return _instance;
            }
        }
        // Se hace privado el constructor de la clase para evitar que se creen otras instancias desde fuera de la clase.
        private BoletoRepository()
        {
            //Implent here the initialization of your singleton
        }
        #endregion


        #region Statements
        private string InsertStatement
        {
            get => "INSERT INTO [dbo].[Boletos] (IdBoleto, Numero, FechaSalida, TiempoDias, CostoEmbarque) VALUES (@id, @numero, @Fecha, @Tiempo, @Costo); Select @@IDentity";
        }

        private string UpdateStatement
        {
            get => "UPDATE [dbo].[Boletos] SET FechaSalida = @Fecha, CostoEmbarque = @Costo WHERE IdBoleto = @id";
        }

        private string DeleteStatement
        {
            get => "DELETE FROM [dbo].[Boletos] WHERE IdBoleto = @id";
        }

        private string SelectOneStatement
        {
            get => "SELECT IdBoleto, Numero, FechaSalida, TiempoDias, CostoEmbarque  FROM [dbo].[Boletos] WHERE IdBoleto = @id";
        }

        private string SelectAllStatement
        {
            get => "SELECT IdBoleto, Numero, FechaSalida, TiempoDias, CostoEmbarque FROM [dbo].[Boletos]";
        }
        #endregion


        public void Add(Boleto obj)
        {
            throw new NotImplementedException();
        }

        public void Update(Boleto obj)
        {
            throw new NotImplementedException();
        }

        public void Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        public Boleto GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<Boleto> GetAll()
        {
            throw new NotImplementedException();
        }

        public Boleto GetByCode(int numero)
        {
            throw new NotImplementedException();
        }

        public List<Boleto> GetByFechaSalida(DateTime Fecha)
        {
            throw new NotImplementedException();
        }

        public Boleto GetByNumeroBoleto(int num)
        {
            throw new NotImplementedException();
        }
    }
}

