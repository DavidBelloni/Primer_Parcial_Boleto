using DOMAIN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface
{
    public interface IBoletoLogic
    {
        void AddBoleto(Boleto boleto);
        List<Boleto> ObtenerBoletos();
        Boleto CrearBoleto(int tipo);

        float ObtenerCostoBoleto(Boleto boleto);

        string CalcularRegreso(int cant, DateTime fecha);

        void SaveOrUpdate(Boleto boleto);

        void Delete(Boleto boleto);

        Boleto GetById(int id);

        List<Boleto> GetAll();

    }
}
