using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Reportes
    {
        public void GeneraReporte1(Lista_Tickets Lts, Lista_Alumnos Lu, ColaPrio_Ticket colitaPrio)
        {
            Console.Clear();
           
            int codigo, cantUser = 0, cantTicketPorUser;
            string nombre;

            cantUser = Lu.CantidadDeUsuarios();
         
            for(int i = 0; i < cantUser; i++)
            {
                codigo = Lu.ObtenerCodigoAleatorioUser(i);
                cantTicketPorUser =colitaPrio.CantidadTicketPorUsuarioPrio(codigo);      
                nombre = Lu.ObtenerNombreCompletoUser(codigo);
                Lu.CantidadTickets(cantTicketPorUser, codigo);
            }
            Lu.ImprimirReporte1();
            Console.ReadLine();
        }
        public void GeneraReporte2(Lista_Tickets LTick, ColaPrio_Ticket colitaPrio)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n\n");
            Console.WriteLine("\t\t\t\t\t\t\t\t| Tipo de ticket".PadRight(60,' ')+ "          | Cantidad de veces que se reporto");
            Console.WriteLine("\t\t\t\t\t\t\t\t----------------------------------------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.Yellow;
            colitaPrio.ImprimirTicketPorCadaTipoPrio("Falla de computadora en Laboratarios de Computo");
            colitaPrio.ImprimirTicketPorCadaTipoPrio("Falla de internet dentro del campus de la universidad");
            colitaPrio.ImprimirTicketPorCadaTipoPrio("Falla en comunicaciones entre redes institucionales");
            colitaPrio.ImprimirTicketPorCadaTipoPrio("Página web de la institución falla");

            Console.ReadLine();


        }
    }
}
