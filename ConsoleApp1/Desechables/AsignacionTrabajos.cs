using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class AsignacionTrabajos
    {
        public Tecnicos cabeza;
        public Tecnicos cola;

        public AsignacionTrabajos()
        {
            cabeza = null;
            cola = null;
        }

        public void LlenarListaDoble(Trabajador q)
        {
            while(q != null)
            {
                Tecnicos agregar = new Tecnicos(q);
                q = q.sgte;
            }
        }

        public void AsignacionTicket(int codigoTra, int codigoTicket, Lista_Tickets lt, ColaPrio_Ticket colitaPrio)
        {
            Tecnicos q = cabeza;
            Ticket t = colitaPrio.BuscarTicketPrio(codigoTicket);
            while (q != null)
            {
                if(q.datosTecnico.codigoTrabajador == codigoTra)
                {
                    q.ticketParaResolver = t;
                    t.codigoTrabajadorEncargado = codigoTra;
                }
                q = q.sgte;
            }
        }

        public void MostrarTicketPorTrabajor(int codigoTra, Ticket t, Lista_Tickets lt)
        {
            Tecnicos q = cabeza;
            Console.WriteLine("Dueño Ticket: ".PadRight(40,' ') + "| Encargado del ticket: ".PadRight(40,' ') + "| Código del encargado: ".PadRight(15,' ') + " | Estado del ticket".PadRight(15,' '));
            string nombre;
            while(q!= null)
            {
                if (q.datosTecnico.codigoTrabajador == codigoTra)
                {
                    nombre = q.datosTecnico.nombres + " " + q.datosTecnico.apellidos;
                }
            }
            
            while (t != null)
            {
                if (t.codigoTrabajadorEncargado == codigoTra)
                {
                    Console.WriteLine(t.dueño.PadRight(40, ' ') + "| " + (q.datosTecnico.nombres + " " + q.datosTecnico.apellidos).PadRight(40, ' ') + "| " + q.datosTecnico.codigoTrabajador.ToString().PadRight(15, ' ') + " |" + t.condicion);
                }

                t = t.sgte;
            }
        }
    }
}
