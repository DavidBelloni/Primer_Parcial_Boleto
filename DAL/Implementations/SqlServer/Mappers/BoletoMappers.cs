using DOMAIN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Implementations.SqlServer.Mappers
{
    internal class BoletoMappers
    {
        #region singleton
        private readonly static BoletoMappers _instance = new BoletoMappers();

        public static BoletoMappers Current
        {
            get
            {
                return _instance;
            }
        }

        private BoletoMappers()
        {
            //Implent here the initialization of your singleton
        }
        #endregion

        public Turista FillTurista(object[] values)
        {
            return new Turista()
            {
                IdBoleto = Guid.Parse(values[0].ToString()),
                FechaSalida = DateTime.Parse(values[1].ToString()),
                CostoEmbarque = float.Parse(values[2].ToString()),

            };
        }

        public Ejecutivo FillEjecutivo(object[] values)
        {
            return new Ejecutivo()
            {
                IdBoleto = Guid.Parse(values[0].ToString()),
                FechaSalida = DateTime.Parse(values[1].ToString()),
                CostoEmbarque = float.Parse(values[2].ToString()),

            };
        }

        public Base FillBase(object[] values)
        {
            return new Base()
            {
                IdBoleto = Guid.Parse(values[0].ToString()),
                FechaSalida = DateTime.Parse(values[1].ToString()),
                CostoEmbarque = float.Parse(values[2].ToString()),

            };
        }
        internal enum BoletoColumns
        {
            IdBoleto = 0,
            FechaSalida = 1,
            CostoEmbarque = 2,

        }
    }
}
