using DOMAIN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;
using System.Reflection;
using DOMAIN.Exceptions.Service;
using Service.DOMAIN.Exceptions;

namespace primer_parcial
{
    internal class Program
    {
        static void Main(string[] args)
        {

            BoletoLogic service = new BoletoLogic();

            int tipo;
            int cant_dias = 0;
            string fecha_regreso;
            DateTime fecha;
            string continuar = "SI";

            do
            {
                Console.WriteLine("\nINFORMACION COMERCIAL");
                Console.WriteLine("¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯ \n");
                Console.WriteLine(" COSTO BASE: $9950  \n COSTO TURISTA: $8400 \n COSTO EJECUTIVO: $9800 \n COSTO EMBARQUE: $900 \n");
                do
                {
                    Console.WriteLine("-INGRESE TIPO DE BOLETO: [0=TURISTA]  [1=EJECUTIVO]");
                    try
                    {
                        if (!int.TryParse(Console.ReadLine(), out tipo) || (tipo != 0 && tipo != 1))
                        {
                            throw new TipoBoletoException();
                        }
                        break; // Salir del bucle si la entrada es válida
                    }
                    catch (TipoBoletoException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Ocurrió un error inesperado: {ex.Message}");
                    }
                } while (true); //Usamos el "true" para hacer el bucle infinito. Saldremos del bucle si la entrada es válida a travez del break!


                do
                {
                    Console.WriteLine("-INGRESE FECHA DE SALIDA: DD/MM/YYYY");
                    try
                    {
                        string input = Console.ReadLine();
                        if (!DateTime.TryParseExact(input, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out fecha))
                        {
                            throw new FechaSalidaException();
                        }
                        break; // Salir del bucle si la entrada es válida
                    }
                    catch (FechaSalidaException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Ocurrió un error inesperado: {ex.Message}");
                    }
                } while (true);


                do
                {
                    Console.WriteLine("-INGRESE DURACION DEL VIAJE EN DÍAS: ");
                    try
                    {
                        if (!int.TryParse(Console.ReadLine(), out cant_dias) || cant_dias <= 0)
                        {
                            throw new CantidadDiasException();
                        }
                        break; // Salir del bucle si la entrada es válida
                    }
                    catch (CantidadDiasException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Ocurrió un error inesperado: {ex.Message}");
                    }
                } while (true);

                fecha_regreso = service.CalcularRegreso(cant_dias, fecha);

                Boleto boleto = service.CrearBoleto(tipo);

                boleto.FechaSalida = fecha;
                boleto.TiempoEnDias = cant_dias;
                boleto.FechaRegreso = DateTime.Parse(fecha_regreso);
                boleto.CostoTotal = service.ObtenerCostoBoleto(boleto);
                service.AgregarBoleto(boleto);

                // Estructura de control, cada iteración del foreach toma un boleto de la lista y lo almacena en item
                foreach (var item in service.ObtenerBoletos())
                {
                    Console.WriteLine($"FECHA DE SALIDA: {item.FechaSalida}, COSTO TOTAL: {item.CostoTotal}, CANTIDAD DE DIAS: {item.TiempoEnDias}, FECHA DE REGRESO: {item.FechaRegreso}, ID-BOLETO: {item.IdBoleto}");
                }
                Console.ReadKey();

                Console.WriteLine("\n¿DESEA SEGUIR GENERANDO PASAJES? [SI/NO]");
                continuar = Console.ReadLine().ToUpper();
            }
            while (continuar == "SI");

        }
    }
}
