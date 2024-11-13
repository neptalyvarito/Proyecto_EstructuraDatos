using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Menu_Admin
    {
        public static Program program = new Program();
        public static Validaciones validacion = new Validaciones();
        public static Reportes reportes = new Reportes();
        public static string nombreCompleto;
        public void menuAdmin(int opc, Log_in inicioSesion, Lista_Alumnos Lu, Lista_Trabajadores LTra, Lista_Administrativos La, Lista_Tickets Ltick,Cola_Solicitudes ColSol, ref Solicitudes q, Pila_Sugerencia PilSug, Registros registro, ref int dniUser, ref int dniTrabajador, ref int dniAdmin, ColaPrio_Ticket colitaPrio)

        {
            bool verificacion = false;
            int opcMandar = 0;
            do
            {
                try
                {

                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("\n\n           Está iniciando sesión como administrador");
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
                        Console.WriteLine("... Número de DNI o contraseña incorrectos.");
                        Console.ReadLine();
                    }
                }
                catch 
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine(" Error.... Dni debe contener solo caracteres númericos");
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

                        nombreCompleto = La.NombreCompletoAmdin(dniAdmin);
                       
                        opc = 0;
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine(" Bienvenido señor " + nombreCompleto);
                        Console.WriteLine("===============================================");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("\n >  1. Gestionar alumnos");
                        Console.WriteLine("\n >  2. Gestionar trabajadores");
                        Console.WriteLine("\n >  3. Gestionar administrativos");
                        Console.WriteLine("\n >  4. Gestionar tickets");
                        Console.WriteLine("\n >  5. Gestionar solicitudes");
                        Console.WriteLine("\n >  6. Gestionar sugerencias");
                        Console.WriteLine("\n >  7. Generar Reporte");
                        Console.WriteLine("\n >  8. Volver");
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("\n===============================================");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("\n >  Ingrese opción: ");
                        opcMandar = int.Parse(Console.ReadLine());

                        switch (opcMandar)
                        {
                            case 1:
                                do
                                {
                                    try
                                    {
                                        Console.Clear();
                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                        Console.WriteLine("           Gestionando Alumnos");
                                        Console.WriteLine("==============================================");
                                        Console.ForegroundColor = ConsoleColor.Yellow;
                                        Console.WriteLine("\n >  1. Crear alumnos\n\n >  2. Ver lista de alumnos\n\n >  3. Modificar datos del alumno \n\n >  4. Eliminar alumno\n\n >  5. Volver");
                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                        Console.WriteLine("\n==============================================");
                                        Console.ForegroundColor = ConsoleColor.Yellow;
                                        Console.Write("\n >  Ingrese opción: ");
                                        opc = int.Parse(Console.ReadLine());

                                        switch (opc)
                                        {
                                            case 1:

                                                Console.Clear();
                                                registro.RegistroUsersTrabajadoresAdmins(Lu, LTra, La, opcMandar);
                                               
                                                opc = 0;
                                                break;

                                            case 2:

                                                Console.Clear();
                                                Lu.MostrarListaUsuarios();
                                                Console.ReadLine();
                                                opc = 0;
                                                break;
                                            case 3:

                                                do
                                                {

                                                    Console.Clear();
                                                    Lu.MostrarListaUsuarios();
                                                    int codigo;
                                                    string aux;
                                                    Console.ForegroundColor = ConsoleColor.Cyan;
                                                    Console.Write("\n============================================================================");
                                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                                    Console.Write("\n\n >  Ingrese el código del alumno del cual desea modificar datos: ");
                                                    aux = Console.ReadLine();

                                                    verificacion = validacion.ValidacionIngresoSoloNum(aux);

                                                    if (aux == "2")
                                                    {
                                                        break;
                                                    }
                                                    else if (verificacion == true)
                                                    {
                                                        codigo = int.Parse(aux);
                                                        verificacion = Lu.SaberSiExisteUsuarioConCodigo(codigo);
                                                        if (verificacion == true)
                                                        {
                                                            program.ModificacionUsuariosTrabajsYAdmins(codigo, opcMandar);
                                                        }
                                                        else
                                                        {
                                                            Console.ForegroundColor = ConsoleColor.DarkRed;
                                                            Console.WriteLine("\n... Alumno no econtrado.\n... Ingrese el código correcto o el ingrese el número 2 para volver.");
                                                            Console.ReadLine();
                                                        }
                                                    }
                                                    else if(verificacion == false)
                                                    {
                                                        Console.ForegroundColor = ConsoleColor.DarkRed;
                                                        Console.WriteLine("\n... El código debe contener solo caracteres númericos");
                                                        Console.ReadLine();
                                                    }
                                                } while ( verificacion != true);

                                                opc = 0;
                                                break;
                                            case 4:

                                                Console.Clear();
                                                Lu.EliminarUsuario();
                                                Console.ReadLine();
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
                                        Console.WriteLine("\n.. < Ingrese un dato valido >");
                                        Console.ReadLine();
                                    }

                                } while (opc != 5);

                                opc = 0;
                                break;

                            case 2:

                                do
                                {
                                    try
                                    {
                                        Console.Clear();
                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                        Console.WriteLine("      Gestionando Trabajadores");
                                        Console.WriteLine("============================================");
                                        Console.ForegroundColor = ConsoleColor.Yellow;
                                        Console.WriteLine("\n >  1. Crear trabajador\n\n >  2. Ver lista de trabajadorres \n\n >  3. Modificar datos del trabajador \n\n >  4. Eliminar trabajador\n\n >  5. Volver");
                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                        Console.WriteLine("\n============================================");
                                        Console.ForegroundColor = ConsoleColor.Yellow;
                                        Console.Write(" >  Ingrese opción: ");
                                        opc = int.Parse(Console.ReadLine());

                                        switch (opc)
                                        {
                                            case 1:

                                                Console.Clear();
                                                registro.RegistroUsersTrabajadoresAdmins(Lu, LTra, La, opcMandar);
                                               
                                                opc = 0;
                                                break;
                                            case 2:
                                                Console.Clear();
                                                LTra.MostrarListaTrabajadores();
                                                Console.ReadLine();
                                                opc = 0;
                                                break;
                                            case 3:
                                                do
                                                {

                                                    Console.Clear();
                                                    LTra.MostrarListaTrabajadores();
                                                    int codigo;
                                                    string aux;
                                                    Console.ForegroundColor = ConsoleColor.Cyan;
                                                    Console.Write("\n===============================================================================");
                                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                                    Console.Write("\n >  Ingrese el código del trabajador del cual desea modificar datos: ");
                                                    aux = Console.ReadLine();

                                                    verificacion = validacion.ValidacionIngresoSoloNum(aux);

                                                    if (aux == "2")
                                                    {
                                                        break;
                                                    }
                                                    else if (verificacion == true)
                                                    {
                                                        codigo = int.Parse(aux);
                                                        verificacion = LTra.SaberSiExisteTrabajadorConCodigo(codigo);
                                                        if (verificacion == true)
                                                        {
                                                            program.ModificacionUsuariosTrabajsYAdmins(codigo, opcMandar);
                                                        }
                                                        else
                                                        {
                                                            Console.ForegroundColor = ConsoleColor.DarkRed;
                                                            Console.WriteLine("... Trabajador no econtrado. Ingrese el código correcto o el ingrese el número 2 para volver");
                                                            Console.ReadLine();
                                                        }
                                                    }
                                                    else if (verificacion == false)
                                                    {
                                                        Console.ForegroundColor = ConsoleColor.Yellow;
                                                        Console.WriteLine("... El código debe contener solo caracteres númericos");
                                                        Console.ReadLine();
                                                    }
                                                } while (verificacion != true);
                                               
                                                opc = 0;
                                                break;
                                            case 4:

                                                Console.Clear();
                                                LTra.EliminarTrabajador();
                                                Console.ReadLine();
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
                                        Console.WriteLine("\n.. < Ingrese un dato valido >");
                                        Console.ReadLine();
                                    }

                                } while (opc != 5);

                                opc = 0;
                                break;

                            case 3:
                                do
                                {
                                    try
                                    {
                                        Console.Clear();
                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                        Console.WriteLine("       Gestionando Administrativos");
                                        Console.WriteLine("===========================================");
                                        Console.ForegroundColor = ConsoleColor.Yellow;
                                        Console.WriteLine("\n >  1. Crear administrativo\n\n >  2. Ver lista de administrativos \n\n >  3. Modificar datos del administrativo \n\n >  4. Elimar administrativo \n\n >  5. Volver");
                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                        Console.WriteLine("\n===========================================");
                                        Console.ForegroundColor = ConsoleColor.Yellow;
                                        Console.Write(" >  Ingrese opción: ");
                                        opc = int.Parse(Console.ReadLine());

                                        switch (opc)
                                        {
                                            case 1:

                                                Console.Clear();
                                                registro.RegistroUsersTrabajadoresAdmins(Lu, LTra, La, opcMandar);

                                                opc = 0;
                                                break;
                                            case 2:

                                                Console.Clear();
                                                La.MostrarListaAdministrativos();
                                                Console.ReadLine();

                                                opc = 0;
                                                break;
                                            case 3:
                                                do
                                                {

                                                    Console.Clear();
                                                    La.MostrarListaAdministrativos();
                                                    int codigo;
                                                    string aux;
                                                    Console.ForegroundColor = ConsoleColor.Cyan;
                                                    Console.Write("\n\n==================================================================================");
                                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                                    Console.Write("\n >  Ingrese el código del administrador del cual desea modificar datos: ");
                                                    aux = Console.ReadLine();

                                                    verificacion = validacion.ValidacionIngresoSoloNum(aux);

                                                    if (aux == "2")
                                                    {
                                                        break;
                                                    }
                                                    else if (verificacion == true)
                                                    {
                                                        codigo = int.Parse(aux);
                                                        verificacion = La.SaberSiExisteAdminConCodigo(codigo);
                                                        if (verificacion == true)
                                                        {
                                                            program.ModificacionUsuariosTrabajsYAdmins(codigo, opcMandar);
                                                        }
                                                        else
                                                        {
                                                            Console.ForegroundColor = ConsoleColor.DarkRed;
                                                            Console.WriteLine("\n... Administrador no econtrado.\n... Ingrese el código correcto o el ingrese el número 2 para volver");
                                                            Console.ReadLine();
                                                        }
                                                    }
                                                    else if (verificacion == false)
                                                    {
                                                        Console.ForegroundColor = ConsoleColor.DarkRed;
                                                        Console.WriteLine("\n... El código debe contener solo caracteres númericos");
                                                        Console.ReadLine();
                                                    }
                                                } while (verificacion != true);
                                               
                                                opc = 0;
                                                break;

                                            case 4:

                                                La.EliminarAdministrativos();
                                                Console.ReadLine();
                                                opc = 0;
                                                break;

                                            case 5:
                                                break;

                                            default:
                                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                                Console.WriteLine("\n.. < Ingrese un dato valido >");
                                                Console.ReadLine();
                                                break;

                                        }
                                    }
                                    catch
                                    {
                                        Console.ForegroundColor = ConsoleColor.DarkRed;
                                        Console.WriteLine("\n.. < Ingrese una opción valida > ");
                                        Console.ReadLine();
                                    }

                                } while (opc != 5);

                                opc = 0;
                                break;

                            case 4:

                                program.GestionTickets();

                                opc = 0;
                                break;
                            case 5:
                                do
                                {
                                    try
                                    {
                                        Console.Clear();
                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                        Console.WriteLine("        Gestionando solicitudes     ");
                                        Console.WriteLine("=======================================");
                                        Console.ForegroundColor = ConsoleColor.Yellow;
                                        Console.WriteLine("\n >  1. Ver todas las solicitudes");
                                        //Console.WriteLine(" 2. Confirmar o denegar solicitud");
                                        Console.WriteLine("\n >  2. Eliminar lista en orden");
                                        Console.WriteLine("\n >  3. Vaciar lista de solicitudes");
                                        Console.WriteLine("\n >  4. Volver");
                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                        Console.WriteLine("\n=======================================");
                                        Console.ForegroundColor = ConsoleColor.Yellow;
                                        Console.Write("\n >  Ingrese su opcion: ");
                                        opc = int.Parse(Console.ReadLine());
                                        switch (opc)
                                        {
                                            case 1:
                                                
                                                ColSol.MostrarSolicitudes(q);
                                                Console.ReadLine();
                                                break;
                                            
                                            case 2:
                                                if (q.Delante != null)
                                                {
                                                    Solicitudes muestra;
                                                    muestra = ColSol.EliminarSolicitud(ref q);
                                                    Console.ForegroundColor = ConsoleColor.Cyan;

                                                    Console.WriteLine("\n Se ha eliminado la primera solicitud en espera");
                                                    Console.WriteLine("\n Caracteristicas de solicitud eliminada: ");
                                                    Console.Write("\n\n Solicitante: ");

                                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                                    Console.Write(muestra.Solicitante);

                                                    Console.ForegroundColor = ConsoleColor.Cyan;
                                                    Console.Write("\n\n Destinatarios: ");
                                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                                    Console.Write(muestra.Destinatario);

                                                    Console.ForegroundColor = ConsoleColor.Cyan;
                                                    Console.Write("\n\n Tipo de Solicitud: ");
                                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                                    Console.Write(muestra.TipoSolicitud);

                                                    Console.ForegroundColor = ConsoleColor.Cyan;
                                                    Console.Write("\n\n Condicion: ");
                                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                                    Console.Write(muestra.Condicion);

                                                    Console.ForegroundColor = ConsoleColor.Cyan;
                                                    Console.Write("\n\n Mensaje: ");
                                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                                    Console.Write(muestra.MensajeParaUsuario);

                                                    Console.ReadLine();
                                                }
                                                else
                                                {
                                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                                    Console.WriteLine("\n  ¡Cola de solicitudes está vacia!");
                                                }
                                                Console.ReadLine();
                                                break;
                                            case 3:
                                                ColSol.EliminarTodasSolicitudes(ref q);
                                                Console.ForegroundColor = ConsoleColor.Yellow;
                                                Console.WriteLine("\n ¡Todas las solicitudes han sido eliminadas!");
                                                Console.ReadLine();
                                                break;
                                            case 4:
                                                break;
                                        }
                                    }
                                    catch
                                    {
                                        Console.ForegroundColor = ConsoleColor.DarkRed;
                                        Console.WriteLine("\n.. < Ingrese una opcion valida >");
                                    }
                                }
                                while (opc != 4);
                                opc = 0;
                                break;

                            case 6:

                                do
                                {
                                    try
                                    {
                                        Console.Clear();
                                        Sugerencias mostrar;
                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                        Console.WriteLine("         Gestionando sugerencias");
                                        Console.WriteLine("============================================");
                                        Console.ForegroundColor = ConsoleColor.Yellow;
                                        Console.WriteLine("\n >  1. Visualizar sugerencias");
                                        Console.WriteLine("\n >  2. Eliminar ultima sugerencia hecha");
                                        Console.WriteLine("\n >  3. Volver");
                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                        Console.WriteLine("\n============================================");
                                        Console.ForegroundColor = ConsoleColor.Yellow;
                                        Console.Write("\n >  Ingrese opción: ");
                                        opc = int.Parse(Console.ReadLine());
                                        switch (opc)
                                        {
                                            case 1:
                                                PilSug.MostrarSugerencia();
                                                Console.ReadLine();
                                                break;
                                            case 2:

                                                if (PilSug.sugerencia != null)
                                                {
                                                    mostrar = PilSug.QuitarSug();
                                                    Console.ForegroundColor = ConsoleColor.Cyan;
                                                    Console.WriteLine("\n\n  ¡Se ha removido la ulima sugerencia que ha sido agregada!");
                                                    Console.WriteLine("\n Especificaciones de la sugerencia: ");

                                                    Console.Write("\n\n Sugerencia:  ");
                                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                                    Console.Write(mostrar.sugerencia);

                                                    Console.ForegroundColor = ConsoleColor.Cyan;
                                                    Console.Write("\n\n Fecha de creación: ");
                                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                                    Console.Write(mostrar.fechaCreacion);

                                                    Console.ForegroundColor = ConsoleColor.Cyan;
                                                    Console.WriteLine("\n Tabla actualizada: \n\n");
                                                    PilSug.MostrarSugerencia();
                                                    Console.ReadLine();
                                                }
                                                else
                                                {
                                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                                    Console.WriteLine("\n  ¡Lista de sugerencias vacia!");
                                                    Console.ReadLine();
                                                }
                                                break;
                                            case 3:
                                                break;
                                            default:
                                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                                Console.WriteLine("\n.. < Ingrese una opción valida >");
                                                break;
                                        }
                                    }
                                    catch 
                                    { 
                                        Console.ForegroundColor = ConsoleColor.DarkRed;
                                        Console.WriteLine("\n.. < Ingrese un dato valido >");
                                    }

                                } while (opc != 3);

                                opc = 0;
                                break;

                            case 7:
                                do
                                {
                                    try
                                    {
                                        Console.Clear();
                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                        Console.WriteLine("          Seleccione que reporte desea visualizar           ");
                                        Console.WriteLine("===============================================================");
                                        Console.ForegroundColor = ConsoleColor.Yellow;
                                        Console.WriteLine("\n >  1. Cantidad de tickets que ha creado cada usuario. ");
                                        Console.WriteLine("\n >  2. Cantidad de tickets que se hacreado de cada tipo. ");
                                        Console.WriteLine("\n >  3. Volver.");
                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                        Console.WriteLine("\n===============================================================");
                                        Console.ForegroundColor = ConsoleColor.Yellow;
                                        Console.Write("\n >  Ingrese una opción: ");
                                        opc = int.Parse(Console.ReadLine());
                                        switch (opc)
                                        {
                                            case 1:
                                                reportes.GeneraReporte1(Ltick, Lu, colitaPrio);
                                                break;
                                            case 2:
                                                reportes.GeneraReporte2(Ltick, colitaPrio);
                                                break;
                                            case 3:
                                                break;
                                            default:
                                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                                Console.WriteLine("\n.. < Ingrese una opción valida >");
                                                break;
                                        }
                                    }
                                    catch
                                    {
                                        Console.ForegroundColor = ConsoleColor.DarkRed;
                                        Console.WriteLine("\n.. < Ingrese un dato valido >");
                                    }
                                } while (opc != 3);
                                opc = 0;
                                break;
                            case 8: //SALIDA
                                break;

                            default:
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.WriteLine("\n.. < Ingrese un dato valido >");
                                Console.ReadLine();
                                break;
                        }
                    }
                    catch
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("\n.. < Ingrese una opción valida >");
                        Console.ReadLine();
                    }

                } while (opcMandar != 8);
            }




        }
    }
}
