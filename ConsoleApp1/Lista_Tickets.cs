using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Lista_Tickets
    {

        public Ticket listaTickets;
        public static int codigoTicket = 202400001;
        public static Validaciones validación = new Validaciones();
        public Lista_Tickets() 
        { 
            listaTickets = null; 
        }

        public void AgregarTicket(string nombre, string descripcion, int codigoDueño)
        {
            string condicion = "En espera";
            string respuestaSolucion= " ";
            DateTime fechaCreacion = DateTime.Now;

            Ticket q = new Ticket(nombre, codigoTicket, condicion, descripcion, fechaCreacion, respuestaSolucion, codigoDueño);

            Ticket t = listaTickets;

            if (listaTickets == null)
            {
                listaTickets = q;
            }
            else
            {
                while (t.sgte != null)
                {
                    t = t.sgte;
                }
                t.sgte = q;
            }
            codigoTicket++;
        } 

        public void ImprimirTickets()
        {
            Ticket t = listaTickets;

            Console.WriteLine("| Código:".PadRight(15, ' ') + "  | Descripción:".PadRight(60, ' ') + "    | Dueño:".PadRight(45, ' ') + "      | Código Dueño:".PadRight(15, ' ') + "  | Condición:".PadRight(15, ' ') + "    | Fecha creación:".PadRight(30, ' ') + "| Respuesta:");
            Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------");

            while (t != null)
            {
                
                Console.Write("\n| " + t.codigoTicket.ToString().PadRight(15, ' ') + "| " + t.descripcion.PadRight(60, ' ') + "| " + t.dueño.PadRight(45, ' ') + "| " + t.codigoDueño.ToString().PadRight(15, ' ') + "| " + t.condicion.PadRight(15, ' ') + "| " + t.fechaCreacion.ToString().PadRight(23, ' ') + " | "+t.respuestaSolucion.PadRight(30, ' '));

                t = t.sgte;
            }
        }
        public void ImprimirTicketsPorUsuario(int codigoBusqueda)
        {
            Ticket t = listaTickets;

            Console.WriteLine("| Código:".PadRight(15, ' ') + "  | Descripción:".PadRight(60, ' ') + "    | Dueño:".PadRight(45, ' ') + "      | Condición:".PadRight(15, ' ') + "     | Fecha creación:".PadRight(30, ' ') + "  | Respuesta:");
            Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------");

            while (t != null)
            {

                if (t.codigoDueño == codigoBusqueda)
                {
                    Console.Write("\n| " +t.codigoTicket.ToString().PadRight(15, ' ')+ "| " + t.descripcion.PadRight(60, ' ')+ "| " + t.dueño.PadRight(45, ' ')+ "| " + t.condicion.PadRight(15, ' ') + "| "+t.fechaCreacion.ToString().PadRight(25, ' ') + "| "+t.respuestaSolucion.PadRight(30, ' '));
                }

                t = t.sgte;
            }
        }
        public void EliminarTicket()
        {
        
            Ticket q = listaTickets;
            Ticket t = listaTickets;
            string codigo;
            bool flag = false;
            do
            {
                Console.Clear();
                ImprimirTickets();
                Console.WriteLine("\n------------------------------------------------------------------");
                Console.WriteLine("|--- Para volver ingrese el número 2");
                Console.Write(" Ingrese el código del ticket a eliminar: ");
                codigo = Console.ReadLine();
                flag = validación.ValidacionIngresoSoloNum(codigo);


                if (codigo == "2")
                {
                    break;
                }
                else if (flag == true)
                {
                    flag = false;
                    while (q != null)
                    {
                        if (q.codigoTicket == int.Parse(codigo))
                        {
                            if (q == listaTickets)
                            {
                                listaTickets = listaTickets.sgte;
                                Console.WriteLine("\n....Ticket eliminado");
                                Console.ReadLine();
                                flag = true;
                                return;
                            }
                            else
                            {
                                t.sgte = q.sgte;
                                q = null;
                                Console.WriteLine("\n....Ticket eliminado");
                                Console.ReadLine();
                                flag = true;
                                return;
                            }
                        }
                        t = q;
                        q = q.sgte;
                    }
                    if (flag == false)
                    {
                        Console.WriteLine("....Ticket no encontrado. \n....Ingrese el código correcto o el ingrese el número 2 para volver");
                        Console.ReadLine();
                    }

                }
                else if (flag == false)
                {
                    Console.WriteLine("...Ingrese solo un valor númerico\n");
                    Console.ReadLine();
                }
            } while (flag != true);
        }
        public void ResponderTicket()
        {
            Ticket q = listaTickets;
            string solucion, codigo;
            bool verificacion;

            do
            {
                Console.Clear();
                MostrarTicketsEspera();
                Console.WriteLine("\n-------------------------------------------------");
                Console.WriteLine("|--- Si desea volver, por favor ingrese el número 2");
                Console.Write("\n Escriba el código del ticket el cual desea responder: ");

                codigo = Console.ReadLine();

                verificacion = validación.ValidacionIngresoSoloNum(codigo);
                if (codigo == "2")
                {
                    break;
                }
                else if (verificacion == true)
                {
                    verificacion = SaberSiExisteTicket(int.Parse(codigo));
                    if (verificacion == true)
                    {
                        do
                        {
                            Console.WriteLine("-------------------------------------------------");
                            Console.Write("\n Escriba la solución al problema: ");
                            solucion = Console.ReadLine();
                            verificacion = validación.ValidacionDeCadenaVaciaEIngresoNum2(solucion);
                            if (solucion == "2")
                            {
                                break;
                            }
                            else if (verificacion == true)
                            {
                                while (q != null)
                                {
                                    if (q.codigoTicket.ToString() == codigo)
                                    {
                                        q.respuestaSolucion = solucion;
                                        q.condicion = "Resuelto";
                                        Console.WriteLine("La respuesta solución ha sido mandada con exito!");
                                        break;
                                    }
                                    q = q.sgte;
                                }
                                Console.ReadLine();
                            }
                            else if (verificacion == false)
                            {
                                Console.WriteLine("....La respuesta no puede estar vacia.");
                            }
                        } while (verificacion != true);
                    }
                    else
                    {
                        Console.WriteLine("....Ticket no encontrado");
                        Console.WriteLine("....Vuelva a ingresar el codigo o ingrese el número 2 para volver");
                    }
                }
                else if (verificacion == false)
                {
                    Console.WriteLine("....Por favor, ingrese solo caracteres númericos");
                    Console.ReadLine();
                }

            } while (verificacion != true);
        }
        public void MostrarTicketsResueltos()
        {
            Ticket t = listaTickets;
            Console.WriteLine("       Tickets resueltos");
            Console.WriteLine("-----------------------------------");

            Console.WriteLine("| Código:".PadRight(15, ' ') + "  | Descripción:".PadRight(60, ' ') + "    | Dueño:".PadRight(45, ' ') + "      | Código Dueño:".PadRight(15, ' ') + "  | Condición:".PadRight(15, ' ') + "    | Fecha creación:".PadRight(30, ' ') + "| Respuesta:");
            Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
         
            while (t != null)
            {
                if(t.condicion == "Resuelto")
                {
                    Console.Write("\n| " + t.codigoTicket.ToString().PadRight(15, ' ') + "| " + t.descripcion.PadRight(60, ' ') + "| " + t.dueño.PadRight(45, ' ') + "| " + t.codigoDueño.ToString().PadRight(15, ' ') + "| " + t.condicion.PadRight(15, ' ') + "| " + t.fechaCreacion.ToString().PadRight(23, ' ') + " | " + t.respuestaSolucion.PadRight(30, ' '));
                }
                t = t.sgte;
            }
        }
        public void MostrarTicketsEspera()
        {
            Ticket t = listaTickets;


            Console.WriteLine("| Código:".PadRight(15, ' ') + "  | Descripción:".PadRight(60, ' ') + "    | Dueño:".PadRight(45, ' ') + "      | Código Dueño:".PadRight(15, ' ') + "  | Condición:".PadRight(15, ' ') + "    | Fecha creación:".PadRight(30, ' ') + "| Respuesta:");
            Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------");

            while (t != null)
            {
                if (t.condicion == "En espera")
                {
                    Console.Write("\n| " + t.codigoTicket.ToString().PadRight(15, ' ') + "| " + t.descripcion.PadRight(60, ' ') + "| " + t.dueño.PadRight(45, ' ') + "| " + t.codigoDueño.ToString().PadRight(15, ' ') + "| " + t.condicion.PadRight(15, ' ') + "| " + t.fechaCreacion.ToString().PadRight(23, ' ') + " | " + t.respuestaSolucion.PadRight(30, ' '));
                }
                    t = t.sgte;
            }
        }
        public void MostrarTicketsResueltosPorUsuario(int codigoBusqueda)
        {
            Ticket t = listaTickets;
            Console.WriteLine("       Tickets resueltos");
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("| Código:".PadRight(15, ' ') + "  | Descripción:".PadRight(60, ' ') + "    | Dueño:".PadRight(45, ' ') + "      | Condición:".PadRight(15, ' ') + "     | Fecha creación:".PadRight(30, ' ') + "  | Respuesta:");
            Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
            while (t != null)
            {
                if (t.condicion == "Resuelto" && t.codigoDueño == codigoBusqueda)
                {
                    Console.Write("\n| " + t.codigoTicket.ToString().PadRight(15, ' ') + "| " + t.descripcion.PadRight(60, ' ') + "| " + t.dueño.PadRight(45, ' ') + "| " + t.condicion.PadRight(15, ' ') + "| " + t.fechaCreacion.ToString().PadRight(25, ' ') + "| " + t.respuestaSolucion.PadRight(30, ' '));
                }
                t = t.sgte;
            }
        }
        public void MostrarTicketsEsperaPorUsuario(int codigoBusqueda)
        {

            Ticket t = listaTickets;
            Console.WriteLine("| Código:".PadRight(15, ' ') + "  | Descripción:".PadRight(60, ' ') + "    | Dueño:".PadRight(45, ' ') + "      | Condición:".PadRight(15, ' ') + "     | Fecha creación:".PadRight(30, ' ') + "  | Respuesta:");
            Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
            while (t != null)
            {
                if (t.condicion == "En espera" && t.codigoDueño == codigoBusqueda)
                {
                    Console.Write("\n| " + t.codigoTicket.ToString().PadRight(15, ' ') + "| " + t.descripcion.PadRight(60, ' ') + "| " + t.dueño.PadRight(45, ' ') + "| " + t.condicion.PadRight(15, ' ') + "| " + t.fechaCreacion.ToString().PadRight(25, ' ') + "| " + t.respuestaSolucion.PadRight(30, ' '));
                }
                t = t.sgte;
            }
        }
        public bool SaberSiExisteTicket(int codigoBusqueda)
        {
            Ticket t = listaTickets;
            bool flag = false;

            while (t != null)
            {

               if(codigoBusqueda == t.codigoTicket) flag = true;

                t = t.sgte;
            }
            return flag;
        }
        public int Holiwi(int codigo)
        {
            int contador = 0;
            Ticket t = listaTickets;
            while (t != null)
            {
                if(codigo == t.codigoDueño) contador++;
                t = t.sgte;
            }
            return contador;
        }
        public int CantidadDeTickets()
        {
            Ticket t = listaTickets;
            int contador = 0;

            while (t != null)
            {
                contador++;
                t = t.sgte;
            }

            return contador;
        }
        public int CantidadTicketPorTipo(string descripcion)
        {
            Ticket t = listaTickets;
            int contador = 0;
            while(t!= null)
            {
                if (descripcion == t.descripcion) contador++;
                t= t.sgte;
            }
            return contador;
        }
        public void ImprimirTicketPorCadaTipo(string descripcion)
        {
            Ticket t = listaTickets;
            int contador = 0;
            while(t != null)
            {
                if (t.descripcion == descripcion) contador++;
                t = t.sgte;
            }
            Console.Write("| "+descripcion.PadRight(60, ' ') + "| " +contador+"\n");
        }
    }
}
