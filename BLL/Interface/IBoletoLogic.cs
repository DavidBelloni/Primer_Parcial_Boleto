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
        void AgregarBoleto(Boleto boleto);
        Boleto CrearBoleto(int tipo);
        List<Boleto> ObtenerBoletos();
        float ObtenerCostoBoleto(Boleto boleto);
        string CalcularRegreso(int cant, DateTime fecha);
        Boleto GetById(Guid idboleto);
        Boleto GetByNumeroBoleto(int num);

    }
}
