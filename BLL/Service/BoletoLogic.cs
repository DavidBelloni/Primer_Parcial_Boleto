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
using BLL.Interface;
using DOMAIN.Exceptions.Service;


namespace BLL
{
    public class BoletoLogic : IBoletoLogic
    {

        private readonly IBoletoRepository boletoRepository;
        public BoletoLogic()
        {
            // Devuelve una instancia de la clase BoletoRepository (Memory o SQL)
            boletoRepository = FactoryRepository.BoletoRepository;
        }

        // Este metodo se encarga de agregar un boleto a la lista de boletos...
        public void AddBoleto(Boleto boleto)
        {
            // Se llama al metodo Add de la clase BoletoDao
            boletoRepository.Add(boleto);
        }

        // Este metodo se encarga de obtener todos los boletos de la lista de boletos
        public List<Boleto> ObtenerBoletos()
        {
            return boletoRepository.GetAll();
        }
       
        public Boleto CrearBoleto(int tipo)
        {
            // Se crea un objeto de la clase Boleto, dependiendo del tipo de boleto que se le pase por parametro
            // Devolviendo una instancia de la clase correspondiente
            switch (tipo)
            {
                case (int)TipoBoleto.Turista:
                    return new Turista(); 

                case (int)TipoBoleto.Ejecutivo:
                    return new Ejecutivo();

                default:
                    throw new TipoBoletoException();
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
            else
                throw new TipoBoletoException();

            return total;
        }

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

