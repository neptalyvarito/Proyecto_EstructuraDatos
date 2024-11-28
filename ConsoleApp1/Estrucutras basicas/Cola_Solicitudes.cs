using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Cola_Solicitudes
    {
        public static int codigo = 222400001;
        public Solicitudes frente;
        public Solicitudes cola;
        public Cola_Solicitudes()
        {

        }
        public void AgregarSolicitud(string solicitante, string tipoSolicitud, string destinatario, int codigoDueño)
        {
            string condicion = "En espera";
            string mensajeParaUsuario = " ";
            Solicitudes p = new Solicitudes(codigo, codigoDueño, solicitante, tipoSolicitud, destinatario, condicion, mensajeParaUsuario);

            if (frente == null)
            {
                frente = p;
            }
            else
            {
                cola.sgte = p;
            }
            cola = p;

            codigo++;
        }

        public Solicitudes EliminarSolicitud()
        {
            Solicitudes p, retornar;
            if (frente == null)
            {
                Console.WriteLine("Cola esta vacia");
                Console.ReadLine();
                return null; 
            }
            else
            {
                retornar = frente;
                frente = frente.sgte;
                return retornar;
            }
        }
        public void EliminarTodasSolicitudes()
        {
            frente = null;
            cola = null;
            Console.WriteLine("Cola eliminada con exito!");
            Console.ReadLine();
        }
        
        public void MostrarSolicitudes()
        {
            Solicitudes p = frente;
            if (frente == null)
            {
                Console.WriteLine(" Cola vacia");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine(" Código ".PadRight(14, ' ') + " | Solicitante".PadRight(28, ' ') + " | Código Solicitante".PadRight(28, ' ') + " | Tipo Solicitud".PadRight(45, ' ') + "    | Destinatario".PadRight(40, ' ') + "       | Condicion".PadRight(28, ' ') + "       | Mensaje".PadRight(28, ' '));
                while (p != null)
                {
                    Console.WriteLine(" " + p.codigoSolicitud.ToString().PadRight(14, ' ') + "|  " + p.solicitante.PadRight(25, ' ') + "| " + p.codigoDueno.ToString().PadRight(25, ' ') + " | " + p.tipoSolicitud.PadRight(45, ' ') + " | " + p.destinatario.PadRight(40, ' ') + " | " + p.condicion.PadRight(25, ' ') + " | " + p.mensajeParaUsuario.PadRight(26, ' '));
                    p = p.sgte;
                }
            }
            
        }
        public void MostrarSolicitudesPorUsuario(int codigoDueno)
        {
            Solicitudes p = frente;
            if (frente == null)
            {
                Console.WriteLine(" Cola vacia");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("\n\n\t\t\t\t\t\t\t\t\t\t\t\t\t-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
                Console.WriteLine("\n\n\t\t\t\t\t\t\t\t\t\t\t\t\t Código ".PadRight(14, ' ') + " | Solicitante".PadRight(28, ' ') + " | Código Solicitante".PadRight(28, ' ') + " | Tipo Solicitud".PadRight(45, ' ') + "    | Destinatario".PadRight(40, ' ') + "       | Condicion".PadRight(28, ' ') + "       | Mensaje".PadRight(28, ' '));
                Console.WriteLine("\n\n\t\t\t\t\t\t\t\t\t\t\t\t\t-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
                while (p != null)
                {
                    if (p.codigoDueno == codigoDueno)
                    {
                        Console.WriteLine("\n\n\t\t\t\t\t\t\t\t\t\t\t\t\t " + p.codigoSolicitud.ToString().PadRight(14, ' ') + "|  " + p.solicitante.PadRight(25, ' ') + "| " + p.codigoDueno.ToString().PadRight(25, ' ') + " | " + p.tipoSolicitud.PadRight(45, ' ') + " | " + p.destinatario.PadRight(40, ' ') + " | " + p.condicion.PadRight(25, ' ') + " | " + p.mensajeParaUsuario.PadRight(26, ' '));
                    }
                    p = p.sgte;
                }
            }
        }
        public Solicitudes AceptarORechazar(PilaParaSolicitudes pilaSoli)
        {
            Solicitudes p, retornar;
            if (frente == null)
            {
                Console.WriteLine("Cola esta vacia");
                Console.ReadLine();
                return null;
            }
            else
            {
                string mensaje;
                int opc = 0;
                do {

                    retornar = frente;

                    Console.WriteLine("\n\n\t\t\t\t\t\t\t\t\t\t\t\t\t        Detalles de la solicitud ");
                    Console.WriteLine("\n\n\t\t\t\t\t\t\t\t\t\t\t\t\t-----------------------------------------");
                    Console.WriteLine("\n\n\t\t\t\t\t\t\t\t\t\t\t\t\t Solicitante  : " + frente.solicitante);
                    Console.WriteLine("\n\n\t\t\t\t\t\t\t\t\t\t\t\t\t Destinatario : " + frente.destinatario);
                    Console.WriteLine("\n\n\t\t\t\t\t\t\t\t\t\t\t\t\t Solicitud    : " + frente.tipoSolicitud);
                    Console.WriteLine("\n\n\t\t\t\t\t\t\t\t\t\t\t\t\t------------------------------------------");
                    Console.WriteLine("\n\n\t\t\t\t\t\t\t\t\t\t\t\t\t 1. Aceptar  |  2. Rechazar  | 3. Volver  ");
                    Console.Write("\n\n\t\t\t\t\t\t\t\t\t\t\t\t\t > Ingrese una opción: ");
                    opc = int.Parse(Console.ReadLine());
                    switch (opc)
                    {
                        case 1:
                            frente.condicion = "Aprobada";
                            Console.Write("Ingrese un breve mensaje para el solicitantes: ");
                            mensaje = Console.ReadLine();
                            frente.mensajeParaUsuario = mensaje;
                            pilaSoli.AgregarSoli(frente);
                            Console.WriteLine("Solicitud respondida con exito");
                            Console.ReadLine();
                            opc = 0;
                            break;

                        case 2:
                            frente.condicion = "Rechazada";
                            Console.Write("Ingrese un breve mensaje para el solicitantes: ");
                            mensaje = Console.ReadLine();
                            frente.mensajeParaUsuario = mensaje;
                            pilaSoli.AgregarSoli(frente);
                            Console.WriteLine("Solicitud respondida con exito");
                            Console.ReadLine();
                            opc = 0;
                            break;

                        case 3:
                            Console.WriteLine(" No se ha respondido ninguna solicitud");
                            Console.ReadLine();
                            break;
                        default:
                            Console.WriteLine(" Ingrese una opción valida");
                            Console.ReadLine();
                            opc = 0;
                            break;
                    }

                } while (opc != 3 );
                frente = frente.sgte;
                return retornar;
            }
        }
    }
}
