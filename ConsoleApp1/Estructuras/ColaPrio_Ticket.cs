using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class ColaPrio_Ticket
    {

        public Ticket colaPrio;
        public static int codigoTicket = 202400001;
        public ColaPrio_Ticket()
        {
            colaPrio = null;
        }
        public void ActulizarCola(Ticket listaTicket)
        {
            colaPrio = listaTicket;
        }

        public void AgregarTicketPrioridad(string nombre, string descripcion, int codigoDueño, string categoria, int prioridadNum, string prioridadDes)
        {
            string condicion = "En espera";
            string respuestaSolucion = " ";
            int codigoTrabajador = 0;
            DateTime fechaCreacion = DateTime.Now;
            DateTime fechaRespuesta = DateTime.Now;

            Ticket q = new Ticket(nombre, codigoTicket, condicion, descripcion, fechaCreacion, respuestaSolucion, codigoDueño, categoria, fechaRespuesta, codigoTrabajador, prioridadNum, prioridadDes);
            Ticket t = colaPrio, ant = null;
           
            codigoTicket++;

            if (colaPrio == null)
            {
                colaPrio = q;
            }
            else
            {
                while (t != null)
                {
                    if ((prioridadNum <= t.prioridadNum))
                    {
                        if (t != colaPrio)
                        {
                            ant.sgte = q;
                            q.sgte = t;
                            return;
                        }
                        else
                        {
                            q.sgte = colaPrio;
                            colaPrio = q;
                            return;
                        }
                    }
                    if (t.sgte == null)
                    {
                        t.sgte = q;
                        return;
                    }
                    ant = t;
                    t = t.sgte;
                }
            }
        }
        public Ticket EliminarTicketPrioridad(Papelera_Tickets papelera)
        {
            Ticket t = colaPrio;
            Ticket ant = null;
            Ticket valor = null;
            if (colaPrio != null)
            {
                if (colaPrio.sgte == null)
                {
                    valor = t;
                    papelera.LlenarPapelera(colaPrio);
                    colaPrio = null;
                    Console.WriteLine("Ticket eliminado!");
                    Console.ReadLine();
                    return valor;
                }
                else
                {
                    while (t.sgte != null)
                    {
                        ant = t;
                        t = t.sgte;
                    }
                    valor = t;
                    papelera.LlenarPapelera(ant.sgte);
                    ant.sgte = null;
                    Console.WriteLine("Ticket eliminado!");
                    Console.ReadLine();
                    return valor;
                }
            }
            else
            {
                Console.WriteLine("Cola vacia ... ");
            }
            return null;
        }
        public void ImprimirTicketsPrio(PilaMostrarTicket pilaMostrar)
        {
            Ticket t = colaPrio;

            Console.WriteLine("| Código:".PadRight(10, ' ') + "  | Categoria:".PadRight(60, ' ') + "  | Descripción:".PadRight(60, ' ') + "    | Dueño:".PadRight(45, ' ') + "      | Código Dueño:".PadRight(15, ' ') + "  | Condición:".PadRight(15, ' ') + "    | Fecha creación:".PadRight(30, ' ') + "| Respuesta:".PadRight(30, ' ') + "| Nivel: ");
            Console.WriteLine("----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------");

            while (t != null)
            {

                Console.Write("\n| " + t.codigoTicket.ToString().PadRight(10, ' ') + "| " + t.categoria.PadRight(60, ' ') + "| " + t.descripcion.PadRight(60, ' ') + "| " + t.dueño.PadRight(45, ' ') + "| " + t.codigoDueño.ToString().PadRight(15, ' ') + "| " + t.condicion.PadRight(15, ' ') + "| " + t.fechaCreacion.ToString().PadRight(23, ' ') + " | " + t.respuestaSolucion.PadRight(30, ' ') + " | " + t.prioridadDes);

                t = t.sgte;
            }

        }
        public void ImprimirTicketsPorUsuarioPrio(int codigoBusqueda)
        {
            Ticket t = colaPrio;

            Console.WriteLine("| Código:".PadRight(10, ' ') + "  | Categoria:".PadRight(60, ' ') + "  | Descripción:".PadRight(60, ' ') + "    | Dueño:".PadRight(45, ' ') + "      | Condición:".PadRight(15, ' ') + "     | Fecha creación:".PadRight(30, ' ') + "  | Respuesta:");
            Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------");

            while (t != null)
            {

                if (t.codigoDueño == codigoBusqueda)
                {
                    Console.Write("\n| " + t.codigoTicket.ToString().PadRight(10, ' ') + "| " + t.categoria.PadRight(60, ' ') + t.descripcion.PadRight(60, ' ') + "| " + t.dueño.PadRight(45, ' ') + "| " + t.condicion.PadRight(15, ' ') + "| " + t.fechaCreacion.ToString().PadRight(25, ' ') + "| " + t.respuestaSolucion.PadRight(30, ' '));
                }

                t = t.sgte;
            }
        }
        public void MostrarTicketsResueltosPrio()
        {
            Ticket t = colaPrio;
            Console.WriteLine("       Tickets resueltos");
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("| Código:".PadRight(10, ' ') + "  | Categoria:".PadRight(60, ' ') + "  | Descripción:".PadRight(60, ' ') + "    | Dueño:".PadRight(45, ' ') + "      | Código Dueño:".PadRight(15, ' ') + "  | Condición:".PadRight(15, ' ') + "    | Fecha creación:".PadRight(30, ' ') + "| Respuesta:");
            Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------");

            while (t != null)
            {
                if (t.condicion == "Resuelto")
                {
                    Console.Write("\n| " + t.codigoTicket.ToString().PadRight(10, ' ') + "| " + t.categoria.PadRight(60, ' ') + "| " + t.descripcion.PadRight(60, ' ') + "| " + t.dueño.PadRight(45, ' ') + "| " + t.codigoDueño.ToString().PadRight(15, ' ') + "| " + t.condicion.PadRight(15, ' ') + "| " + t.fechaCreacion.ToString().PadRight(23, ' ') + " | " + t.respuestaSolucion.PadRight(30, ' '));
                }
                t = t.sgte;
            }
        }
        public void MostrarTicketsEsperaPrio()
        {
            Ticket t = colaPrio;


            Console.WriteLine("| Código:".PadRight(10, ' ') + "  | Categoria:".PadRight(60, ' ') + "  | Descripción:".PadRight(60, ' ') + "    | Dueño:".PadRight(45, ' ') + "      | Código Dueño:".PadRight(15, ' ') + "  | Condición:".PadRight(15, ' ') + "    | Fecha creación:".PadRight(30, ' ') + "| Respuesta:");
            Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------");

            while (t != null)
            {
                if (t.condicion == "En espera")
                {
                    Console.Write("\n| " + t.codigoTicket.ToString().PadRight(10, ' ') + "| " + t.categoria.PadRight(60, ' ') + "| " + t.descripcion.PadRight(60, ' ') + "| " + t.dueño.PadRight(45, ' ') + "| " + t.codigoDueño.ToString().PadRight(15, ' ') + "| " + t.condicion.PadRight(15, ' ') + "| " + t.fechaCreacion.ToString().PadRight(23, ' ') + " | " + t.respuestaSolucion.PadRight(30, ' '));
                }
                t = t.sgte;
            }
        }
        public void MostrarTicketsResueltosPorUsuarioPrio(int codigoBusqueda)
        {
            Ticket t = colaPrio;
            Console.WriteLine("       Tickets resueltos");
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("| Código:".PadRight(10, ' ') + "  | Categoria:".PadRight(60, ' ') + "  | Descripción:".PadRight(60, ' ') + "    | Dueño:".PadRight(45, ' ') + "      | Condición:".PadRight(15, ' ') + "     | Fecha creación:".PadRight(30, ' ') + "  | Respuesta:");
            Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
            while (t != null)
            {
                if (t.condicion == "Resuelto" && t.codigoDueño == codigoBusqueda)
                {
                    Console.Write("\n| " + t.codigoTicket.ToString().PadRight(10, ' ') + "| " + t.categoria.PadRight(60, ' ') + t.descripcion.PadRight(60, ' ') + "| " + t.dueño.PadRight(45, ' ') + "| " + t.condicion.PadRight(15, ' ') + "| " + t.fechaCreacion.ToString().PadRight(25, ' ') + "| " + t.respuestaSolucion.PadRight(30, ' '));
                }
                t = t.sgte;
            }
        }
        public void MostrarTicketsEsperaPorUsuarioPrio(int codigoBusqueda)
        {

            Ticket t = colaPrio;

            Console.WriteLine("| Código:".PadRight(10, ' ') + "  | Categoria:".PadRight(60, ' ') + "  | Descripción:".PadRight(60, ' ') + "    | Dueño:".PadRight(45, ' ') + "      | Condición:".PadRight(15, ' ') + "     | Fecha creación:".PadRight(30, ' ') + "  | Respuesta:");

            Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
            while (t != null)
            {
                if (t.condicion == "En espera" && t.codigoDueño == codigoBusqueda)
                {
                    Console.Write("\n| " + t.codigoTicket.ToString().PadRight(10, ' ') + "| " + t.categoria.PadRight(60, ' ') + t.descripcion.PadRight(60, ' ') + "| " + t.dueño.PadRight(45, ' ') + "| " + t.condicion.PadRight(15, ' ') + "| " + t.fechaCreacion.ToString().PadRight(25, ' ') + "| " + t.respuestaSolucion.PadRight(30, ' '));
                }
                t = t.sgte;
            }
        }
        public bool SaberSiExisteTicketPrio(int codigoBusqueda)
        {
            Ticket t = colaPrio;
            bool flag = false;

            while (t != null)
            {

                if (codigoBusqueda == t.codigoTicket) flag = true;

                t = t.sgte;
            }
            return flag;
        }
        public int CantidadTicketPorUsuarioPrio(int codigo)
        {
            int contador = 0;
            Ticket t = colaPrio;
            while (t != null)
            {
                if (codigo == t.codigoDueño) contador++;
                t = t.sgte;
            }
            return contador;
        }
        public int CantidadDeTicketsPrio()
        {
            Ticket t = colaPrio;
            int contador = 0;

            while (t != null)
            {
                contador++;
                t = t.sgte;
            }

            return contador;
        }
        public int CantidadTicketPorTipoPrio(string descripcion)
        {
            Ticket t = colaPrio;
            int contador = 0;
            while (t != null)
            {
                if (descripcion == t.descripcion) contador++;
                t = t.sgte;
            }
            return contador;
        }
        public void ImprimirTicketPorCadaTipoPrio(string descripcion)
        {
            Ticket t = colaPrio;
            int contador = 0;
            while (t != null)
            {
                if (t.descripcion == descripcion) contador++;
                t = t.sgte;
            }
            Console.Write("| " + descripcion.PadRight(60, ' ') + "| " + contador + "\n");
        }
        public Ticket BuscarTicketPrio(int codigo)
        {
            Ticket t = colaPrio;

            while (t != null)
            {
                if (t.codigoTicket == codigo)
                {
                    t = t;
                    break;
                }
                t = t.sgte;
            }

            return t;
        }
        public int CodigoEncargadoTicket(string descripcion)
        {
            Ticket t = colaPrio;
            int contador = 0;
            while (t != null)
            {
                if (descripcion == t.descripcion) contador++;
                t = t.sgte;
            }
            return contador;
        }
    }
}
