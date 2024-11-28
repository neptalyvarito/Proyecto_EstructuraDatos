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
     
        public static Validaciones validación = new Validaciones();
        public Lista_Tickets() 
        { 
            listaTickets = null; 
        }
        public void LlenarLista(Ticket colaPrio)
        {
            listaTickets = colaPrio;
        }
        public void ImprimirTicket()
        {
            Ticket t = listaTickets;

            Console.WriteLine("| Código:".PadRight(10, ' ') + "  | Categoria:".PadRight(60, ' ') + "  | Descripción:".PadRight(60, ' ') + "    | Dueño:".PadRight(45, ' ') + "      | Código Dueño:".PadRight(15, ' ') + "  | Condición:".PadRight(15, ' ') + "    | Fecha creación:".PadRight(30, ' ') + "| Respuesta:");
            Console.WriteLine("----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------");

            while (t != null)
            {

                Console.Write("\n| " + t.codigoTicket.ToString().PadRight(10, ' ') + "| " + t.categoria.PadRight(60, ' ') + "| " + t.descripcion.PadRight(60, ' ') + "| " + t.dueño.PadRight(45, ' ') + "| " + t.codigoDueño.ToString().PadRight(15, ' ') + "| " + t.condicion.PadRight(15, ' ') + "| " + t.fechaCreacion.ToString().PadRight(23, ' ') + " | " + t.respuestaSolucion.PadRight(30, ' '));

                t = t.sgte;
            }
        }
        //public void EliminarTicket(ColaPrio_Ticket colaPr, Papelera_Tickets papelera, PilaMostrarTicket mostrarListaTick)
        //{
        
        //    Ticket q = listaTickets;
        //    Ticket t = listaTickets;
        //    string codigo;
        //    bool flag = false;
        //    do
        //    {
        //        Console.Clear();
        //        colaPr.ImprimirTicketsPrio(mostrarListaTick);
        //        Console.WriteLine("\n------------------------------------------------------------------");
        //        Console.WriteLine("|--- Para volver ingrese el número 2");
        //        Console.Write(" Ingrese el código del ticket a eliminar: ");
        //        codigo = Console.ReadLine();
        //        flag = validación.ValidacionIngresoSoloNum(codigo);


        //        if (codigo == "2")
        //        {
        //            break;
        //        }
        //        else if (flag == true)
        //        {
        //            flag = false;
        //            while (q != null)
        //            {
        //                if (q.codigoTicket == int.Parse(codigo))
        //                {
        //                    if (q == listaTickets)
        //                    {
        //                        papelera.LlenarPapelera(listaTickets);
        //                        listaTickets = null;
        //                        Console.WriteLine("\n....Ticket eliminado");
        //                        Console.ReadLine();
        //                        flag = true;
        //                        return;
        //                    }
        //                    else
        //                    {
        //                        t.sgte = q.sgte;
        //                        papelera.LlenarPapelera(q);
        //                        q = null;
        //                        Console.WriteLine("\n....Ticket eliminado");
        //                        Console.ReadLine();
        //                        flag = true;
        //                        return;
        //                    }
        //                }
        //                t = q;
        //                q = q.sgte;
        //            }
        //            if (flag == false)
        //            {
        //                Console.WriteLine("....Ticket no encontrado. \n....Ingrese el código correcto o el ingrese el número 2 para volver");
        //                Console.ReadLine();
        //            }

        //        }
        //        else if (flag == false)
        //        {
        //            Console.WriteLine("...Ingrese solo un valor númerico\n");
        //            Console.ReadLine();
        //        }
        //    } while (flag != true);
        //}
        public void ResponderTicket(ColaPrio_Ticket colitaPrio)
        {
            Ticket q = listaTickets;
            string solucion, codigo;
            bool verificacion;

            do
            {
                Console.Clear();
                colitaPrio.MostrarTicketsEsperaPrio();
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
                    verificacion = colitaPrio.SaberSiExisteTicketPrio(int.Parse(codigo));
                    if (verificacion == true)
                    {
                        do
                        {
                            Console.WriteLine("---------------------------------------------------------------");
                            Console.Write("\n Escriba la solución al problema (coloque su nombre y apellido): ");
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
    }
}
