using DOMAIN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;

namespace primer_parcial
{
    internal class Program
    {
        static void Main(string[] args)
        {

            BoletoLogic boletoLogic = new BoletoLogic();

            int tipo;
            int cant_dias = 0;
            string fecha_regreso;
            DateTime fecha;
            string continuar;

            do
            {
                Console.WriteLine("\nINFORMACION COMERCIAL");
                Console.WriteLine("¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯ \n");
                Console.WriteLine(" COSTO BASE: $9950  \n COSTO TURISTA: $8400 \n COSTO EJECUTIVO: $9800 \n COSTO EMBARQUE: $900 \n");

                Console.WriteLine("-INGRESE TIPO DE BOLETO: [0=BASE]  [1=TURISTA]  [2=EJECUTIVO]");
                tipo = int.Parse(Console.ReadLine());

                Console.WriteLine("-INGRESE FECHA DE SALIDA: DD/MM/YYYY");
                fecha = DateTime.Parse(Console.ReadLine());

                Console.WriteLine("-INGRESE DURACION DEL VIAJE EN DIAS: ");
                cant_dias = int.Parse(Console.ReadLine());

                fecha_regreso = boletoLogic.CalcularRegreso(cant_dias, fecha);

                Boleto boleto = boletoLogic.CrearBoleto(tipo);

                boleto.FechaSalida = fecha;
                boleto.TiempoEnDias = cant_dias;
                boleto.FechaRegreso = DateTime.Parse(fecha_regreso);
                boleto.Costo_total = boletoLogic.ObtenerCostoBoleto(boleto);
                boletoLogic.AddBoleto(boleto);

                // Estructura de control, cada iteración del foreach toma un boleto de la lista y lo almacena en item
                // Se imprimen sus datos en consola hasta recorrer todos los boletos.
                foreach (var item in boletoLogic.GetAllBoletos())
                {
                    Console.WriteLine($"FECHA DE SALIDA: {item.FechaSalida}, COSTO TOTAL: {item.Costo_total}, CANTIDAD DE DIAS: {item.TiempoEnDias}, FECHA DE REGRESO: {item.FechaRegreso}");
                }
                Console.ReadKey();

                Console.WriteLine("\n¿DESEA SEGUIR GENERANDO PASAJES? [SI/NO]");
                continuar = Console.ReadLine().ToUpper();
            }
            while (continuar == "SI");

        }
    }
}
