using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Papelera_Tickets
    {
        public Ticket TicketsEliminados;
        public Ticket cola;

        public Papelera_Tickets()
        {
            TicketsEliminados = null;
        }

        public void LlenarPapelera(Ticket q)
        {
            Ticket t = new Ticket(q.dueño, q.codigoTicket, q.condicion, q.descripcion, q.fechaCreacion, q.respuestaSolucion, q.codigoDueño, q.categoria, q.fechaRespuesta, q.codigoTrabajadorEncargado, q.prioridadNum, q.prioridadDes);

            if (TicketsEliminados == null)
            {
                TicketsEliminados = t;
            }
            else
            {
                cola.sgte = t;
            }
            cola = t;
        }
        public void MostrarPapelera()
        {
            Ticket t = TicketsEliminados;

            Console.WriteLine("| Código:".PadRight(10, ' ') + "  | Categoria:".PadRight(60, ' ') + "  | Descripción:".PadRight(60, ' ') + "    | Dueño:".PadRight(45, ' ') + "      | Código Dueño:".PadRight(15, ' ') + "  | Condición:".PadRight(15, ' ') + "    | Fecha creación:".PadRight(30, ' ') + "| Respuesta:".PadRight(30, ' ') + "| Nivel: ");
            Console.WriteLine("----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------");

            while (t != null)
            {
                Console.Write("\n| " + t.codigoTicket.ToString().PadRight(10, ' ') + "| " + t.categoria.PadRight(60, ' ') + "| " + t.descripcion.PadRight(60, ' ') + "| " + t.dueño.PadRight(45, ' ') + "| " + t.codigoDueño.ToString().PadRight(15, ' ') + "| " + t.condicion.PadRight(15, ' ') + "| " + t.fechaCreacion.ToString().PadRight(23, ' ') + " | " + t.respuestaSolucion.PadRight(30, ' ') + " | " + t.prioridadDes);
                t = t.sgte;
            }
        }
        public void EliminarElementoPapelera()
        {
            Ticket q;
            int opc = 0;
            do
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("Está segudo que desea eliminar el ticket de forma permanente?");
                    Console.WriteLine("1. Si.");
                    Console.WriteLine("2. Volver.");
                    Console.Write(" -> Elija una opción: ");
                    opc = int.Parse(Console.ReadLine());
                    if (opc == 1)
                    {
                        if (TicketsEliminados == null)
                        {
                            Console.WriteLine("Papelera de tickets vacia ... ");
                            q = null;
                        }
                        else
                        {
                            q = TicketsEliminados;
                            TicketsEliminados = TicketsEliminados.sgte;
                            Console.WriteLine("Ticket con el código \""+ q.codigoTicket + "\" eliminado de forma permanente");
                        }
                    }
                    else if (opc == 2) break;
                }
                catch
                {
                    Console.WriteLine("Ingrese un tipo de dato valido");
                }
            } while (opc != 2);
        }
        public Ticket RestaurarElUltimoTicketIngresado()
        {
            Ticket q;
            if (TicketsEliminados == null)
            {
                Console.WriteLine("Papelera de tickets vacia ... ");
                q = null;
            }
            else
            {
                q = TicketsEliminados;
                TicketsEliminados = TicketsEliminados.sgte;
                Console.WriteLine("Ticket con el código \"" + q.codigoTicket + "\" restaurado");
                Console.ReadLine();
            }
            return q;
        }
    }
}
