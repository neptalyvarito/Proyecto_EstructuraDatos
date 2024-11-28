using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Menu_Alumnos
    {
        public static Validaciones validacion = new Validaciones();
        public static GenerarTicket generarTikcetsito = new GenerarTicket();
        public static int codigoBusquedaUser;
        public static string nombreCompleto;
        public void Menu_Usuarios(int opc, Log_in inicioSesion, Lista_Alumnos Lu, Lista_Trabajadores LTra, Lista_Administrativos La, Lista_Tickets Ltick, Lista_Profes Lp, Cola_Solicitudes ColSol, ref int dniUser, ref int dniTrabajador, ref int dniAdmin, ref int dniProfe, Pila_Sugerencia PilaSug, ColaPrio_Ticket colaPrio, PilaParaSolicitudes pilaSoli)
        {
            bool verificacion = false;
            do
            {
                try
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("\n\n\t\t\t\t\t\t\t\t\t\t\t\t\t               Está iniciando sesión como alumno");
                    Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t===================================================================");
                    Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t  Llene los siguientes campos o ingrese el número 2 para volver");
                    Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t===================================================================");

                    verificacion = inicioSesion.InicioSesión(opc, Lu, LTra, La, Lp, ref dniUser, ref dniTrabajador, ref dniAdmin, ref dniProfe);
                    if (verificacion == false && (dniUser == 2 || dniAdmin == 2 || dniTrabajador == 2))
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
                        Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t....Número de DNI o contraseña incorrectos.");
                        Console.ReadLine();
                    }
                }
                catch
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("\n\t\t\t\t\t\t\t\t\t\t\t\t\t Error.... Dni debe contener solo caracteres númericos");
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
                        Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t Bienvenido alumno(a) " + nombreCompleto);
                        Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t================================================");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("\n\t\t\t\t\t\t\t\t\t\t\t\t\t >  1. Generar Ticket\n\n\t\t\t\t\t\t\t\t\t\t\t\t\t >  2. Ver todos mis tickets \n\n\t\t\t\t\t\t\t\t\t\t\t\t\t >  3. Ver mis tickets resueltos \n\n\t\t\t\t\t\t\t\t\t\t\t\t\t >  4. Ver mis tickets en espera \n\n\t\t\t\t\t\t\t\t\t\t\t\t\t >  5. Modificar mis datos \n\n\t\t\t\t\t\t\t\t\t\t\t\t\t >  6. Realizar Solicitud \n\n\t\t\t\t\t\t\t\t\t\t\t\t\t >  7. Ver mis solicitudes \n\n\t\t\t\t\t\t\t\t\t\t\t\t\t >  8. Realizar Sugerencias a la empresa \n\n\t\t\t\t\t\t\t\t\t\t\t\t\t >  9. Volver");
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("\n\t\t\t\t\t\t\t\t\t\t\t\t\t================================================");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("\n\t\t\t\t\t\t\t\t\t\t\t\t\t >  Elija una opción: ");
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
                                        switch (opc)
                                        {
                                            case 1:
                                                categoria = "\t\t\t\t\t\t\t\t\t\t\t\t\tVPN: Conexion, error en VPN";
                                                generarTikcetsito.GenerarTickesito(categoria, nombreCompleto, colaPrio, codigoBusquedaUser, 1, "Alumnos");
                                                break;
                                            case 2:
                                                categoria = "\t\t\t\t\t\t\t\t\t\t\t\t\tEquipos de computo y accesorios";
                                                generarTikcetsito.GenerarTickesito(categoria, nombreCompleto, colaPrio, codigoBusquedaUser, 1, "Alumnos");
                                                break;
                                            case 3:
                                                categoria = "\t\t\t\t\t\t\t\t\t\t\t\t\tRedes: Falla de conexión, lentitud, etc";
                                                generarTikcetsito.GenerarTickesito(categoria, nombreCompleto, colaPrio, codigoBusquedaUser, 1, "Alumnos");
                                                break;
                                            case 4:
                                                categoria = "\t\t\t\t\t\t\t\t\t\t\t\t\tSoftware: Teams, Windows, Office, etc"; 
                                                generarTikcetsito.GenerarTickesito(categoria, nombreCompleto, colaPrio, codigoBusquedaUser, 1, "Alumnos");
                                                break;
                                            case 5:
                                                categoria = "\t\t\t\t\t\t\t\t\t\t\t\t\tWifi: falla de conexión, etc";
                                                generarTikcetsito.GenerarTickesito(categoria, nombreCompleto, colaPrio, codigoBusquedaUser, 1, "Alumnos");
                                                break;
                                            case 6:
                                                categoria = "\t\t\t\t\t\t\t\t\t\t\t\t\tInternet: caida del servicio";
                                                generarTikcetsito.GenerarTickesito(categoria, nombreCompleto, colaPrio, codigoBusquedaUser, 1, "Alumnos");
                                                break;
                                            case 7:
                                                categoria = "\t\t\t\t\t\t\t\t\t\t\t\t\tCorreo: No envia ni recibe correo ";
                                                generarTikcetsito.GenerarTickesito(categoria, nombreCompleto, colaPrio, codigoBusquedaUser, 1, "Alumnos"); ;
                                                break;
                                            case 8:
                                                categoria = "\t\t\t\t\t\t\t\t\t\t\t\t\tAntivirus:AMP, Umbrell";
                                                generarTikcetsito.GenerarTickesito(categoria, nombreCompleto, colaPrio, codigoBusquedaUser, 1, "Alumnos");
                                                break;
                                            case 9: // sale de do while
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

                                Console.Clear();
                                colaPrio.ImprimirTicketsPorUsuarioPrio(codigoBusquedaUser);
                                Console.ReadLine();
                                opc = 0;
                                break;

                            case 3:

                                Console.Clear();
                                colaPrio.MostrarTicketsResueltosPorUsuarioPrio(codigoBusquedaUser);
                                Console.ReadLine();
                                opc = 0;
                                break;

                            case 4:

                                Console.Clear();
                                colaPrio.MostrarTicketsEsperaPorUsuarioPrio(codigoBusquedaUser);
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
                                        Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t            Modificando mis datos            ");
                                        Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t=============================================");
                                        Console.ForegroundColor = ConsoleColor.Yellow;
                                        Console.WriteLine("\n\t\t\t\t\t\t\t\t\t\t\t\t\t >  1. Modificar mis nombres\n\n\t\t\t\t\t\t\t\t\t\t\t\t\t >  2. Modificar mis apellidos \n\n\t\t\t\t\t\t\t\t\t\t\t\t\t >  3. Modificar mi de número celular\n\n\t\t\t\t\t\t\t\t\t\t\t\t\t >  4. Modificar mi contraseña \n\n\t\t\t\t\t\t\t\t\t\t\t\t\t >  5. Volver");
                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                        Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t=============================================");
                                        Console.ForegroundColor = ConsoleColor.Yellow;
                                        Console.Write("\n\t\t\t\t\t\t\t\t\t\t\t\t\t >  Ingrese opción: ");
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
                                                    Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t                       Modificando mis datos        ");
                                                    Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t=======================================================================");
                                                    Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t|          Modificando nombres. Ingrese el número 2 para volver       |");
                                                    Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t=======================================================================");
                                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                                    Console.Write("\n\t\t\t\t\t\t\t\t\t\t\t\t\t >  Por favor ingrese los nuevos nombres: ");
                                                    Console.Write("\n\t\t\t\t\t\t\t\t\t\t\t\t\t    ");

                                                    modificacion1 = Console.ReadLine();

                                                    verificacion = validacion.ValidacionDeCadenaSoloLetras(modificacion1);
                                                    if (modificacion1 == "2") break;
                                                    else if (verificacion == true)
                                                    {
                                                        Lu.ModificarDatosUsers(modificacion1, modificacion2, codigoBusquedaUser, opc);
                                                        Console.WriteLine("\n\t\t\t\t\t\t\t\t\t\t\t\t\t  ->  ¡Nombres modificados con exito!");
                                                        Console.ReadLine();
                                                    }
                                                    else if (verificacion == false)
                                                    {
                                                        Console.ForegroundColor = ConsoleColor.DarkRed;
                                                        Console.Write("\n\t\t\t\t\t\t\t\t\t\t\t\t\t... Los nombres no pueden quedar vacios y no deben tener caracteres númericos\n... O ingrese el número 2 para salir.");
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
                                                    Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t                         Modificando mis datos                         ");
                                                    Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t=======================================================================");
                                                    Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t|         Modificando apellidos. Ingrese el número 2 para volver      |");
                                                    Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t=======================================================================");
                                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                                    Console.Write("\t\t\t\t\t\t\t\t\t\t\t\t\t >  Por favor ingrese los nuevos apellidos: ");
                                                    Console.Write("\t\t\t\t\t\t\t\t\t\t\t\t\t\n    ");
                                                    modificacion1 = Console.ReadLine();

                                                    verificacion = validacion.ValidacionDeCadenaSoloLetras(modificacion1);

                                                    if (modificacion1 == "2") break;

                                                    else if (verificacion == true)
                                                    {
                                                        Lu.ModificarDatosUsers(modificacion1, modificacion2, codigoBusquedaUser, opc);
                                                        Console.WriteLine("\n\t\t\t\t\t\t\t\t\t\t\t\t\t  ->  Apellidos modificados con exito!");
                                                        Console.ReadLine();
                                                    }

                                                    else if (verificacion == false)
                                                    {
                                                        Console.ForegroundColor = ConsoleColor.DarkRed;
                                                        Console.Write("\t\t\t\t\t\t\t\t\t\t\t\t\t... Los apellidos no pueden quedar vacios y no deben tener caracteres númericos\n... O ingrese el número 2 para salir.");
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
                                                    Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t                           Modificando mis datos                       ");
                                                    Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t=======================================================================");
                                                    Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t|    Modificando número de celular. Ingrese el número 2 para volver   |");
                                                    Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t=======================================================================");
                                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                                    Console.WriteLine("\n\t\t\t\t\t\t\t\t\t\t\t\t\t >  Ingrese su nuevo número de celular: ");
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
                                                            Console.WriteLine("\n\t\t\t\t\t\t\t\t\t\t\t\t\t  ->  Número de celular modificado con exito!");
                                                            Console.ReadLine();
                                                        }
                                                        else if (verificacion == false)
                                                        {
                                                            Console.ForegroundColor = ConsoleColor.DarkRed;
                                                            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t... La longitud del número de celular debe ser de 9 caracteres númericos\n");
                                                            Console.ReadLine();
                                                        }

                                                    }
                                                    else
                                                    {
                                                        Console.ForegroundColor = ConsoleColor.DarkRed;
                                                        Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t... La variable debe poseer solo caracteres de tipo númericos");
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
                                                    Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t                         Modificando mis datos                         ");
                                                    Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t=======================================================================");
                                                    Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t|        Modificando contraseña. Ingrese el número 2 para volver      |");
                                                    Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t=======================================================================");
                                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                                    Console.Write("\t\t\t\t\t\t\t\t\t\t\t\t\t >  Ingrese nueva contraseña: ");
                                                    modificacion1 = Console.ReadLine();

                                                    verificacion = validacion.ValidacionDeCadenaVaciaEIngresoNum2(modificacion1);

                                                    if (modificacion1 == "2") break;

                                                    else if (verificacion == true)
                                                    {
                                                        Lu.ModificarDatosUsers(modificacion1, modificacion2, codigoBusquedaUser, opc);
                                                        Console.WriteLine("\n\t\t\t\t\t\t\t\t\t\t\t\t\t  ->  Contraseña modificada con exito!");
                                                        Console.ReadLine();
                                                    }
                                                    else if (verificacion == false)
                                                    {
                                                        Console.ForegroundColor = ConsoleColor.DarkRed;
                                                        Console.Write("\t\t\t\t\t\t\t\t\t\t\t\t\t... La contraseña no debe estar vacia");
                                                        Console.ReadLine();
                                                    }
                                                } while (verificacion != true);

                                                opc = 0;
                                                break;

                                            case 5:
                                                break;

                                            default:
                                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                                Console.WriteLine("\n\t\t\t\t\t\t\t\t\t\t\t\t\t.. < Ingrese una opción valida >");
                                                Console.ReadLine();
                                                break;
                                        }
                                    }
                                    catch
                                    {
                                        Console.ForegroundColor = ConsoleColor.DarkRed;
                                        Console.Write("\n\t\t\t\t\t\t\t\t\t\t\t\t\t.. < Ingrese una opción valida >");
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
                                        Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t          Realizando solicitud ");
                                        Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t===========================================");
                                        Console.ForegroundColor = ConsoleColor.Yellow;
                                        Console.WriteLine("\n\t\t\t\t\t\t\t\t\t\t\t\t\t ¿ El usuario destinatario es usted ?");
                                        Console.WriteLine("\n\t\t\t\t\t\t\t\t\t\t\t\t\t >  1. Si");
                                        Console.WriteLine("\n\t\t\t\t\t\t\t\t\t\t\t\t\t >  2. No");
                                        Console.WriteLine("\n\t\t\t\t\t\t\t\t\t\t\t\t\t >  3. Volver");
                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                        Console.WriteLine("\n\t\t\t\t\t\t\t\t\t\t\t\t\t=========================================");
                                        Console.ForegroundColor = ConsoleColor.Yellow;
                                        Console.Write("\n\t\t\t\t\t\t\t\t\t\t\t\t\t >  Ingrese opcion: ");
                                        opc = int.Parse(Console.ReadLine());
                                        switch (opc)
                                        {
                                            case 1:
                                                do
                                                {
                                                    Console.ForegroundColor = ConsoleColor.Cyan;
                                                    Console.WriteLine("\n\t\t\t\t\t\t\t\t\t\t\t\t\t=========================================");
                                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                                    Console.WriteLine("\n\t\t\t\t\t\t\t\t\t\t\t\t\t  ¡Listo! ");
                                                    Console.Write("\n\t\t\t\t\t\t\t\t\t\t\t\t\t >  Ingresa tu solicitud: ");
                                                    Console.Write("\n\t\t\t\t\t\t\t\t\t\t\t\t\t    ");
                                                    string descripcion = Console.ReadLine();

                                                    verificacion = validacion.ValidacionDeCadenaVaciaEIngresoNum2(descripcion);
                                                    if (descripcion == "2")
                                                    {
                                                        break;
                                                    }
                                                    else if (verificacion == true)
                                                    {
                                                        ColSol.AgregarSolicitud(nombreCompleto, descripcion, nombreCompleto, codigoBusquedaUser);
                                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                                        Console.WriteLine("\n\t\t\t\t\t\t\t\t\t\t\t\t\t=====================================================");
                                                        Console.ForegroundColor = ConsoleColor.Yellow;
                                                        Console.WriteLine("\n\t\t\t\t\t\t\t\t\t\t\t\t\t  ->  ¡Tu solicitud ha sido enviada con exito!");
                                                        Console.ReadLine();
                                                    }
                                                    else if (verificacion == false)
                                                    {
                                                        Console.ForegroundColor = ConsoleColor.DarkRed;
                                                        Console.WriteLine("\n\t\t\t\t\t\t\t\t\t\t\t\t\t.. La solicitud no puede estar en blanco");
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
                                                    Console.Write("\n\n\n\t\t\t\t\t\t\t\t\t\t\t\t\t==================================================");
                                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                                    Console.Write("\n\t\t\t\t\t\t\t\t\t\t\t\t\t > Ingrese el codigo del destinatario:");
                                                    codigo = int.Parse(Console.ReadLine());
                                                    flag = Lu.SaberSiExisteUsuarioConCodigo(codigo);
                                                    if (flag == true)
                                                    {
                                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                                        Console.WriteLine("\n\t\t\t\t\t\t\t\t\t\t\t\t\t==================================================");
                                                        Console.ForegroundColor = ConsoleColor.Yellow;
                                                        Console.WriteLine("\n\t\t\t\t\t\t\t\t\t\t\t\t\t  ¡Listo! ");
                                                        Console.Write("\n\t\t\t\t\t\t\t\t\t\t\t\t\t >  Ingresa tu solicitud: ");
                                                        Console.Write("\n\t\t\t\t\t\t\t\t\t\t\t\t\t    ");
                                                        string descripcion = Console.ReadLine();

                                                        verificacion = validacion.ValidacionDeCadenaVaciaEIngresoNum2(descripcion);
                                                        if (descripcion == "2")
                                                        {
                                                            break;
                                                        }
                                                        else if (verificacion == true)
                                                        {
                                                            ColSol.AgregarSolicitud(nombreCompleto, descripcion, Lu.ObtenerNombreCompletoUser(codigo), codigoBusquedaUser);

                                                            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t==================================================");
                                                            Console.WriteLine("\n\t\t\t\t\t\t\t\t\t\t\t\t\t  ->  Tu solicitud ha sido enviada con exito");
                                                            Console.ReadLine();
                                                        }
                                                        else if (verificacion == false)
                                                        {
                                                            Console.ForegroundColor = ConsoleColor.DarkRed;
                                                            Console.WriteLine("\n\t\t\t\t\t\t\t\t\t\t\t\t\t... La solicitud no puede estar en blanco");
                                                            Console.ReadLine();
                                                        }
                                                    }
                                                    else
                                                    {
                                                        Console.ForegroundColor = ConsoleColor.DarkRed;
                                                        Console.WriteLine("\n\t\t\t\t\t\t\t\t\t\t\t\t\t... Usuario no encontrado!");
                                                        Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t... Ingrese de forma correcta el codigo del usuario destinatario");
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
                                        Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t.. < Ingrese una opción valida >");
                                    }
                                } while (verificacion != true);

                                break;

                            case 7:
                                ColSol.MostrarSolicitudesPorUsuario(codigoBusquedaUser);
                                pilaSoli.MostrarSugerenciaPorUser(codigoBusquedaUser);
                                Console.ReadLine();
                                break;

                            case 8:
                                do
                                {

                                    Console.Clear();
                                    Console.ForegroundColor = ConsoleColor.Cyan;
                                    Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t                Realizando sugerencia a la empresa                   ");
                                    Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t======================================================================");
                                    Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t    Sientase libre de expresar lo que guste, sugerencia es anonima    ");
                                    Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t======================================================================");
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.Write("\n\t\t\t\t\t\t\t\t\t\t\t\t\t >  Ingresa tu sugerencia: ");
                                    Console.Write("\n\t\t\t\t\t\t\t\t\t\t\t\t\t    ");
                                    string descripcion = Console.ReadLine();

                                    verificacion = validacion.ValidacionDeCadenaVaciaEIngresoNum2(descripcion);
                                    if (descripcion == "2")
                                    {
                                        break;
                                    }
                                    else if (verificacion == true)
                                    {
                                        PilaSug.AgregarSug(descripcion);
                                        Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t----------------------------------------------------");
                                        Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t  ->  Su sugerencia ha sido mandada con exito!");
                                        Console.ReadLine();
                                    }
                                    else if (verificacion == false)
                                    {
                                        Console.ForegroundColor = ConsoleColor.DarkRed;
                                        Console.WriteLine("\n\t\t\t\t\t\t\t\t\t\t\t\t\t... La sugerencia no debe quedar en blanco");
                                        Console.ReadLine();
                                    }

                                } while (verificacion != true);

                                break;

                            case 9:
                                do
                                {
                                    Console.Clear();
                                    Console.ForegroundColor = ConsoleColor.Cyan;
                                    Console.WriteLine("                 Realizando encuesta de satisfacción                   ");
                                    Console.WriteLine("======================================================================");
                                    Console.WriteLine("    Siéntase libre de expresar lo que guste, la encuesta es anónima    ");
                                    Console.WriteLine("======================================================================");
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.Write("\n >  ¿Está satisfecho(a) con la atención dada? (Sí/No): ");
                                    string satisfaccion = Console.ReadLine();

                                    verificacion = validacion.ValidacionDeCadenaVaciaEIngresoNum2(satisfaccion);
                                    if (satisfaccion == "2")
                                    {
                                        break;
                                    }
                                    else if (verificacion == true)
                                    {
                                        PilaSug.AgregarSug(satisfaccion);
                                        Console.WriteLine("----------------------------------------------------");
                                        Console.WriteLine("  ->  Su sugerencia ha sido mandada con exito!");
                                        Console.ReadLine();
                                    }
                                    else if (verificacion == false)
                                    {
                                        Console.ForegroundColor = ConsoleColor.DarkRed;
                                        Console.WriteLine("\n... Su respuesta no debe quedar en blanco");
                                        Console.ReadLine();
                                    }

                                } while (verificacion != true);
                        break;
                            case 10:
                                break;
                            default:
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.WriteLine("\n\t\t\t\t\t\t\t\t\t\t\t\t\t.. < Ingrese una opción valida >");
                                Console.ReadLine();
                                break;
                        }
                    }
                    catch
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.Write("\n\t\t\t\t\t\t\t\t\t\t\t\t\t.. < Ingrese una opción valida >");
                        Console.ReadLine();
                    }

                } while (opc != 9);
            }
        }
        public static void GeneraTicketUser(Lista_Tickets Ltick, string categoria, ColaPrio_Ticket colaPrio)
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
                    colaPrio.AgregarTicketPrioridad(nombreCompleto, descripcion, codigoBusquedaUser, categoria, 4, "Alumno");
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