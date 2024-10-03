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
        public void GeneraReporte1(Lista_Tickets Lts, Lista_Usuarios Lu)
        {
            Console.Clear();
           
            int codigo, cantUser = 0, cantTicketPorUser;
            string nombre;

            cantUser = Lu.CantidadDeUsuarios();
         
            for(int i = 0; i < cantUser; i++)
            {
                codigo = Lu.ObtenerCodigoAleatorioUser(i);
                cantTicketPorUser =Lts.Holiwi(codigo);      
                nombre = Lu.ObtenerNombreCompletoUser(codigo);
                Lu.CantidadTickets(cantTicketPorUser, codigo);
            }
            Lu.ImprimirReporte1();
            Console.ReadLine();
        }
        public void GeneraReporte2(Lista_Tickets LTick)
        {
            Console.Clear();
            Console.WriteLine("| Tipo de ticket".PadRight(60,' ')+ "  | Cantidad de veces que se reporto");
            Console.WriteLine("----------------------------------------------------------------------------------------");
            LTick.ImprimirTicketPorCadaTipo("Falla de computadora en Laboratarios de Computo");
            LTick.ImprimirTicketPorCadaTipo("Falla de internet dentro del campus de la universidad");
            LTick.ImprimirTicketPorCadaTipo("Falla en comunicaciones entre redes institucionales");
            LTick.ImprimirTicketPorCadaTipo("Página web de la institución falla");

            Console.ReadLine();


        }
    }
}
