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
        public void menuAdmin(int opc, Log_in inicioSesion, Lista_Usuarios Lu, Lista_Trabajadores LTra, Lista_Administrativos La, Lista_Tickets Ltick, Registros registro, ref int dniUser, ref int dniTrabajador, ref int dniAdmin)

        {
            bool verificacion = false;
            int opcMandar = 0;
            do
            {
                try
                {

                    Console.Clear();

                    Console.WriteLine(" Está iniciando sesión como administrador");
                    Console.WriteLine("---------------------------------------------");
                    Console.WriteLine(" Por favor, llene los siguientes campos \n Si desea volver, por favor, ingrese el número 2:");
                    Console.WriteLine("---------------------------------------------");

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
                        Console.WriteLine("....Número de DNI o contraseña incorrectos.");
                        Console.ReadLine();
                    }
                }
                catch 
                {
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
                        Console.WriteLine(" Bienvenido señor " + nombreCompleto);
                        Console.WriteLine("-----------------------------------------------");
                        Console.WriteLine(" 1. Gestionar alumnos");
                        Console.WriteLine(" 2. Gestionar trabajadores");
                        Console.WriteLine(" 3. Gestionar administrativos");
                        Console.WriteLine(" 4. Gestionar tickets");
                        Console.WriteLine(" 5. Generar Reporte");
                        Console.WriteLine(" 6. Volver");
                        Console.WriteLine("-----------------------------------------------");
                        Console.Write(" Ingrese opción: ");
                        opcMandar = int.Parse(Console.ReadLine());
                        switch (opcMandar)
                        {
                            case 1:
                                do
                                {
                                    try
                                    {
                                        Console.Clear();
                                        Console.WriteLine("       Gestionando Alumnos");
                                        Console.WriteLine("-------------------------------------------");
                                        Console.WriteLine(" 1. Crear alumnos\n 2. Ver lista de alumnos\n 3. Modificar datos del alumno \n 4. Eliminar alumno\n 5. Volver");
                                        Console.WriteLine("-------------------------------------------");
                                        Console.Write("Ingrese opción: ");
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
                                                    Console.WriteLine("-------------------------------------------------------------------\n");
                                                    Console.Write("Ingrese el número 2 para volver ");
                                                    Console.Write("Ingrese el código del alumno del cual desea modificar datos: ");
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
                                                            Console.WriteLine("....Alumno no econtrado. Ingrese el código correcto o el ingrese el número 2 para volver");
                                                            Console.ReadLine();
                                                        }
                                                    }
                                                    else if(verificacion == false)
                                                    {
                                                        Console.WriteLine("....El código debe contener solo caracteres númericos");
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
                                                Console.WriteLine("\n......Ingrese una opción valida");
                                                Console.ReadLine();
                                                break;
                                        }
                                    }
                                    catch
                                    {

                                        Console.Write("\n........Ingrese un dato valido");
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
                                        Console.WriteLine("      Gestionando Trabajadores");
                                        Console.WriteLine("-------------------------------------------");
                                        Console.WriteLine(" 1. Crear trabajador\n 2. Ver lista de trabajadorres \n 3. Modificar datos del trabajador \n 4. Eliminar trabajador\n 5. Volver");
                                        Console.WriteLine("-------------------------------------------");
                                        Console.Write("Ingrese opción: ");
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
                                                    Console.WriteLine("-------------------------------------------------------------------\n");
                                                    Console.Write("Ingrese el número 2 para volver ");
                                                    Console.Write("Ingrese el código del trabajador del cual desea modificar datos: ");
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
                                                            Console.WriteLine("....Trabajador no econtrado. Ingrese el código correcto o el ingrese el número 2 para volver");
                                                            Console.ReadLine();
                                                        }
                                                    }
                                                    else if (verificacion == false)
                                                    {
                                                        Console.WriteLine("....El código debe contener solo caracteres númericos");
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

                                                Console.WriteLine("\n........Ingrese una opción valida");
                                                Console.ReadLine();

                                                break;
                                        }
                                    }
                                    catch
                                    {
                                        Console.Write("\n........Ingrese un dato valido");
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
                                        Console.WriteLine("       Gestionando Administrativos");
                                        Console.WriteLine("-------------------------------------------");
                                        Console.WriteLine(" 1. Crear administrativo\n 2. Ver lista de administrativos \n 3. Modificar datos del administrativo \n 4. Elimar administrativo \n 5. Volver");
                                        Console.WriteLine("-------------------------------------------");
                                        Console.Write("Ingrese opción: ");
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
                                                    Console.WriteLine("-------------------------------------------------------------------\n");
                                                    Console.Write("Ingrese el número 2 para volver ");
                                                    Console.Write("Ingrese el código del administrador del cual desea modificar datos: ");
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
                                                            Console.WriteLine("....Administrador no econtrado. Ingrese el código correcto o el ingrese el número 2 para volver");
                                                            Console.ReadLine();
                                                        }
                                                    }
                                                    else if (verificacion == false)
                                                    {
                                                        Console.WriteLine("....El código debe contener solo caracteres númericos");
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
                                                Console.Write("\n........Ingrese un dato valido");
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
                                        Console.WriteLine(" Seleccione que reporte desea visualizar           ");
                                        Console.WriteLine("-----------------------------------------------------");
                                        Console.WriteLine(" 1. Cantidad de tickets que ha creado cada usuario. ");
                                        Console.WriteLine(" 2. Cantidad de tickets que se hacreado de cada tipo. ");
                                        Console.WriteLine(" 3. Volver.");
                                        Console.WriteLine("-----------------------------------------------------");
                                        Console.Write(" Ingrese una opción: ");
                                        opc = int.Parse(Console.ReadLine());
                                        switch (opc)
                                        {
                                            case 1:
                                                reportes.GeneraReporte1(Ltick, Lu);
                                                break;
                                            case 2:
                                                reportes.GeneraReporte2(Ltick);
                                                break;
                                            case 3:
                                                break;
                                            default:
                                                Console.WriteLine("....Ingrese una opción valida");
                                                break;

                                        }
                                    }
                                    catch
                                    {
                                        Console.WriteLine("....Ingrese un dato valido");
                                    }
                                } while (opc!=3);

                                break;
                            case 6: //SALIDA
                                break;

                            default:

                                Console.Write("\n........Ingrese un dato valido");
                                Console.ReadLine();
                                break;
                        }
                    }
                    catch
                    {

                        Console.Write("\n\n........Ingrese una opción valida ");
                        Console.ReadLine();
                    }

                } while (opcMandar != 6);
            }




        }
    }
}
