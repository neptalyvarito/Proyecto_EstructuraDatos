using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class GenerarTicket
    {
        Validaciones validacion = new Validaciones();
        public void GenerarTickesito(string categoria, string nombreCompleto, ColaPrio_Ticket colaPrio, int codigoDelCreador, int tipoIngresante, string nivel)
        {
            bool verificacion;
            do
            {

                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine(" Categoria Seleccionada:  " + categoria);
                Console.WriteLine("======================================================================");
                Console.WriteLine(" Proporciona una breve descripción de tu incidente : ");
                Console.WriteLine("======================================================================");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("\n >  Ingrese qué problemas está teniendo: ");
                Console.Write("\n    ");
                string descripcion = Console.ReadLine();

                verificacion = validacion.ValidacionDeCadenaVaciaEIngresoNum2(descripcion);
                if (descripcion == "2")
                {
                    break;
                }
                else if (verificacion == true)
                {
                    colaPrio.AgregarTicketPrioridad(nombreCompleto, descripcion, codigoDelCreador, categoria, tipoIngresante, nivel);
                    Console.WriteLine("  ->  Su ticket ha sido creado con exito!");
                    Console.ReadLine();
                }
                else if (verificacion == false)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("\n... El ingreso de descripcón del ticket no puede estar en blanco");
                    Console.ReadLine();
                }

            } while (verificacion != true);
        }
    }
}
