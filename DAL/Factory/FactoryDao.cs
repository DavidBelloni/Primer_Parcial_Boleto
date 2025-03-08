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
    public static class FactoryDao
    {
        private static int backendType;
        static FactoryDao()
        {
            backendType = int.Parse(ConfigurationManager.AppSettings["BackendType"]);
        }

        public static IBoletoDao BoletoDao
        {
            get
            {
                if (backendType == (int)BackendType.Memory)
                    return DAL.Implementations.Memory.BoletoDao.Current;
                else
                    return DAL.Implementations.SqlServer.BoletoDao.Current;

            }
        }
    }

    internal enum BackendType
    {
        Memory,
        SqlServer
    }
}
