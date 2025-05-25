using DAL.Contracts;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Implementations.SqlServer;

namespace DAL.Factory
{
    public static class FactoryRepository
    {
        private static int backendType;
        static FactoryRepository()
        {
            backendType = int.Parse(ConfigurationManager.AppSettings["BackendType"]);
        }

        public static IBoletoRepository BoletoRepository
        {
            get
            {
                if (backendType == (int)BackendType.Memory)
                    return DAL.Implementations.Memory.BoletoRepository.Current;
                else if
                    (backendType == (int)BackendType.SqlServer)
                    return DAL.Implementations.SqlServer.BoletoRepository.Current;
                else
                    throw new Exception("Backend type not supported");  

            }
        }
    }

    internal enum BackendType
    {
        Memory,
        SqlServer
    }
}
