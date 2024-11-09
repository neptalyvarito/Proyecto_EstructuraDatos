using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        
        public static Lista_Tickets Ltick = new Lista_Tickets();
        public static Lista_Usuarios Lu = new Lista_Usuarios();
        public static Lista_Administrativos La = new Lista_Administrativos();
        public static Lista_Trabajadores LTra = new Lista_Trabajadores();

        public static Cola_Solicitudes ColaSol = new Cola_Solicitudes();
        public static Solicitudes q = new Solicitudes();
        public static Pila_Sugerencia PilaSug = new Pila_Sugerencia();
        public static AsignacionTrabajos AsigTra = new AsignacionTrabajos();

        public static Validaciones validacion = new Validaciones();
        public static Log_in inicioSesion = new Log_in();
        public static Generacion_Aleatorio GAletorio = new Generacion_Aleatorio();

        public static Menu_Clientes menuUsario = new Menu_Clientes();
        public static Menu_Trabajadores menuTrabajador = new Menu_Trabajadores();
        public static Menu_Admin menuAdministrador = new Menu_Admin();

        public static Registros registro = new Registros();
        

        public static int dni;
        public static int codigoBusquedaTrabajador, codigoBusquedaAdmin, dniUser = 0, dniTrabajador = 0, dniAdmin =0;

        public static void UserPorDefecto()
        {
            Lu.RegistrarUsuarios("Renato", "Crispin Alvaro", 12345678, 901789730, "hola");
        }
        public static void AdminPorDefecto()
        {
            La.AgregarAdmin("Alvaro Neptaly", "Mayo de la Vega", 901789730, 75433366, "alvaroneptaly");
            La.AgregarAdmin("Neiser Omar", "Chavez Chuqui", 922240578, 70826687, "neiseromar");
            La.AgregarAdmin("Sandy Andrea", "Solis Molina", 953261550, 76802211, "sandyandrea");
            La.AgregarAdmin("Elias Alejandro", "Diaz Cahuas", 927073589, 74877780, "eliasalejandro");
        }
        
        static void Main(string[] args)
        {
            UserPorDefecto();
            AdminPorDefecto();
            GAletorio.GenerarUsuariosAdmisYTrabajadoresAleatorios(Lu, La, LTra);
            GAletorio.GenerarTickets(Ltick, Lu);


            int opc = 0;
           
            do
            {
                Console.Clear(); 
                try
                {
                    Console.Clear();
                    Console.BackgroundColor = ConsoleColor.Black; 
                    Console.ForegroundColor = ConsoleColor.Red; 
                    Console.WriteLine("\n\t\t\t\t\t==============================================================================================================================================================================================");
                    Console.ForegroundColor = ConsoleColor.Yellow; 
                    Console.WriteLine("\t\n\t\t\t\t\t\t\t\t\t\t\t  _   ___   _  __   _                 _    _     _   _   _  _  _   _          ");
                    Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t (_    |   (_    |   |_  |\\/|   /\\     | \\  |_    /_  |  (_    |    |   / \\  |\\ |   ");
                    Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t __)  _|_  __)   |   |  |  |  /--\\    |/  |    \\|  |  _)   |   _|  \\_/  | \\|   ");
                    Console.WriteLine("\t\t\t\t                                                                                  ");
                    Console.WriteLine("\t\t\t\t\t$$$$$$$\\  $$$$$$$$\\        $$$$$$\\   $$$$$$\\  $$$$$$$\\   $$$$$$\\  $$$$$$$\\  $$$$$$$$\\ $$$$$$$$\\       $$$$$$$$\\     $$$$$$\\           $$$$$$$\\  $$$$$$$$\\       $$\\   $$\\ $$$$$$$\\  $$\\   $$\\ ");
                    Console.WriteLine("\t\t\t\t\t$$  _$$\\ $$  __|      $$  _$$\\ $$  _$$\\ $$  _$$\\ $$  _$$\\ $$  _$$\\ \\$$  _|$$  __|      \\$$  _|    \\$$  _|          $$  _$$\\ $$  __|      $$ |  $$ |$$  _$$\\ $$$\\  $$ |");
                    Console.WriteLine("\t\t\t\t\t$$ |  $$ |$$ |            $$ /  \\__|$$ /  $$ |$$ |  $$ |$$ /  $$ |$$ |  $$ |   $$ |   $$ |               $$ |         $$ |            $$ |  $$ |$$ |            $$ |  $$ |$$ |  $$ |$$$$\\ $$ |");
                    Console.WriteLine("\t\t\t\t\t$$ |  $$ |$$$$$\\          \\$$$$$$\\  $$ |  $$ |$$$$$$$  |$$ |  $$ |$$$$$$$  |   $$ |   $$$$$\\             $$ |         $$ |            $$ |  $$ |$$$$$\\          $$ |  $$ |$$$$$$$  |$$ $$\\$$ |");
                    Console.WriteLine("\t\t\t\t\t$$ |  $$ |$$  _|          \\_$$\\ $$ |  $$ |$$  _/ $$ |  $$ |$$  _$$<    $$ |   $$  _|            $$ |         $$ |            $$ |  $$ |$$  _|         $$ |  $$ |$$  __/ $$ \\$$$$ |");
                    Console.WriteLine("\t\t\t\t\t$$ |  $$ |$$ |            $$\\   $$ |$$ |  $$ |$$ |      $$ |  $$ |$$ |  $$ |   $$ |   $$ |               $$ |         $$ |            $$ |  $$ |$$ |            $$ |  $$ |$$ |      $$ |\\$$$ |");
                    Console.WriteLine("\t\t\t\t\t$$$$$$$  |$$$$$$$$\\       \\$$$$$$  | $$$$$$  |$$ |       $$$$$$  |$$ |  $$ |   $$ |   $$$$$$$$\\          $$ |   $$\\ $$$$$$\\ $$\\       $$$$$$$  |$$$$$$$$\\       \\$$$$$$  |$$ |      $$ | \\$$ |");
                    Console.WriteLine("\t\t\t\t\t\\__/ \\__|       \\__/  \\__/ \\|       \\__/ \\|  \\|   \\|   \\__|         \\|   \\|\\__|\\|      \\__/ \\___|       \\__/ \\|      \\|  \\_|");

                    Console.ForegroundColor = ConsoleColor.Red; //Texto azul en negrita
                    Console.WriteLine("\n\t\t\t\t\t==============================================================================================================================================================================================");
                    Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t-------------------");
                    Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t1. Iniciar sesión                                                 ");
                    Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t2. Salir");
                    Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t-------------------");
                    Console.Write("\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\tIngrese opción: ");
                    opc = int.Parse(Console.ReadLine());
                    Console.Clear();

                    Console.WriteLine("==========================");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("  \n >  1. Iniciar sesión\n\n >  2. Salir");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("\n==========================");
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

                                    Console.Clear();
                                    Console.ForegroundColor = ConsoleColor.Cyan;                                  
                                    Console.WriteLine("\n======== Iniciar sesión como ========");
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.WriteLine("\n >  1. Alumno\n\n >  2. Trabajador\n\n >  3. Administrativo\n\n >  4. Volver");
                                    Console.ForegroundColor = ConsoleColor.Cyan;
                                    Console.WriteLine("\n=====================================");
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.Write("\n >  Elija una opción: ");
                                    opc = int.Parse(Console.ReadLine());

                                    switch (opc)
                                    {
                                        case 1:// Desarrollo de la parte usuario


                                            menuUsario.Menu_Usuarios(opc, inicioSesion, Lu, LTra, La, Ltick, ColaSol, ref q, ref dniUser, ref dniTrabajador, ref dniAdmin, PilaSug);
                                          
                                            opc = 0;
                                            break;

                                        case 2:// Desarrollo parte trabajadores

                                            menuTrabajador.menuTrabajaor(opc, inicioSesion, Lu, LTra, La, Ltick, ref dniUser, ref dniTrabajador, ref dniAdmin);
                                            opc = 0;
                                            break; 

                                        case 3: // Desarrollo de la parte aministrativos

                                            menuAdministrador.menuAdmin(opc, inicioSesion, Lu, LTra, La, Ltick, ColaSol, ref q, PilaSug, registro, ref dniUser, ref dniTrabajador, ref dniAdmin);
                                            
                                            opc = 0;
                                            break;// Desarrollo parte Admins

                                        case 4:// Salida
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
                                    Console.WriteLine("\n.. < Ingrese una opción valida >");
                                    Console.ReadLine();
                                }

                            } while (opc != 4);

                            opc = 0;
                            break;

                        case 2: // Sale del programa
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
                    Console.WriteLine("\n.. < Ingrese una opción valida >");
                    Console.ReadLine();
                }

            } while (opc != 2);
        
        }
        public void EnMedio()
        {
            Console.Write("\t\t\t\t\t\t\t\t\t\t");
        }
        public void ModificacionUsuariosTrabajsYAdmins(int codigo, int tipoModificar)
        {
            int opc = 0;
            string tipoObjeto = " ", cabecera = " ";

            if (tipoModificar == 1)
            {
                tipoObjeto = "alumno";
                cabecera = "Alumno";
            }
            else if (tipoModificar == 2)
            {
                tipoObjeto = "trabajador";
                cabecera = "Trabajadores";
            }
            else if (tipoModificar == 3)
            {
                tipoObjeto = "administrador";
                cabecera = "Administradores";
            }
            do
            {
                try
                {
                   
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("============ Modificando " + cabecera+ " ==========");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\n >  1. Modificar nombres\n\n >  2. Modificar apellidos\n\n >  3. Modificar número celular\n\n >  4. Modificar contraseña \n\n >  5. Volver.");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("\n=================================================");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("\n >  Elija una opción: ");
                    opc = int.Parse(Console.ReadLine());

                    string modificacion1 = " ";
                    int modificacion2 = 0;
                    bool verificacion;

                    switch (opc)
                    {
                        case 1:

                            do {

                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.WriteLine("\n\n\t\t        Modificando "+ cabecera);
                                Console.WriteLine("=====================================================================");
                                Console.WriteLine("|         Modificando nombres. Ingrese el número 2 para volver      |");
                                Console.WriteLine("=====================================================================");
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine("\n >  Ingrese los nuevos nombres del "+ tipoObjeto+" : ");
                                Console.Write("\n    ");
                                modificacion1 = Console.ReadLine();

                                verificacion = validacion.ValidacionIngresoNum2(modificacion1);
                             
                                if(modificacion1 == "2")
                                {
                                    break;
                                }
                                else if (verificacion == true)
                                {

                                    if(tipoModificar == 1) Lu.ModificarDatosUsers(modificacion1, modificacion2, codigo, opc);
                                    else if(tipoModificar == 2) LTra.ModificarDatosTrabajadores(modificacion1, modificacion2, codigo, opc);
                                    else if (tipoModificar == 3) La.ModificarDatosAdmins(modificacion1, modificacion2, codigo, opc);

                                    Console.Write("\n  ->  ¡Nombres modificados con exito!");
                                    Console.ReadLine();
                                }
                                else if(verificacion == false)
                                {
                                    Console.ForegroundColor = ConsoleColor.DarkRed;
                                    Console.Write("\n... Los nombres no pueden quedar vacios y no deben tener caracteres númericos.\n... O ingrese el número 2 para salir.");
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
                                Console.WriteLine("\n\n\t\t        Modificando " + cabecera);
                                Console.WriteLine("=======================================================================");
                                Console.WriteLine("|         Modificando apellidos. Ingrese el número 2 para volver      |");
                                Console.WriteLine("=======================================================================");
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Write("\n >  Ingrese los nuevos apellidos del " + tipoObjeto + ": ");
                                Console.Write("\n    ");
                                modificacion1 = Console.ReadLine();

                                verificacion = validacion.ValidacionIngresoNum2(modificacion1);
                                if (modificacion1 == "2")
                                {
                                    break;
                                }
                                else if (verificacion == true)
                                {
                                    if (tipoModificar == 1) Lu.ModificarDatosUsers(modificacion1, modificacion2, codigo, opc);
                                    else if (tipoModificar == 2) LTra.ModificarDatosTrabajadores(modificacion1, modificacion2, codigo, opc);
                                    else if (tipoModificar == 3) La.ModificarDatosAdmins(modificacion1, modificacion2, codigo, opc);
                                    Console.Write("\n  ->  Apellidos modificados con exito!");
                                    Console.ReadLine();
                                }
                                else if (verificacion == false)
                                {
                                    Console.ForegroundColor = ConsoleColor.DarkRed;
                                    Console.Write("\n... Los apellidos no pueden quedar vacios y no deben tener caracteres númericos\n... O ingrese el número 2 para salir.");
                                    Console.ReadLine();
                                }
                            } while (verificacion == false);
                            opc = 0;
                            break;

                        case 3:

                            do {
                                string aux;

                                Console.Clear();
                                Console.WriteLine("\n\n\t\t        Modificando " + cabecera);
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.WriteLine("================================================================================");
                                Console.WriteLine("|       Modificando número de celular. Ingrese el número 2 para volver         |");
                                Console.WriteLine("================================================================================");
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine("\n >  Ingrese el nuevo número de celular  del "+tipoObjeto+" : ");
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
                                        if (tipoModificar == 1) Lu.ModificarDatosUsers(modificacion1, modificacion2, codigo, opc);
                                        else if (tipoModificar == 2) LTra.ModificarDatosTrabajadores(modificacion1, modificacion2, codigo, opc);
                                        else if (tipoModificar == 3) La.ModificarDatosAdmins(modificacion1, modificacion2, codigo, opc);
                                        Console.WriteLine("  ->  ¡Número de celular modificado con exito!");
                                        Console.ReadLine();
                                    }
                                    else if (verificacion == false)
                                    {
                                        Console.ForegroundColor = ConsoleColor.DarkRed;
                                        Console.WriteLine("... La longitud del número de celular debe ser de 9 caracteres númericos\n... O ingrese el número 2 para volver");
                                        Console.ReadLine();
                                    }

                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.DarkRed;
                                    Console.WriteLine("... La variable debe poseer solo caracteres de tipo númericos\n... O ingrese el número 2 para volver");
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
                                Console.WriteLine("\n\n\t\t        Modificando " + cabecera);
                                Console.WriteLine("===================================================================================");
                                Console.WriteLine("|              Modificando contraseña. Ingrese el número 2 para volver            |");
                                Console.WriteLine("===================================================================================");
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Write(" >  Por favor ingrese la nueva contraseña "+tipoObjeto+" : ");
                                Console.Write("\n    ");
                                modificacion1 = Console.ReadLine();

                                verificacion = validacion.ValidacionIngresoNum2(modificacion1);
                                if (modificacion1 == "2")
                                {
                                    break;
                                }
                                else if (verificacion == true)
                                {
                                    if (tipoModificar == 1) Lu.ModificarDatosUsers(modificacion1, modificacion2, codigo, opc);
                                    else if (tipoModificar == 2) LTra.ModificarDatosTrabajadores(modificacion1, modificacion2, codigo, opc);
                                    else if (tipoModificar == 3) La.ModificarDatosAdmins(modificacion1, modificacion2, codigo, opc);

                                    Console.Write("\n  ->  Contraseña modificada con exito!");
                                    Console.ReadLine();
                                }
                                else if (verificacion == false)
                                {
                                    Console.ForegroundColor = ConsoleColor.DarkRed;
                                    Console.Write("... La contraseña no pueden quedar vacia. O ingrese el número 2 para salir.");
                                    Console.ReadLine();
                                }
                            } while (verificacion == false);

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
                    Console.WriteLine("\n.. < Ingrese una opción valida >");
                    Console.ReadLine();
                }
            } while (opc != 5);
        }
        public void GestionTickets()
        {
            int opc = 0;
            do
            {
                try
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("======= Gestionando tickets =======");
                    Console.WriteLine("\n >  1. Ver lista de tickets \n\n >  2. Responder ticket \n\n >  3. Ver tickets en espera \n\n >  4. Ver tickets resueltos \n\n >  5. Designar tickets \n\n >  6. Eliminar ticket\n\n >  7. Volver ");
                    Console.WriteLine("\n===================================");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("\n >  Elija una opción: ");
                    opc = int.Parse(Console.ReadLine());
                    switch (opc)
                    {
                        case 1:

                            Console.Clear();
                            Ltick.ImprimirTickets();
                            Console.ReadLine();

                            opc = 0;
                            break;

                        case 2:

                            Console.Clear();
                            Ltick.ResponderTicket();

                            opc = 0;
                            break;

                        case 3:
                            Console.Clear();
                            Ltick.MostrarTicketsEspera();
                            Console.ReadLine();
                            opc = 0;
                            break;

                        case 4:
                            Console.Clear();
                            Ltick.MostrarTicketsResueltos();
                            Console.ReadLine();
                            opc = 0;
                            break;

                        case 5:

                            string codigoTi, codigoTr;
                            bool flag;
                           
                            do
                            {
                                Console.Clear();
                                Ltick.MostrarTicketsEspera();
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.Write("\n\n=====================================================================");
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Write("\n >  Ingrese código del ticket que desea designar: ");
                                codigoTi = Console.ReadLine();

                                flag = validacion.ValidacionIngresoSoloNum(codigoTi);
                                if (codigoTi == "2")
                                {
                                    break;
                                }
                                else if (flag == true)
                                {
                                    flag = false;

                                    flag =  Ltick.SaberSiExisteTicket(int.Parse(codigoTi));

                                    if(flag == true)
                                    {
                                        do
                                        {
                                            Console.Clear();
                                            LTra.MostrarListaTrabajadores();
                                            Console.ForegroundColor = ConsoleColor.Cyan;
                                            Console.Write("\n\n==========================================================");
                                            Console.ForegroundColor = ConsoleColor.Yellow;
                                            Console.Write("\n >  Ingrese código del trabajador a designar:");
                                            codigoTr = Console.ReadLine();
                                            flag = validacion.ValidacionIngresoSoloNum(codigoTi);
                                            if (codigoTr == "2")
                                            {
                                                break;
                                            }
                                            else if (flag == true)
                                            {
                                                flag = false;
                                                flag = LTra.SaberSiExisteTrabajadorConCodigo(int.Parse(codigoTr));
                                                if (flag == true)
                                                {
                                                    AsigTra.AsignacionTicket(int.Parse(codigoTr), int.Parse(codigoTi), Ltick);
                                                 
                                                    Console.ForegroundColor = ConsoleColor.Cyan;
                                                    Console.WriteLine("\n=============================");
                                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                                    Console.WriteLine(" \nAsignación hecha: ");
                                                    Console.WriteLine(" \nTicket: " + codigoTi);
                                                    Console.WriteLine(" \nResponsable: " + LTra.ObtenerNombreTrabajadoresConCodigo(int.Parse(codigoTr)));
                                                    Console.ReadLine();
                                                }
                                            }
                                            if (flag == false)
                                            {
                                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                                Console.WriteLine("... Trabajador no encontrado\n... Ingrese el código correcto o ingrese el número 2 para volver");
                                                Console.ReadLine();
                                            }
                                        } while (flag != true);
                                    }

                                    if (flag == false)
                                    {
                                        Console.ForegroundColor = ConsoleColor.DarkRed;
                                        Console.WriteLine("... Ticket no encontrado\n... Ingrese el código correcto o ingrese el número 2 para volver");
                                        Console.ReadLine();
                                    }

                                }
                                else if (flag == false)
                                {
                                    Console.ForegroundColor = ConsoleColor.DarkRed;
                                    Console.WriteLine("... Ingrese solo un valor númerico\n");
                                    Console.ReadLine();
                                }
                            } while (flag != true);
                            opc = 0;
                            break;

                        case 6:
                            Console.Clear();
                            Ltick.EliminarTicket();
                            opc = 0;
                            break;

                        case 7:
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
                    Console.WriteLine("\n.. < Ingrese una opción valida >");
                    Console.ReadLine();
                }
            } while (opc != 6);
        }

    }
}

