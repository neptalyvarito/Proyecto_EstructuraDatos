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
                Console.BackgroundColor = ConsoleColor.White; 
                Console.ForegroundColor = ConsoleColor.DarkBlue; 
                Console.Clear(); 
                try
                {
                    Console.Clear();

                    Console.WriteLine(" Bienvenido al sistema TI");
                    Console.WriteLine("-------------------------");
                    Console.WriteLine(" 1. Iniciar sesión\n 2. Salir");
                    Console.WriteLine("-------------------------");
                    Console.Write(" Ingrese opción: ");
                    opc = int.Parse(Console.ReadLine());

                    switch (opc)
                    {
                        case 1:
                            do
                            {
                                try
                                {

                                    Console.Clear();

                                    Console.WriteLine(" Inciar sesión como: ");
                                    Console.WriteLine("--------------------");
                                    Console.WriteLine(" 1. Alumno\n 2. Trabajador\n 3. Administrativo\n 4. Volver");
                                    Console.WriteLine("--------------------");
                                    Console.Write(" Ingrese opción: ");
                                    opc = int.Parse(Console.ReadLine());

                                    switch (opc)
                                    {
                                        case 1:// Desarrollo de la parte usuario


                                            menuUsario.Menu_Usuarios(opc, inicioSesion, Lu, LTra, La, Ltick, ref dniUser, ref dniTrabajador, ref dniAdmin);
                                          
                                            opc = 0;
                                            break;

                                        case 2:// Desarrollo parte trabajadores

                                            menuTrabajador.menuTrabajaor(opc, inicioSesion, Lu, LTra, La, Ltick, ref dniUser, ref dniTrabajador, ref dniAdmin);
                                            opc = 0;
                                            break; 

                                        case 3: // Desarrollo de la parte aministrativos

                                            menuAdministrador.menuAdmin(opc, inicioSesion, Lu, LTra, La, Ltick, registro, ref dniUser, ref dniTrabajador, ref dniAdmin);
                                            
                                            opc = 0;
                                            break;// Desarrollo parte Admins

                                        case 4:// Salida
                                            break;

                                        default:

                                            Console.WriteLine("\n..... Ingrese una opción valida");
                                            Console.ReadLine();
                                            break;
                                    }
                                }
                                catch  
                                {

                                    Console.Write("\n\n........Ingrese una opción valida...");
                                    Console.ReadLine();
                                }

                            } while (opc != 4);

                            opc = 0;
                            break;

                        case 2: // Sale del programa
                            break;

                        default:
                            Console.WriteLine("\n........Ingrese una opción valida");
                            Console.ReadLine();
                            break;

                    }
                }
                catch
                {


                    Console.Write("\n\n........Ingrese una opción valida...");
                    Console.ReadLine();
                }

            } while (opc != 2);
        
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
                    Console.WriteLine("     Modificando " +cabecera);
                    Console.WriteLine("----------------------------------");
                    Console.WriteLine(" 1. Modificar nombres\n 2. Modificar apellidos \n 3. Modificar número celular\n 4. Modificar contraseña \n 5. Volver");
                    Console.WriteLine("----------------------------------");
                    Console.Write(" Ingrese opción: ");
                    opc = int.Parse(Console.ReadLine());

                    string modificacion1 = " ";
                    int modificacion2 = 0;
                    bool verificacion;

                    switch (opc)
                    {
                        case 1:

                            do {

                                Console.Clear();
                                Console.WriteLine("         Modificando "+ cabecera);
                                Console.WriteLine("--------------------------------------");
                                Console.WriteLine("|         Modificando nombres        |");
                                Console.WriteLine("|  Ingrese el número 2 para volver   |");
                                Console.WriteLine("--------------------------------------");
                               
                                Console.Write(" Por favor, ingrese los nuevos nombres del "+ tipoObjeto+": ");
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

                                    Console.Write("....Nombres modificados con exito!");
                                    Console.ReadLine();
                                }
                                else if(verificacion == false)
                                {
                                    Console.Write("....Los nombres no pueden quedar vacios y no deben tener caracteres númericos. O ingrese el número 2 para salir.");
                                    Console.ReadLine();
                                }

                            } while (verificacion != true);

                            opc = 0;
                            break;

                        case 2:
                            do
                            {
                                Console.WriteLine("          Modificando " + cabecera);
                                Console.WriteLine("----------------------------------------");
                                Console.WriteLine("|         Modificando apellidos        |");
                                Console.WriteLine("|   Ingrese el número 2 para volver    |");
                                Console.WriteLine("----------------------------------------");
                                Console.Write(" Por favor, ingrese los nuevos apellidos del " + tipoObjeto + ": ");
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
                                    Console.Write("....Apellidos modificados con exito!");
                                    Console.ReadLine();
                                }
                                else if (verificacion == false)
                                {
                                    Console.Write("....Los apellidos no pueden quedar vacios y no deben tener caracteres númericos. O ingrese el número 2 para salir.");
                                    Console.ReadLine();
                                }
                            } while (verificacion == false);
                            opc = 0;
                            break;

                        case 3:

                            do {
                                string aux;

                                Console.Clear();
                                Console.WriteLine("              Modificando "+ cabecera);
                                Console.WriteLine("------------------------------------------------");
                                Console.WriteLine("|       Modificando número de celular          |");
                                Console.WriteLine("|         Ingrese el número 2 para volver      |");
                                Console.WriteLine("------------------------------------------------");
                                Console.WriteLine("| Ingrese el nuevo número de celular  del "+tipoObjeto+": ");
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
                                        Console.WriteLine("\n....Número de celular modificado con exito!");
                                        Console.ReadLine();
                                    }
                                    else if (verificacion == false)
                                    {
                                        Console.WriteLine("......La longitud del número de celular debe ser de 9 caracteres númericos\n");
                                        Console.ReadLine();
                                    }

                                }
                                else
                                {
                                    Console.WriteLine("La variable debe poseer solo caracteres de tipo númericos");
                                    Console.ReadLine();
                                }
                            } while (verificacion != true);

                            opc = 0;
                            break;

                        case 4:
                            do
                            {
                                Console.WriteLine("                Modificando "+cabecera);
                                Console.WriteLine("--------------------------------------------------");
                                Console.WriteLine("|              Modificando contraseña            |");
                                Console.WriteLine("|         Ingrese el número 2 para volver        |");
                                Console.WriteLine("--------------------------------------------------");
                                Console.Write(" | Por favor ingrese la nueva contraseña "+tipoObjeto+": ");
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

                                    Console.Write("\n......Contraseña modificada con exito!");
                                    Console.ReadLine();
                                }
                                else if (verificacion == false)
                                {
                                    Console.Write("....La contraseña no pueden quedar vacia o ingrese el número 2 para salir.");
                                    Console.ReadLine();
                                }
                            } while (verificacion == false);

                            opc = 0;
                            break;

                        case 5:
                            break;

                        default:
                            Console.WriteLine("\n........Ingrese una opción valida");
                            Console.ReadLine();
                            break;
                    }
                }
                catch
                {

                    Console.Write("\n\n........Ingrese una opción valida");
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
                    Console.WriteLine(" Gestionando tickets");
                    Console.WriteLine("-------------------------------------");
                    Console.WriteLine(" 1. Ver lista de tickets \n 2. Responder ticket \n 3. Ver tickets en espera \n 4. Ver tickets resueltos \n 5. Eliminar ticket\n 6. Volver ");
                    Console.WriteLine("-------------------------------------");
                    Console.Write(" Ingrese opción: ");
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
                            Console.Clear();
                            Ltick.EliminarTicket();
                            opc = 0;
                            break;

                        case 6:
                            break;

                        default:
                            Console.WriteLine("\n....Ingrese una opción valida");
                            Console.ReadLine();
                            break;

                    }
                }
                catch
                {

                    Console.Write("\n\n........Ingrese una opción valida");
                    Console.ReadLine();
                }
            } while (opc != 6);
        }

    }
}

