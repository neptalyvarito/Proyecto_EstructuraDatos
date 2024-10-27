using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Menu_Clientes
    {
        public static Validaciones validacion = new Validaciones();

        public static int codigoBusquedaUser;
        public static string nombreCompleto;
        public void Menu_Usuarios(int opc, Log_in inicioSesion, Lista_Usuarios Lu, Lista_Trabajadores LTra, Lista_Administrativos La, Lista_Tickets Ltick, Cola_Solicitudes ColSol, ref Solicitudes q, ref int dniUser, ref int dniTrabajador, ref int dniAdmin, Pila_Sugerencia PilaSug)
        {
            bool verificacion = false;
            do
            {
                try
                {
                    Console.Clear();

                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("\n\n               Está iniciando sesión como alumno");
                    Console.WriteLine("===================================================================");
                    Console.WriteLine("  Llene los siguientes campos o ingrese el número 2 para volver");
                    Console.WriteLine("===================================================================");

                    verificacion = inicioSesion.InicioSesión(opc, Lu, LTra, La, ref dniUser, ref dniTrabajador, ref dniAdmin);
                    if (verificacion == false && (dniUser == 2 || dniAdmin == 2 || dniTrabajador == 2))
                    {
                        dniUser = 0;
                        dniAdmin = 0;
                        dniTrabajador = 0;
                        break;
                    }
                    else if (verificacion == false)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("....Número de DNI o contraseña incorrectos.");
                        Console.ReadLine();
                    }
                }
                catch
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("\n Error.... Dni debe contener solo caracteres númericos");
                    Console.ReadLine();
                }

            } while (verificacion == false);

            if (verificacion == true)
            {

                do
                {
                    try
                    {
                        Console.Clear();

                        codigoBusquedaUser = Lu.ObtenerCodigoUser(dniUser);
                        nombreCompleto = Lu.NombreCompletoUsuario(dniUser);

                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine(" Bienvenido alumno(a) " + nombreCompleto);
                        Console.WriteLine("================================================");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("\n >  1. Generar Ticket\n\n >  2. Ver todos mis tickets \n\n >  3. Ver mis tickets resueltos \n\n >  4. Ver mis tickets en espera \n\n >  5. Modificar mis datos \n\n >  6. Realizar Solicitud \n\n >  7. Ver mis solicitudes \n\n >  8. Realizar Sugerencias a la empresa \n\n >  9. Volver");
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("\n================================================");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("\n >  Elija una opción: ");
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
                                        Console.WriteLine("    Indicanos el servicio que presenta fallas");
                                        Console.WriteLine("====================================================");
                                        Console.ForegroundColor = ConsoleColor.Yellow;
                                        Console.WriteLine("\n >  1. VPN: Conexion, error en VPN");
                                        Console.WriteLine("\n >  2. Equipos de computo y accesorios");
                                        Console.WriteLine("\n >  3. Redes: Falla de conexión, lentitud, etc.");
                                        Console.WriteLine("\n >  4. Software: Teams, Windows, Office, etc. ");
                                        Console.WriteLine("\n >  5. Wifi: falla de conexión, etc.");
                                        Console.WriteLine("\n >  6. Internet: caida del servicio ");
                                        Console.WriteLine("\n >  7. Correo: No envia ni recibe correo ");
                                        Console.WriteLine("\n >  8. Antivirus:AMP, Umbrell");
                                        Console.WriteLine("\n >  9. Volver");
                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                        Console.WriteLine("\n====================================================");
                                        Console.ForegroundColor = ConsoleColor.Yellow;
                                        Console.Write("\n >  Elija una opción: ");
                                        opc = int.Parse(Console.ReadLine());
                                        switch (opc)
                                        {
                                            case 1:
                                                categoria = "VPN: Conexion, error en VPN";
                                                GeneraTicketUser(Ltick, categoria);
                                                break;
                                            case 2:
                                                categoria = "Equipos de computo y accesorios";
                                                GeneraTicketUser(Ltick, categoria);
                                                break;
                                            case 3:
                                                categoria = "Redes: Falla de conexión, lentitud, etc";
                                                GeneraTicketUser(Ltick, categoria);
                                                break;
                                            case 4:
                                                categoria = "Software: Teams, Windows, Office, etc";
                                                GeneraTicketUser(Ltick, categoria);
                                                break;
                                            case 5:
                                                categoria = "Wifi: falla de conexión, etc";
                                                GeneraTicketUser(Ltick, categoria);
                                                break;
                                            case 6:
                                                categoria = "Internet: caida del servicio";
                                                GeneraTicketUser(Ltick, categoria);
                                                break;
                                            case 7:
                                                categoria = "Correo: No envia ni recibe correo ";
                                                GeneraTicketUser(Ltick, categoria);
                                                break;
                                            case 8:
                                                categoria = "Antivirus:AMP, Umbrell";
                                                GeneraTicketUser(Ltick, categoria);
                                                break;
                                            case 9: // sale de do while
                                                break;
                                        }
                                    }
                                    catch
                                    {
                                        Console.ForegroundColor = ConsoleColor.DarkRed;
                                        Console.Write("\n\n.. < Ingrese un dato valido >");
                                        Console.ReadLine();
                                    }
                                    
                                } while (opc != 9);
                       
                                opc = 0;
                                break;

                            case 2:

                                Console.Clear();
                                Ltick.ImprimirTicketsPorUsuario(codigoBusquedaUser);
                                Console.ReadLine();
                                opc = 0;
                                break;

                            case 3:

                                Console.Clear();
                                Ltick.MostrarTicketsResueltosPorUsuario(codigoBusquedaUser);
                                Console.ReadLine();
                                opc = 0;
                                break;

                            case 4:

                                Console.Clear();
                                Ltick.MostrarTicketsEsperaPorUsuario(codigoBusquedaUser);
                                Console.ReadLine();
                                opc = 0;
                                break;

                            case 5:

                                do
                                {
                                    try
                                    {
                                        Console.Clear();
                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                        Console.WriteLine("            Modificando mis datos            ");
                                        Console.WriteLine("=============================================");
                                        Console.ForegroundColor = ConsoleColor.Yellow;
                                        Console.WriteLine("\n >  1. Modificar mis nombres\n\n >  2. Modificar mis apellidos \n\n >  3. Modificar mi de número celular\n\n >  4. Modificar mi contraseña \n\n >  5. Volver");
                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                        Console.WriteLine("=============================================");
                                        Console.ForegroundColor = ConsoleColor.Yellow;
                                        Console.Write("\n >  Ingrese opción: ");
                                        opc = int.Parse(Console.ReadLine());

                                        string modificacion1 = " ";
                                        int modificacion2 = 0;

                                        switch (opc)
                                        {
                                            case 1:
                                                do
                                                {
                                                    Console.Clear();
                                                    Console.ForegroundColor = ConsoleColor.Cyan;
                                                    Console.WriteLine("                       Modificando mis datos        ");
                                                    Console.WriteLine("=======================================================================");
                                                    Console.WriteLine("|          Modificando nombres. Ingrese el número 2 para volver       |");
                                                    Console.WriteLine("=======================================================================");
                                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                                    Console.Write("\n >  Por favor ingrese los nuevos nombres: ");
                                                    Console.Write("\n    ");

                                                    modificacion1 = Console.ReadLine();

                                                    verificacion = validacion.ValidacionDeCadenaSoloLetras(modificacion1);
                                                    if (modificacion1 == "2") break;
                                                    else if (verificacion == true)
                                                    {
                                                        Lu.ModificarDatosUsers(modificacion1, modificacion2, codigoBusquedaUser, opc);
                                                        Console.WriteLine("\n  ->  ¡Nombres modificados con exito!");
                                                        Console.ReadLine();
                                                    }
                                                    else if (verificacion == false)
                                                    {
                                                        Console.ForegroundColor = ConsoleColor.DarkRed;
                                                        Console.Write("\n... Los nombres no pueden quedar vacios y no deben tener caracteres númericos\n... O ingrese el número 2 para salir.");
                                                        Console.ReadLine();
                                                    }
                                                } while (verificacion != true);

                                                opc = 0;
                                                break;

                                            case 2:
                                                do
                                                {
                                                    Console.Clear();
                                                    Console.ForegroundColor = ConsoleColor.Cyan;
                                                    Console.WriteLine("                         Modificando mis datos                         ");
                                                    Console.WriteLine("=======================================================================");
                                                    Console.WriteLine("|         Modificando apellidos. Ingrese el número 2 para volver      |");
                                                    Console.WriteLine("=======================================================================");
                                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                                    Console.Write(" >  Por favor ingrese los nuevos apellidos: ");
                                                    Console.Write("\n    ");
                                                    modificacion1 = Console.ReadLine();

                                                    verificacion = validacion.ValidacionDeCadenaSoloLetras(modificacion1);

                                                    if (modificacion1 == "2") break;

                                                    else if (verificacion == true)
                                                    {
                                                        Lu.ModificarDatosUsers(modificacion1, modificacion2, codigoBusquedaUser, opc);
                                                        Console.WriteLine("\n  ->  Apellidos modificados con exito!");
                                                        Console.ReadLine();
                                                    }

                                                    else if (verificacion == false)
                                                    {
                                                        Console.ForegroundColor = ConsoleColor.DarkRed;
                                                        Console.Write("... Los apellidos no pueden quedar vacios y no deben tener caracteres númericos\n... O ingrese el número 2 para salir.");
                                                        Console.ReadLine();
                                                    }

                                                } while (verificacion != true);

                                                opc = 0;
                                                break;

                                            case 3:

                                                do
                                                {
                                                    string aux;

                                                    Console.Clear();
                                                    Console.ForegroundColor = ConsoleColor.Cyan;
                                                    Console.WriteLine("                           Modificando mis datos                       ");
                                                    Console.WriteLine("=======================================================================");
                                                    Console.WriteLine("|    Modificando número de celular. Ingrese el número 2 para volver   |");
                                                    Console.WriteLine("=======================================================================");
                                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                                    Console.WriteLine("\n >  Ingrese su nuevo número de celular: ");
                                                    aux = Console.ReadLine();

                                                    verificacion = validacion.ValidacionIngresoSoloNum(aux);

                                                    if (verificacion == true)
                                                    {
                                                        modificacion2 = int.Parse(aux);

                                                        verificacion = validacion.ValidacionIngresoNumeroCelular(modificacion2);

                                                        if (aux == "2") break;
                                                        else if (verificacion == true)
                                                        {
                                                            verificacion = true;
                                                            Lu.ModificarDatosUsers(modificacion1, modificacion2, codigoBusquedaUser, opc);
                                                            Console.WriteLine("\n  ->  Número de celular modificado con exito!");
                                                            Console.ReadLine();
                                                        }
                                                        else if (verificacion == false)
                                                        {
                                                            Console.ForegroundColor = ConsoleColor.DarkRed;
                                                            Console.WriteLine("... La longitud del número de celular debe ser de 9 caracteres númericos\n");
                                                            Console.ReadLine();
                                                        }

                                                    }
                                                    else
                                                    {
                                                        Console.ForegroundColor = ConsoleColor.DarkRed;
                                                        Console.WriteLine("... La variable debe poseer solo caracteres de tipo númericos");
                                                        Console.ReadLine();
                                                    }
                                                } while (verificacion != true);

                                                opc = 0;
                                                break;

                                            case 4:
                                                do
                                                {
                                                    Console.Clear();
                                                    Console.ForegroundColor = ConsoleColor.Cyan;
                                                    Console.WriteLine("                         Modificando mis datos                         ");
                                                    Console.WriteLine("=======================================================================");
                                                    Console.WriteLine("|        Modificando contraseña. Ingrese el número 2 para volver      |");
                                                    Console.WriteLine("=======================================================================");
                                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                                    Console.Write(" >  Ingrese nueva contraseña: ");
                                                    modificacion1 = Console.ReadLine();

                                                    verificacion = validacion.ValidacionDeCadenaVaciaEIngresoNum2(modificacion1);

                                                    if (modificacion1 == "2") break;

                                                    else if (verificacion == true)
                                                    {
                                                        Lu.ModificarDatosUsers(modificacion1, modificacion2, codigoBusquedaUser, opc);
                                                        Console.WriteLine("\n  ->  Contraseña modificada con exito!");
                                                        Console.ReadLine();
                                                    }
                                                    else if (verificacion == false)
                                                    {
                                                        Console.ForegroundColor = ConsoleColor.DarkRed;
                                                        Console.Write("... La contraseña no debe estar vacia");
                                                        Console.ReadLine();
                                                    }
                                                } while (verificacion != true);

                                                opc = 0;
                                                break;

                                            case 5:
                                                break;

                                            default:
                                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                                Console.WriteLine("\n.. < Ingrese una opción valida >");
                                                Console.ReadLine();
                                                break;
                                        }
                                    }
                                    catch
                                    {
                                        Console.ForegroundColor = ConsoleColor.DarkRed;
                                        Console.Write("\n.. < Ingrese una opción valida >");
                                        Console.ReadLine();
                                    }

                                } while (opc != 5);

                                opc = 0;
                                break;

                            case 6:
                                do
                                {
                                    try
                                    {
                                        Console.Clear();
                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                        Console.WriteLine("          Realizando solicitud ");
                                        Console.WriteLine("===========================================");
                                        Console.ForegroundColor = ConsoleColor.Yellow;
                                        Console.WriteLine("\n ¿ El usuario destinatario es usted ?");
                                        Console.WriteLine("\n >  1. Si");
                                        Console.WriteLine("\n >  2. No");
                                        Console.WriteLine("\n >  3. Volver");
                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                        Console.WriteLine("\n=========================================");
                                        Console.ForegroundColor = ConsoleColor.Yellow;
                                        Console.Write("\n >  Ingrese opcion: ");
                                        opc = int.Parse(Console.ReadLine());
                                        switch (opc)
                                        {
                                            case 1:
                                                do
                                                {
                                                    Console.ForegroundColor = ConsoleColor.Cyan;
                                                    Console.WriteLine("\n=========================================");
                                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                                    Console.WriteLine("\n  ¡Listo! ");
                                                    Console.Write("\n >  Ingresa tu solicitud: ");
                                                    Console.Write("\n    ");
                                                    string descripcion = Console.ReadLine();

                                                    verificacion = validacion.ValidacionDeCadenaVaciaEIngresoNum2(descripcion);
                                                    if (descripcion == "2")
                                                    {
                                                        break;
                                                    }
                                                    else if (verificacion == true)
                                                    {
                                                        ColSol.AgregarSolicitud(ref q, nombreCompleto,descripcion, nombreCompleto, codigoBusquedaUser);
                                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                                        Console.WriteLine("\n=====================================================");
                                                        Console.ForegroundColor = ConsoleColor.Yellow;
                                                        Console.WriteLine("\n  ->  ¡Tu solicitud ha sido enviada con exito!");
                                                        Console.ReadLine();
                                                    }
                                                    else if (verificacion == false)
                                                    {
                                                        Console.ForegroundColor = ConsoleColor.DarkRed;
                                                        Console.WriteLine("\n.. La solicitud no puede estar en blanco");
                                                        Console.ReadLine();
                                                    }
                                                    Console.Clear();
                                                } while (verificacion != true);
                                                break;

                                            case 2:
                                                bool flag;
                                                do
                                                {
                                                    Lu.MostrarListaUsuarios();
                                                    int codigo;
                                                    Console.ForegroundColor = ConsoleColor.Cyan;
                                                    Console.Write("\n\n\n==================================================");
                                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                                    Console.Write("\n > Ingrese el codigo del destinatario:");
                                                    codigo = int.Parse(Console.ReadLine());
                                                    flag = Lu.SaberSiExisteUsuarioConCodigo(codigo);
                                                    if (flag == true)
                                                    {
                                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                                        Console.WriteLine("\n==================================================");
                                                        Console.ForegroundColor = ConsoleColor.Yellow;
                                                        Console.WriteLine("\n  ¡Listo! ");
                                                        Console.Write("\n >  Ingresa tu solicitud: ");
                                                        Console.Write("\n    ");
                                                        string descripcion = Console.ReadLine();

                                                        verificacion = validacion.ValidacionDeCadenaVaciaEIngresoNum2(descripcion);
                                                        if (descripcion == "2")
                                                        {
                                                            break;
                                                        }
                                                        else if (verificacion == true)
                                                        {
                                                            ColSol.AgregarSolicitud(ref q, nombreCompleto, descripcion, Lu.ObtenerNombreCompletoUser(codigo), codigoBusquedaUser);

                                                            Console.WriteLine("==================================================");
                                                            Console.WriteLine("\n  ->  Tu solicitud ha sido enviada con exito");
                                                            Console.ReadLine();
                                                        }
                                                        else if (verificacion == false)
                                                        {
                                                            Console.ForegroundColor = ConsoleColor.DarkRed;
                                                            Console.WriteLine("\n... La solicitud no puede estar en blanco");
                                                            Console.ReadLine();
                                                        }
                                                    }
                                                    else
                                                    {
                                                        Console.ForegroundColor = ConsoleColor.DarkRed;
                                                        Console.WriteLine("\n... Usuario no encontrado!");
                                                        Console.WriteLine("... Ingrese de forma correcta el codigo del usuario destinatario");
                                                        Console.ReadLine();
                                                    }
                                                    Console.Clear();
                                                } while (flag != true);

                                                break;
                                            case 3:
                                                break;
                                        }
                                    }
                                    catch
                                    {
                                        Console.ForegroundColor = ConsoleColor.DarkRed;
                                        Console.WriteLine(".. < Ingrese una opción valida >");
                                    }
                                } while (verificacion != true);

                                break;

                            case 7:
                                ColSol.MostrarSolicitudesPorUsuario(q, codigoBusquedaUser);
                                Console.ReadLine();
                                break;

                            case 8:
                                do
                                {

                                    Console.Clear();
                                    Console.ForegroundColor = ConsoleColor.Cyan;
                                    Console.WriteLine("                 Realizando sugerencia a la empresa                   ");
                                    Console.WriteLine("======================================================================");
                                    Console.WriteLine("    Sientase libre de expresar lo que guste, sugerencia es anonima    ");
                                    Console.WriteLine("======================================================================");
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.Write("\n >  Ingresa tu sugerencia: ");
                                    Console.Write("\n    ");
                                    string descripcion = Console.ReadLine();

                                    verificacion = validacion.ValidacionDeCadenaVaciaEIngresoNum2(descripcion);
                                    if (descripcion == "2")
                                    {
                                        break;
                                    }
                                    else if (verificacion == true)
                                    {
                                        PilaSug.AgregarSug(descripcion);
                                        Console.WriteLine("----------------------------------------------------");
                                        Console.WriteLine("  ->  Su sugerencia ha sido mandada con exito!");
                                        Console.ReadLine();
                                    }
                                    else if (verificacion == false)
                                    {
                                        Console.ForegroundColor = ConsoleColor.DarkRed;
                                        Console.WriteLine("\n... La sugerencia no debe quedar en blanco");
                                        Console.ReadLine();
                                    }

                                } while (verificacion != true);

                                break;
                            
                            case 9:
                                break;
                            default:
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.WriteLine("\n.. < Ingrese una opción valida >" );
                                Console.ReadLine();
                                break;
                        }
                    }
                    catch
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.Write("\n.. < Ingrese una opción valida >");
                        Console.ReadLine();
                    }

                } while (opc != 9);
            }
        }
        public static void GeneraTicketUser(Lista_Tickets Ltick, string categoria)
        {
            bool verificacion;
            do
            {

                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine(" Categoria Seleccionada:  " + categoria);
                Console.WriteLine("======================================================================");
                Console.WriteLine(" Proporciona una breve descripción de tu incidente : ");
                Console.WriteLine("======================================================================");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("\n >  Ingrese qué problemas está teniendo: ");
                Console.Write("\n    ");
                string descripcion = Console.ReadLine();

                verificacion = validacion.ValidacionDeCadenaVaciaEIngresoNum2(descripcion);
                if (descripcion == "2")
                {
                    break;
                }
                else if (verificacion == true)
                {
                    Ltick.AgregarTicket(nombreCompleto, descripcion, codigoBusquedaUser, categoria);
                    Console.WriteLine("  ->  Su ticket ha sido creado con exito!");
                    Console.ReadLine();
                }
                else if (verificacion == false)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("\n... El ingreso de descripcón del ticket no puede estar en blanco");
                    Console.ReadLine();
                }

            } while (verificacion != true);

        }
    }
}            