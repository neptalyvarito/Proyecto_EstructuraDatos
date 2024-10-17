using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Menu_Trabajadores
    {
        public static Program program = new Program();
        public static Validaciones validacion = new Validaciones();
        public static string nombreCompleto;
        public void menuTrabajaor(int opc, Log_in inicioSesion, Lista_Usuarios Lu, Lista_Trabajadores LTra, Lista_Administrativos La, Lista_Tickets Ltick, ref int dniUser, ref int dniTrabajador, ref int dniAdmin) 
        {
            bool verificacion = false;
            do
            {
                try
                {

                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("\n\n              Está iniciando sesión como trabajador");
                    Console.WriteLine("===================================================================");
                    Console.WriteLine("  Llene los siguientes campos o ingrese el número 2 para volver");
                    Console.WriteLine("===================================================================");

                    verificacion = inicioSesion.InicioSesión(opc, Lu, LTra, La, ref dniUser, ref dniTrabajador, ref dniAdmin);

                    //etornar = int.Parse(Console.ReadLine());
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
                        Console.WriteLine("\n... Número de DNI o contraseña incorrectos.");
                        Console.ReadLine();
                    }
                }
                catch
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("\n  Error... Dni debe contener solo caracteres númericos");
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
                        nombreCompleto = LTra.NombreCompletoTrabajador(dniTrabajador);
                        
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine(" Bienvenido señor " + nombreCompleto);
                        Console.WriteLine("\n==============================================");
                        Console.WriteLine("\n >  1. Gestionar tickets\n\n >  2. Gestionar alumnos\n\n >  3. Marcar hora de salida \n\n >  4. Volver");
                        Console.WriteLine("\n==============================================");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write(" >  Elija una opción: ");
                        opc = int.Parse(Console.ReadLine());
                        switch (opc)
                        {
                            case 1:
                                program.GestionTickets();
                                opc = 0;
                                break;


                            case 2:
                                do
                                {
                                    try
                                    {
                                        Console.Clear();
                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                        Console.WriteLine("\n\n======== Gestionando Alumnos ========");
                                        Console.WriteLine("\n >  1. Mostrar lista de alumnos\n\n >  2. Modificar datos del alumno \n\n >  3. Eliminar alumno \n\n >  4. Volver");
                                        Console.WriteLine("\n=====================================");
                                        Console.ForegroundColor = ConsoleColor.Yellow;
                                        Console.Write(" >  Elija una opción: ");
                                        opc = int.Parse(Console.ReadLine());
                                        switch (opc)
                                        {
                                            case 1:

                                                Console.Clear();
                                                Lu.MostrarListaUsuarios();
                                                Console.ReadLine();
                                                opc = 0;
                                                break;

                                            case 2:
                                                do
                                                {

                                                    Console.Clear();
                                                    Lu.MostrarListaUsuarios();
                                                    int codigo1;
                                                    string aux;
                                                    Console.ForegroundColor = ConsoleColor.Cyan;
                                                    Console.WriteLine("========================================================================================");
                                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                                    Console.Write(" >  Ingrese el código del alumno del cual desea modificar datos: ");
                                                    aux = Console.ReadLine();

                                                    verificacion = validacion.ValidacionIngresoSoloNum(aux);

                                                    if (aux == "2")
                                                    {
                                                        break;
                                                    }
                                                    else if (verificacion == true)
                                                    {
                                                        codigo1 = int.Parse(aux);
                                                        verificacion = Lu.SaberSiExisteUsuarioConCodigo(codigo1);
                                                        if (verificacion == true)
                                                        {
                                                            program.ModificacionUsuariosTrabajsYAdmins(codigo1, 1);
                                                        }
                                                        else
                                                        {
                                                            Console.ForegroundColor = ConsoleColor.DarkRed;
                                                            Console.WriteLine("... Alumno no econtrado. Ingrese el código correcto o el ingrese el número 2 para volver");
                                                            Console.ReadLine();
                                                        }
                                                    }
                                                    else if (verificacion == false)
                                                    {
                                                        Console.ForegroundColor = ConsoleColor.DarkRed;
                                                        Console.WriteLine("... El código debe contener solo caracteres númericos");
                                                        Console.ReadLine();
                                                    }
                                                } while (verificacion != true);
                                                opc = 0;
                                                break;

                                            case 3:
                                                Console.Clear();
                                                Lu.EliminarUsuario();
                                                Console.ReadLine();
                                                opc = 0;
                                                break;

                                            case 4:
                                                break;

                                            default:

                                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                                Console.WriteLine("\n... Ingrese una opción valida");
                                                Console.ReadLine();
                                                opc = 0;
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

                            case 3:
                                Console.Clear();
                                int codigo = LTra.ObtenerCodigoConDNI(dniTrabajador);
                                LTra.MarcarSalida(codigo);
                                break;

                            case 4://SALIDA DEL PROGRAMA
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
                        Console.WriteLine("\n.. < Ingrese una opción valida >");
                        Console.ReadLine();
                    }
                } while (opc != 4);
            }
         }
    }
}
