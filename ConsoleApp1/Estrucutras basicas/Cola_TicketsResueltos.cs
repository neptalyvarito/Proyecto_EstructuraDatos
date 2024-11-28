using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Cola_TicketsResueltos
    {
        public Ticket frente;
        public Ticket cola;

        public Cola_TicketsResueltos()
        {
            cola = null;
        }

        public void AgregarTicketResuelto(Ticket q)
        {
            Ticket t = new Ticket(q.dueño, q.codigoTicket, q.condicion, q.descripcion, q.fechaCreacion, q.respuestaSolucion, q.codigoDueño, q.categoria, q.fechaRespuesta, q.codigoTrabajadorEncargado, q.prioridadNum, q.prioridadDes);

            if(frente == null)
            {
                frente = t;
            }
            else
            {
                cola.sgte = t;
            }
            cola = t;
        }   
        public void ImprimirTicketsResueltos()
        {
            Ticket q = frente;
            if (frente == null)
            {
                Console.WriteLine("\n\n\n\n\t\t\t\t\t\t Cola de tickets resueltos vacia");
            }
            else
            {
                while (q != null)
                {
                    Console.Write("\n| " + q.codigoTicket.ToString().PadRight(10, ' ') + "| " + q.categoria.PadRight(60, ' ') + "| " + q.descripcion.PadRight(60, ' ') + "| " + q.dueño.PadRight(45, ' ') + "| " + q.codigoDueño.ToString().PadRight(15, ' ') + "| " + q.condicion.PadRight(15, ' ') + "| " + q.fechaCreacion.ToString().PadRight(23, ' ') + " | " + q.respuestaSolucion.PadRight(30, ' '));
                    q = q.sgte;
                }
            }
        }

    }
}
