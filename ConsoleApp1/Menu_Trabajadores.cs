using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Menu_Trabajadores
    {
        public static Program program = new Program();
        public static Validaciones validacion = new Validaciones();
        public static string nombreCompleto;
        public void menuTrabajaor(int opc, Log_in inicioSesion, Lista_Alumnos Lu, Lista_Trabajadores LTra, Lista_Administrativos La, Lista_Tickets Ltick, Arbol_Compus ArbCom, ref int dniUser, ref int dniTrabajador, ref int dniAdmin) 
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
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("\n >  1. Gestionar tickets\n\n >  2. Gestionar alumnos\n\n >  3. Marcar hora de salida \n\n >  4. Gestionar computadoras \n\n > 5. Volver");
                        Console.ForegroundColor = ConsoleColor.Cyan;
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
                                        Console.ForegroundColor = ConsoleColor.Yellow;
                                        Console.WriteLine("\n >  1. Mostrar lista de alumnos\n\n >  2. Modificar datos del alumno \n\n >  3. Eliminar alumno \n\n >  4. Volver");
                                        Console.ForegroundColor = ConsoleColor.Cyan;
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

                            case 4:

                                do
                                {
                                    try
                                    {
                                        Console.Clear();
                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                        Console.WriteLine("\n\n==================== Gestionando Computadoras ====================");
                                        Console.ForegroundColor = ConsoleColor.Yellow;
                                        Console.WriteLine("\n > 1. Agregar nueva computadora a la lista");
                                        Console.WriteLine("\n > 2. Buscar computadora por código");
                                        Console.WriteLine("\n > 3. Modificar información de una computadora excepto su código");
                                        Console.WriteLine("\n > 4. Mostrar computadoras de un mismo salon.");
                                        Console.WriteLine("\n > 5. Mostrar computadoras de la misma marca.");
                                        Console.WriteLine("\n > 6. Eliminar una computadora de la lista");
                                        Console.WriteLine("\n > 7. Visualizar lista de computadoras");
                                        Console.WriteLine("\n > 8. Volver");
                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                        Console.WriteLine("\n====================================================================");
                                        Console.ForegroundColor = ConsoleColor.Yellow;
                                        Console.Write(" > Elija una opción: ");
                                        opc = int.Parse(Console.ReadLine());

                                        switch (opc)
                                        {
                                            case 1:
                                                
                                                bool flag;
                                                string codigoC = " ", marca = " ", sistemaO = " ", ram = " ", almacenamiento = " ", tarjetaM = " ", salon = " ", piso = " ", edificio = " ";
                                                do
                                                {

                                                    Console.Clear();
                                                    Console.WriteLine("                  Registrando computadoras ");
                                                    Console.WriteLine("---------------------------------------------------------");
                                                    Console.WriteLine(" Si desea salir y no registrar nada, \ningrese el numero 2 en cualquier parte del código  ");
                                                    Console.WriteLine("---------------------------------------------------------");
                                                    
                                                    Console.Write(" Código de la computadora        : ");
                                                    codigoC = Console.ReadLine();
                                                    flag = validacion.ValidacionDeCadenaVaciaEIngresoNum2(codigoC);
                                                    if (codigoC == "2")
                                                    {
                                                        flag = false;
                                                        break;
                                                    }
                                                    else if (flag == false)
                                                    {
                                                        Console.WriteLine(" El código de la computadora no puede quedar en blanco.");
                                                        Console.ReadLine();
                                                    }

                                                } while (flag == false);

                                                if (flag == true)
                                                {
                                                    do
                                                    {
                                                        Console.Write(" Marca de la computadora         : ");
                                                        marca = Console.ReadLine();

                                                        flag = validacion.ValidacionDeCadenaVaciaEIngresoNum2(marca);

                                                        if (marca == "2")
                                                        {
                                                            flag = false;
                                                            break;
                                                        }
                                                        else if (flag == false)
                                                        {
                                                            Console.WriteLine(" La marca de la computadora no puede quedar en blanco.");
                                                            Console.ReadLine();
                                                        }
                                                    } while (flag == false);
                                                }
                                                if (flag == true)
                                                {
                                                    do
                                                    {
                                                        Console.Write(" Sistema Operativo               : ");
                                                        sistemaO = Console.ReadLine();

                                                        flag = validacion.ValidacionDeCadenaVaciaEIngresoNum2(sistemaO);

                                                        if (sistemaO == "2")
                                                        {
                                                            flag = false;
                                                            break;
                                                        }
                                                        else if (flag == false)
                                                        {
                                                            Console.WriteLine(" El Sistema Operativo de la computadora no puede quedar en blanco.");
                                                            Console.ReadLine();
                                                        }

                                                    } while(flag == false);
                                                }
                                                if (flag == true)
                                                {
                                                    do
                                                    {

                                                        Console.Write(" RAM (poner dos decimales .00)   : ");
                                                        ram = Console.ReadLine();
                                                        flag = validacion.ValidacionDeCadenaVaciaEIngresoNum2(ram);
                                                        if(ram == "2")
                                                        {
                                                            flag = false;
                                                            break ; 
                                                        }
                                                        else if (flag == true)
                                                        {
                                                            flag = validacion.ValidacionIngresoSoloNumDouble(ram);
                                                          
                                                            if (flag == false)
                                                            {
                                                                Console.WriteLine("La ram no puede poseer caracteres no númericos");
                                                                Console.ReadLine();
                                                            }
                                                        }
                                                        else if (flag == false)
                                                        {
                                                            Console.WriteLine("La ram no puede quedar vacia");
                                                            Console.ReadLine();
                                                        }

                                                    } while (flag != true);
                                                }

                                                if(flag == true)
                                                {
                                                    do { 
                                                        Console.Write(" Almacenamiento de la computadora: ");
                                                        almacenamiento = Console.ReadLine();
                                                        flag = validacion.ValidacionDeCadenaVaciaEIngresoNum2(almacenamiento);
                                                        if (almacenamiento == "2")
                                                        {
                                                            flag = false;
                                                            break;
                                                        }
                                                        else if (flag == true)
                                                        {
                                                            flag = validacion.ValidacionIngresoSoloNumDouble(almacenamiento);

                                                            if (flag == false)
                                                            {
                                                                Console.WriteLine("La ram no puede poseer caracteres no númericos");
                                                                Console.ReadLine();
                                                            }
                                                        }
                                                        else if (flag == false)
                                                        {
                                                            Console.WriteLine("La ram no puede quedar vacia");
                                                            Console.ReadLine();
                                                        }

                                                    } while (flag != true) ;
                                                }
                                                if (flag == true)
                                                {
                                                    do { 
                                                        Console.Write(" Tarjeta madre: ");
                                                        tarjetaM = Console.ReadLine();

                                                        flag = validacion.ValidacionDeCadenaVaciaEIngresoNum2(tarjetaM);
                                                        if (tarjetaM == "2")
                                                        {
                                                            flag = false;
                                                            break;
                                                        }
                                                        else if (flag == false)
                                                        {
                                                            Console.WriteLine(" El código de la computadora no puede quedar en blanco.");
                                                            Console.ReadLine();
                                                        }

                                                        } while (flag == false) ;
                                                }
                                                
                                                if (flag == true)
                                                {
                                                    Console.WriteLine("            Ubicación de uso de la computadora ");
                                                    Console.WriteLine("===========================================================");
                                                    Console.WriteLine(" ");
                                                }
                                                
                                                if(flag == true)
                                                {
                                                    do
                                                    {
                                                        Console.Write("Salón                            : ");
                                                         salon = Console.ReadLine();

                                                        flag = validacion.ValidacionDeCadenaVaciaEIngresoNum2(salon);
                                                        if (salon == "2")
                                                        {
                                                            flag = false;
                                                            break;
                                                        }
                                                        else if (flag == false)
                                                        {
                                                            Console.WriteLine(" El código de la computadora no puede quedar en blanco.");
                                                            Console.ReadLine();
                                                        }

                                                    } while (flag == false);

                                                } while (flag == false);

                                                if (flag == true)
                                                {
                                                    do
                                                    {
                                                        Console.Write("Piso                             : ");
                                                        piso = Console.ReadLine();

                                                        flag = validacion.ValidacionDeCadenaVaciaEIngresoNum2(piso);

                                                        if (piso == "2")
                                                        {
                                                            flag = false;
                                                            break;
                                                        }
                                                        else if (flag == true)
                                                        {
                                                            flag = validacion.ValidacionIngresoSoloNum(piso);

                                                            if (flag == false)
                                                            {
                                                                Console.WriteLine("El piso no puede poseer caracteres no númericos");
                                                                Console.ReadLine();
                                                            }
                                                        }
                                                        else if (flag == false)
                                                        {
                                                            Console.WriteLine("El piso no puede quedar vacia");
                                                            Console.ReadLine();
                                                        }

                                                    } while (flag == false);
                                                }
                                                if (flag == true)
                                                {
                                                    do
                                                    {
                                                        Console.Write("Edificio                         : ");
                                                        edificio = Console.ReadLine();
                                                        flag = validacion.ValidacionDeCadenaVaciaEIngresoNum2(edificio);
                                                        
                                                        if(edificio == "2")
                                                        {
                                                            flag = false;
                                                            break;
                                                        }
                                                        else if(flag == false)
                                                        {
                                                            Console.WriteLine(" Edificio no puede quedar en blanco.");
                                                            Console.ReadLine();
                                                        }

                                                    } while (flag == false);
                                                }
                                                if (flag == true)
                                                {
                                                    ArbCom.AgregarCompu(codigoC, double.Parse(ram), double.Parse(almacenamiento), marca, sistemaO, salon, int.Parse(piso), edificio, tarjetaM);
                                                }   
                                                opc = 0;
                                                break;
                                            
                                            case 2:
                                                Console.Clear();
                                                Console.Write("Ingrese el código de la computadora a buscar: ");
                                                string codigoBus = Console.ReadLine();
                                                ArbCom.buscarPorCompuPorCodigo(codigoBus);
                                                Console.ReadLine();

                                                opc = 0;
                                                break;

                                            case 3:

                                                Console.WriteLine(" Indique la computadora de la cual quiere modificar información: ");

                                                opc = 0;
                                                break;
                                            case 4:
                                                Console.Clear();
                                                Console.Write(" Ingrese el salon: ");
                                                string codigoBusSal = Console.ReadLine();
                                                ArbCom.MostrarArbolitoPorSalon(ArbCom.arbolito, codigoBusSal);
                                                Console.ReadLine();


                                                opc = 0;
                                                break;

                                            case 5:

                                                Console.Clear();

                                                Console.Write("Ingrese la marca que desea buscar: ");
                                                string marcaBus = Console.ReadLine();
                                                ArbCom.MostrarArbolitoPorMarca(ArbCom.arbolito, marcaBus);

                                                Console.ReadLine();

                                                opc = 0;
                                                break;

                                            case 6: 
                                                
                                                
                                                opc = 0;
                                                break;

                                            case 7:

                                                Console.Clear();
                                                ArbCom.MostrarArbolitoEnOrden(ArbCom.arbolito);
                                                Console.ReadLine();
                                                opc = 0;
                                                break;

                                            case 8: 
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

                                }while(opc != 5);

                                break;

                            case 5://SALIDA DEL PROGRAMA
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
         }
    }
}
