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
        public static Validaciones validacion = new Validaciones();
        public static int codigoTicket = 202400001;
        public ColaPrio_Ticket()
        {
            colaPrio = null;
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
                    if ((t.prioridadNum <= prioridadNum))
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

        public void ResponderTicket(Cola_TicketsResueltos colaTickResueltos)
        {
            Ticket t = colaPrio;
            Ticket ant = null;
            Ticket valor = null;
            
            if (colaPrio != null)
            {
             
                if (colaPrio.sgte == null)
                {
                    Console.WriteLine("\n\n\t\t\t\t\t\t\t\t\t\t\t\t\t   Datos del ticket a responder ");
                    Console.WriteLine("\n\n\t\t\t\t\t\t\t\t\t\t\t\t\t-------------------------------------");
                    Console.WriteLine("\n\n\t\t\t\t\t\t\t\t\t\t\t\t\tPrioridad : " + colaPrio.prioridadDes);
                    Console.WriteLine("\n\n\t\t\t\t\t\t\t\t\t\t\t\t\tCodigo    : " + colaPrio.codigoTicket);
                    Console.WriteLine("\n\n\t\t\t\t\t\t\t\t\t\t\t\t\tDueño     : " + colaPrio.dueño);
                    Console.WriteLine("\n\n\t\t\t\t\t\t\t\t\t\t\t\t\tCategoria : " + colaPrio.categoria);
                    Console.WriteLine("\n\n\t\t\t\t\t\t\t\t\t\t\t\t\tProblema  : " + colaPrio.descripcion);
                    string solucion = responder();
                    if (solucion == "2")
                    {
                        Console.WriteLine("\n\n\t\t\t\t\t\t\t\t\t\t\t\t\tNo se respondido ningun ticket");
                        Console.ReadLine();
                    }
                    else
                    {
                        colaPrio.condicion = "Resuelto";
                        colaPrio.respuestaSolucion = solucion;
                        valor = t;
                    
                        colaTickResueltos.AgregarTicketResuelto(colaPrio);
                        colaPrio = null;
                        Console.WriteLine("\n\n\t\t\t\t\t\t\t\t\t\t\t\t\tTicket Respondido con exito!");
                        Console.ReadLine();
                    }
                }
                else
                {

                    Console.WriteLine("\n\n\t\t\t\t\t\t\t\t\t\t\t\t\t   Datos del ticket a responder ");
                    Console.WriteLine("\n\n\t\t\t\t\t\t\t\t\t\t\t\t\t-------------------------------------");
                    Console.WriteLine("\n\n\t\t\t\t\t\t\t\t\t\t\t\t\tPrioridad : " + colaPrio.prioridadDes);
                    Console.WriteLine("\n\n\t\t\t\t\t\t\t\t\t\t\t\t\tCodigo    : " + colaPrio.codigoTicket);
                    Console.WriteLine("\n\n\t\t\t\t\t\t\t\t\t\t\t\t\tDueño     : " + colaPrio.dueño);
                    Console.WriteLine("\n\n\t\t\t\t\t\t\t\t\t\t\t\t\tCategoria : " + colaPrio.sgte);
                    Console.WriteLine("\n\n\t\t\t\t\t\t\t\t\t\t\t\t\tProblema  : " + colaPrio.descripcion);
                    string solucion = responder();
                    if (solucion == "2")
                    {
                        Console.WriteLine("\n\n\t\t\t\t\t\t\t\t\t\t\t\t\tNo se respondido ningun ticket");
                        Console.ReadLine();
                    }
                    else
                    {
                        colaPrio.condicion = "Resuelto";
                        colaPrio.respuestaSolucion = solucion;
                        valor = t;
                        colaTickResueltos.AgregarTicketResuelto(colaPrio);
                        colaPrio = colaPrio.sgte;
                        Console.WriteLine("\n\n\t\t\t\t\t\t\t\t\t\t\t\t\tTicket respondido con exito!");
                        Console.ReadLine();
                    }

                }
            }
            else
            {
                Console.WriteLine("\n\n\t\t\t\t\t\t\t\t\t\t\t\t\tCola de tickets está vacia ... ");
                Console.ReadLine();
            }
            
        }
        public string responder()
        {
            string solucion = " ";
            bool verificacion;
            
            do
            {
                Console.WriteLine("\n\n\t\t\t\t\t\t\t\t\t\t\t\t\t---------------------------------------------------------------");
                Console.Write("\n\n\t\t\t\t\t\t\t\t\t\t\t\t\tEscriba la solución al problema : ");
                solucion = Console.ReadLine();
                verificacion = validacion.ValidacionDeCadenaVaciaEIngresoNum2(solucion);
                if (solucion == "2")
                {
                    break;
                }
                else if (verificacion == true)
                {
                    return solucion;
                }
                else if (verificacion == false)
                {
                    Console.WriteLine("....La respuesta no puede estar vacia.");
                }
            } while (verificacion != true);
            return solucion;
        }

        public void EliminarTicketPrioridad(Papelera_Tickets papelera)
        {
            Ticket t = colaPrio;
            Ticket valor = null;

            if (colaPrio != null)
            {
                if (colaPrio.sgte == null)
                {
                    valor = t;
                  
                    
                    Console.WriteLine("\n\n\t\t\t\t\t\t\t\t\t\t\t\t\t   ¡El ticket ha sido eliminado!");
                    Console.WriteLine("\n\n\t\t\t\t\t\t\t\t\t\t\t\t\t-------------------------------------");
                    Console.WriteLine("\n\n\t\t\t\t\t\t\t\t\t\t\t\t\tDueño       : " + colaPrio.dueño);
                    Console.WriteLine("\n\n\t\t\t\t\t\t\t\t\t\t\t\t\tPrioridad   : " + colaPrio.prioridadDes);
                    Console.WriteLine("\n\n\t\t\t\t\t\t\t\t\t\t\t\t\tDescripción : " + colaPrio.descripcion);
                    papelera.LlenarPapelera(colaPrio);
                    colaPrio = null;
                    Console.ReadLine();

                }
                else
                {
                    valor = colaPrio;
            
                    Console.WriteLine("\n\n\t\t\t\t\t\t\t\t\t\t\t\t\t   ¡El ticket ha sido eliminado!");
                    Console.WriteLine("\n\n\t\t\t\t\t\t\t\t\t\t\t\t\t-------------------------------------");
                    Console.WriteLine("\n\n\t\t\t\t\t\t\t\t\t\t\t\t\tDueño       : " + colaPrio.dueño);
                    Console.WriteLine("\n\n\t\t\t\t\t\t\t\t\t\t\t\t\tPrioridad   : " + colaPrio.prioridadDes);
                    Console.WriteLine("\n\n\t\t\t\t\t\t\t\t\t\t\t\t\tDescripción : " + colaPrio.descripcion);
                    papelera.LlenarPapelera(colaPrio);

                    colaPrio = colaPrio.sgte;
                    Console.ReadLine();

                }
            }
            else
            {
                Console.WriteLine("\n\n\t\t\t\t\t\t\t\t\t\t\t\t\tCola vacia ... ");
                Console.ReadLine();
     
            }
        }
        public void ImprimirTicketsPrio()
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
            Console.WriteLine("\n\t\t\t\t\t\t\t\t| " + descripcion.PadRight(60, ' ') + "| " + contador + "");
            int a = CantidadDeTicketsPrio();
            Console.Write("\n\t\t\t\t\t\t\t\t->:| ");
            for(int i = 0; i<contador; i++)
            {
                Console.Write("|");
            }
            for(int i = 0; i<(a-contador); i++)
            {
                Console.Write("I");
            }
            Console.ReadLine();
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
