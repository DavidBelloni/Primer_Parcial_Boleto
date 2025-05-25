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

                // Estructura de control, cada iteración toma un boleto de la lista y lo va mostrando
                foreach (var item in service.ObtenerBoletos())
                    {
                        Console.WriteLine($"FECHA DE SALIDA: {item.FechaSalida}, COSTO TOTAL: {item.CostoTotal}, CANTIDAD DE DIAS: {item.TiempoEnDias}, FECHA DE REGRESO: {item.FechaRegreso}, ID-BOLETO: {item.IdBoleto}");
                    }
                Console.WriteLine("Presione una tecla para continuar");
                Console.ReadLine();

                Console.WriteLine("\n¿DESEA SEGUIR GENERANDO PASAJES? [SI/NO]");
                continuar = Console.ReadLine().ToUpper();
            }
            while (continuar == "SI");

            // OPCIONES EXTRAS DEL MENU (BUSQUEDAS)

            string opcionBusqueda;
            do
            {
                Console.WriteLine("\n[BUSCAR BOLETO]");
                Console.WriteLine("Seleccione el método de búsqueda:");
                Console.WriteLine("1 - Buscar por ID");
                Console.WriteLine("2 - Buscar por Número de Boleto");
                Console.WriteLine("Escriba SALIR para cancelar.");

                string opcion = Console.ReadLine().Trim().ToUpper();
                if (opcion == "SALIR")
                    break;

                try
                {
                    if (opcion == "1")
                    {
                        Console.Write("Ingrese el ID del boleto: ");
                        string id = Console.ReadLine();
                        Guid guidBoleto;
                        if (!Guid.TryParse(id, out guidBoleto))
                            throw new FormatoGuidException();

                        var boletoBuscado = service.GetById(guidBoleto);
                        if (boletoBuscado == null)
                            throw new BoletoNoEncontradoException();

                        Console.WriteLine($"BOLETO ENCONTRADO: {boletoBuscado.FechaSalida}, COSTO TOTAL: {boletoBuscado.CostoTotal}, CANTIDAD DE DIAS: {boletoBuscado.TiempoEnDias}, FECHA DE REGRESO: {boletoBuscado.FechaRegreso}, ID-BOLETO: {boletoBuscado.IdBoleto}");
                    }
                    else if (opcion == "2")
                    {
                        Console.Write("Ingrese el número de boleto: ");
                        int numeroBoleto;
                        if (!int.TryParse(Console.ReadLine(), out numeroBoleto))
                            throw new Exception("El número de boleto debe ser un número entero.");

                        var boletoBuscado = service.GetByNumeroBoleto(numeroBoleto);
                        if (boletoBuscado == null)
                            throw new BoletoNoEncontradoException();

                        Console.WriteLine($"BOLETO ENCONTRADO: {boletoBuscado.FechaSalida}, COSTO TOTAL: {boletoBuscado.CostoTotal}, CANTIDAD DE DIAS: {boletoBuscado.TiempoEnDias}, FECHA DE REGRESO: {boletoBuscado.FechaRegreso}, ID-BOLETO: {boletoBuscado.IdBoleto}");
                    }
                    else
                    {
                        Console.WriteLine("Opción no válida. Intente nuevamente.");
                    }
                }
                catch (FormatoGuidException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (BoletoNoEncontradoException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error al buscar el boleto: {ex.Message}");
                }

                Console.WriteLine("¿Desea realizar nuevamente la búsqueda? [SI/NO]");
                opcionBusqueda = Console.ReadLine().ToUpper();
            }
            while (opcionBusqueda == "SI");

            Console.WriteLine("\n ¡GRACIAS POR USAR EL SISTEMA!");

        }
    }
}
