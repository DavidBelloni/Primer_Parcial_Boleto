using DOMAIN;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Contracts;
using DAL.Factory;   
using System.Security.Permissions;


namespace BLL
{
    public class BoletoLogic
    {

        private IBoletoDao boletoDao;

        public BoletoLogic()
        {
            // Devuelve una instancia de la clase BoletoDao...
            boletoDao = FactoryDao.BoletoDao;
        }

        // Este metodo se encarga de agregar un boleto a la lista de boletos...
        public void AddBoleto(Boleto boleto)
        {
            // Se llama al metodo Add de la clase BoletoDao
            boletoDao.Add(boleto);
        }

        // Este metodo se encarga de obtener todos los boletos de la lista de boletos
        public List<Boleto> GetAllBoletos()
        {
            return boletoDao.GetAll();
        }
       
        public Boleto CrearBoleto(int tipo)
        {
            switch (tipo)
            {
                case (int)TipoBoleto.Base:
                    return new Base();

                case (int)TipoBoleto.Turista:
                    return new Turista(); 

                case (int)TipoBoleto.Ejecutivo:
                    return new Ejecutivo();

                default:
                    throw new ArgumentException("Tipo de boleto no válido");
            }
        }

        public float ObtenerCostoBoleto(Boleto boleto)
        {
            float total = boleto.CostoEmbarque + boleto.CostoBase;

            if (boleto is Turista turista)
            {
                total += turista.CostoTurista;
            }
            else if (boleto is Ejecutivo ejecutivo)
            {
                total += ejecutivo.CostoEjecutivo;
            }

            return total;
        }

        /*
        public float ObtenerCostoBoleto(int tipo)
        {
            float total; // = default;

            if (tipo == (int)TipoBoleto.Base) // BOLETO BASE
            {
                total = pbase.CostoEmbarque + pbase.CostoBase;
                return total;
            }
            else if (tipo == (int)TipoBoleto.Turista) // BOLETO TURISTA
            {
                Turista pturista = new Turista();
                total = pbase.CostoEmbarque + pbase.CostoBase + pturista.CostoTurista;
                return total;
            }
            else if (tipo == (int)TipoBoleto.Ejecutivo) // BOLETO EJECUTIVO
            {
                Ejecutivo pejecutivo = new Ejecutivo();
                total = pbase.CostoEmbarque + pbase.CostoBase + pejecutivo.CostoEjecutivo;
                return total;
            }
            else
            {
                throw new ArgumentException("TIPO DE BOLETO NO VALIDO");
            }
   
        }
        */


        public string CalcularRegreso(int cant, DateTime fecha)
        {
            // Metodo de la clase DateTime, que suma o resta dias a una fecha
            string fecharegreso = fecha.AddDays(cant).ToString();

            return fecharegreso;
        }

        public void SaveOrUpdate(Boleto boleto) { }

        public void Delete(Boleto boleto) { }

        public Boleto GetById(int id)
        {
            return null;
        }

        public List<Boleto> GetAll()
        {
            return null;
        }


    }
}

