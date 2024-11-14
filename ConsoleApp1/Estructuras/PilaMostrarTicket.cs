using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class PilaMostrarTicket
    {
        public Ticket pilaMostrar;

        public PilaMostrarTicket()
        {
            pilaMostrar = null;
        }
        
        public void LlenarPila(Ticket q)
        {
            if(pilaMostrar == null)
            {
                pilaMostrar = q;
              
            }
            else
            {
                q.sgte = pilaMostrar;
                pilaMostrar = q;
              
            }
        }
        public void ImprimirLisTicket()
        {
            Ticket t = pilaMostrar;

            Console.WriteLine("| Código:".PadRight(10, ' ') + "  | Categoria:".PadRight(60, ' ') + "  | Descripción:".PadRight(60, ' ') + "    | Dueño:".PadRight(45, ' ') + "      | Código Dueño:".PadRight(15, ' ') + "  | Condición:".PadRight(15, ' ') + "    | Fecha creación:".PadRight(30, ' ') + "| Respuesta:".PadRight(30, ' ') + "| Nivel: ");
            Console.WriteLine("----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------");

            while (t != null)
            {

                Console.Write("\n| " + t.codigoTicket.ToString().PadRight(10, ' ') + "| " + t.categoria.PadRight(60, ' ') + "| " + t.descripcion.PadRight(60, ' ') + "| " + t.dueño.PadRight(45, ' ') + "| " + t.codigoDueño.ToString().PadRight(15, ' ') + "| " + t.condicion.PadRight(15, ' ') + "| " + t.fechaCreacion.ToString().PadRight(23, ' ') + " | " + t.respuestaSolucion.PadRight(30, ' ') + " | " + t.prioridadDes);

                t = t.sgte;
            }
        }
    }
}
