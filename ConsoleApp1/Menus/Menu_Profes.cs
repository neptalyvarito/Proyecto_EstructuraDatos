using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Menu_Profes
    {
        public static Program program = new Program();
        public static Validaciones validacion = new Validaciones();
        public static string nombreCompleto;
        public static GenerarTicket generarTicketsito = new GenerarTicket();
        public int codiguito;
        public void MenuProfes(int opc, Log_in inicioSesion, Lista_Alumnos Lu, Lista_Trabajadores LTra, Lista_Administrativos La, Lista_Tickets Ltick, Lista_Profes Lp, Cola_Solicitudes ColSol, ref Solicitudes q, Pila_Sugerencia PilSug, Registros registro, ref int dniUser, ref int dniTrabajador, ref int dniAdmin, ref int dniProfe, ColaPrio_Ticket colitaPrio)
        {
            bool verificacion = false;
            int opcMandar = 0;
            do
            {
                try
                {

                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("\n\n\t\t\t\t\t\t\t\t\t\t\t\t\t           Está iniciando sesión como Docente");
                    Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t===================================================================");
                    Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t  Llene los siguientes campos o ingrese el número 2 para volver");
                    Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t===================================================================");

                    verificacion = inicioSesion.InicioSesión(opc, Lu, LTra, La, Lp, ref dniUser, ref dniTrabajador, ref dniAdmin, ref dniProfe);

                    if (verificacion == false && (dniUser == 2 || dniAdmin == 2 || dniTrabajador == 2 || dniProfe == 2))
                    {
                        dniUser = 0;
                        dniAdmin = 0;
                        dniTrabajador = 0;
                        dniProfe = 0;
                        break;
                    }
                    else if (verificacion == false)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t... Número de DNI o contraseña incorrectos.");
                        Console.ReadLine();
                    }
                }
                catch
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t Error.... Dni debe contener solo caracteres númericos");
                    Console.ReadLine();
                }

            } while (verificacion == false);
            if (verificacion == true)
            {
                do
                {
                    Console.Clear();

                    nombreCompleto = Lp.ObtenerNombreCompletoProfe(dniProfe);
       
                    opc = 0;
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t Bienvenido señor " + nombreCompleto);
                    Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t===============================================");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\n\t\t\t\t\t\t\t\t\t\t\t\t\t >  1. Generar ticket");
                    Console.WriteLine("\n\t\t\t\t\t\t\t\t\t\t\t\t\t >  2. Volver");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("\n\t\t\t\t\t\t\t\t\t\t\t\t\t===============================================");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("\n\t\t\t\t\t\t\t\t\t\t\t\t\t >  Ingrese opción: ");
                    opc = int.Parse(Console.ReadLine());

                    switch (opc)
                    {
                        case 1:

                            do
                            {
                                try
                                {
                                    string categoria;

                                    Console.Clear();
                                    Console.ForegroundColor = ConsoleColor.Cyan;
                                    Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t    Indicanos el servicio que presenta fallas");
                                    Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t====================================================");
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.WriteLine("\n\t\t\t\t\t\t\t\t\t\t\t\t\t >  1. VPN: Conexion, error en VPN");
                                    Console.WriteLine("\n\t\t\t\t\t\t\t\t\t\t\t\t\t >  2. Equipos de computo y accesorios");
                                    Console.WriteLine("\n\t\t\t\t\t\t\t\t\t\t\t\t\t >  3. Redes: Falla de conexión, lentitud, etc.");
                                    Console.WriteLine("\n\t\t\t\t\t\t\t\t\t\t\t\t\t >  4. Software: Teams, Windows, Office, etc. ");
                                    Console.WriteLine("\n\t\t\t\t\t\t\t\t\t\t\t\t\t >  5. Wifi: falla de conexión, etc.");
                                    Console.WriteLine("\n\t\t\t\t\t\t\t\t\t\t\t\t\t >  6. Internet: caida del servicio ");
                                    Console.WriteLine("\n\t\t\t\t\t\t\t\t\t\t\t\t\t >  7. Correo: No envia ni recibe correo ");
                                    Console.WriteLine("\n\t\t\t\t\t\t\t\t\t\t\t\t\t >  8. Antivirus:AMP, Umbrell");
                                    Console.WriteLine("\n\t\t\t\t\t\t\t\t\t\t\t\t\t >  9. Volver");
                                    Console.ForegroundColor = ConsoleColor.Cyan;
                                    Console.WriteLine("\n\t\t\t\t\t\t\t\t\t\t\t\t\t====================================================");
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.Write("\n\t\t\t\t\t\t\t\t\t\t\t\t\t >  Elija una opción: ");
                                    opc = int.Parse(Console.ReadLine());

                                    codiguito = Lp.ObtenerCodigoProfe(dniTrabajador);

                                    switch (opc)
                                    {
                                        case 1:
                                            categoria = "VPN: Conexion, error en VPN";
                                            generarTicketsito.GenerarTickesito(categoria, nombreCompleto, colitaPrio, codiguito, 3, "Profesor");
                                            break;
                                        case 2:
                                            categoria = "Equipos de computo y accesorios";
                                            generarTicketsito.GenerarTickesito(categoria, nombreCompleto, colitaPrio, codiguito, 3, "Profesor");
                                            break;
                                        case 3:
                                            categoria = "Redes: Falla de conexión, lentitud, etc";
                                            generarTicketsito.GenerarTickesito(categoria, nombreCompleto, colitaPrio, codiguito, 3, "Profesor");
                                            break;
                                        case 4:
                                            categoria = "Software: Teams, Windows, Office, etc";
                                            generarTicketsito.GenerarTickesito(categoria, nombreCompleto, colitaPrio, codiguito, 3, "Profesor");
                                            break;
                                        case 5:
                                            categoria = "Wifi: falla de conexión, etc";
                                            generarTicketsito.GenerarTickesito(categoria, nombreCompleto, colitaPrio, codiguito, 3, "Profesor");
                                            break;
                                        case 6:
                                            categoria = "Internet: caida del servicio";
                                            generarTicketsito.GenerarTickesito(categoria, nombreCompleto, colitaPrio, codiguito, 3, "Profesor");
                                            break;
                                        case 7:
                                            categoria = "Correo: No envia ni recibe correo ";
                                            generarTicketsito.GenerarTickesito(categoria, nombreCompleto, colitaPrio, codiguito, 3, "Profesor");
                                            break;
                                        case 8:
                                            categoria = "Antivirus:AMP, Umbrell";
                                            generarTicketsito.GenerarTickesito(categoria, nombreCompleto, colitaPrio, codiguito, 3, "Profesor");
                                            break;
                                        case 9: 
                                            break;
                                    }
                                }
                                catch
                                {
                                    Console.ForegroundColor = ConsoleColor.DarkRed;
                                    Console.Write("\n\n\t\t\t\t\t\t\t\t\t\t\t\t\t.. < Ingrese un dato valido >");
                                    Console.ReadLine();
                                }

                            } while (opc != 9);

                            opc = 0;
                            break;

                        case 2:
                            break;

                        default:
                            break;
                    
                    }


                } while (opc != 2);


            }
        }
    }
}
