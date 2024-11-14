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
        public void menuTrabajador(int opc, Log_in inicioSesion, Lista_Alumnos Lu, Lista_Trabajadores LTra, Lista_Administrativos La, Lista_Tickets Ltick, Lista_Profes Lp, Arbol_Compus ArbCom, ref int dniUser, ref int dniTrabajador, ref int dniAdmin, ref int dniProfe, AsignacionTrabajos Asignacion) 
        {
            bool verificacion = false;
            do
            {
                try
                {

                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("\n\\t\t\t\t\t\t\t\t\t\t\t\t\t              Está iniciando sesión como trabajador");
                    Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t===================================================================");
                    Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t  Llene los siguientes campos o ingrese el número 2 para volver");
                    Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t===================================================================");

                    verificacion = inicioSesion.InicioSesión(opc, Lu, LTra, La, Lp, ref dniUser, ref dniTrabajador, ref dniAdmin, ref dniProfe);

                    //etornar = int.Parse(Console.ReadLine());
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
                        Console.WriteLine("\n\t\t\t\t\t\t\t\t\t\t\t\t\t... Número de DNI o contraseña incorrectos.");
                        Console.ReadLine();
                    }
                }
                catch
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("\n\t\t\t\t\t\t\t\t\t\t\t\t\t  Error... Dni debe contener solo caracteres númericos");
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
                        Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t Bienvenido señor " + nombreCompleto);
                        Console.WriteLine("\n\t\t\t\t\t\t\t\t\t\t\t\t\t==============================================");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("\n\t\t\t\t\t\t\t\t\t\t\t\t\t >  1. Gestionar tickets\n\n\t\t\t\t\t\t\t\t\t\t\t\t\t >  2. Gestionar alumnos\n\n\t\t\t\t\t\t\t\t\t\t\t\t\t >  3. Gestionar computadoras\n\n\t\t\t\t\t\t\t\t\t\t\t\t\t >  4. Marcar hora de salida \n\n\t\t\t\t\t\t\t\t\t\t\t\t\t >  5. Volver");
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("\n\t\t\t\t\t\t\t\t\t\t\t\t\t==============================================");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("\t\t\t\t\t\t\t\t\t\t\t\t\t >  Elija una opción: ");
                        opc = int.Parse(Console.ReadLine());
                        switch (opc)
                        {
                            case 1:
                                int codigo;
                                codigo = LTra.ObtenerCodigoConDNI(dniTrabajador);
                                program.GestionTickets(2, nombreCompleto, codigo);
                                opc = 0;
                                break;


                            case 2:
                                do
                                {
                                    try
                                    {
                                        Console.Clear();
                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                        Console.WriteLine("\n\n\t\t\t\t\t\t\t\t\t\t\t\t\t======== Gestionando Alumnos ========");
                                        Console.ForegroundColor = ConsoleColor.Yellow;
                                        Console.WriteLine("\n\t\t\t\t\t\t\t\t\t\t\t\t\t >  1. Mostrar lista de alumnos\n\n\t\t\t\t\t\t\t\t\t\t\t\t\t >  2. Modificar datos del alumno \n\n\t\t\t\t\t\t\t\t\t\t\t\t\t >  3. Eliminar alumno \n\n\t\t\t\t\t\t\t\t\t\t\t\t\t >  4. Volver");
                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                        Console.WriteLine("\n\t\t\t\t\t\t\t\t\t\t\t\t\t=====================================");
                                        Console.ForegroundColor = ConsoleColor.Yellow;
                                        Console.Write("\t\t\t\t\t\t\t\t\t\t\t\t\t >  Elija una opción: ");
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
                                                    Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t========================================================================================");
                                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                                    Console.Write("\t\t\t\t\t\t\t\t\t\t\t\t\t >  Ingrese el código del alumno del cual desea modificar datos: ");
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
                                                            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t... Alumno no econtrado. Ingrese el código correcto o el ingrese el número 2 para volver");
                                                            Console.ReadLine();
                                                        }
                                                    }
                                                    else if (verificacion == false)
                                                    {
                                                        Console.ForegroundColor = ConsoleColor.DarkRed;
                                                        Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t... El código debe contener solo caracteres númericos");
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
                                                Console.WriteLine("\n\t\t\t\t\t\t\t\t\t\t\t\t\t... Ingrese una opción valida");
                                                Console.ReadLine();
                                                opc = 0;
                                                break;

                                        }
                                    }
                                    catch
                                    {
                                        Console.ForegroundColor = ConsoleColor.DarkRed;
                                        Console.WriteLine("\n\t\t\t\t\t\t\t\t\t\t\t\t\t.. < Ingrese una opción valida >");
                                        Console.ReadLine();
                                    }

                                } while (opc != 4);

                                opc = 0;
                                break;

                            case 3:

                                do
                                {
                                    try
                                    {
                                        Console.Clear();
                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                        Console.WriteLine("\n\n\t\t\t\t\t\t\t\t\t\t\t\t\t==================== Gestionando Computadoras ====================");
                                        Console.ForegroundColor = ConsoleColor.Yellow;
                                        Console.WriteLine("\n\t\t\t\t\t\t\t\t\t\t\t\t\t > 1. Agregar nueva computadora a la lista");
                                        Console.WriteLine("\n\t\t\t\t\t\t\t\t\t\t\t\t\t > 2. Buscar computadora por código");
                                        Console.WriteLine("\n\t\t\t\t\t\t\t\t\t\t\t\t\t > 3. Modificar información de una computadora excepto su código");
                                        Console.WriteLine("\n\t\t\t\t\t\t\t\t\t\t\t\t\t > 4. Mostrar computadoras de un mismo salon.");
                                        Console.WriteLine("\n\t\t\t\t\t\t\t\t\t\t\t\t\t > 6. Eliminar una computadora de la lista");
                                        Console.WriteLine("\n\t\t\t\t\t\t\t\t\t\t\t\t\t > 7. Visualizar lista de computadoras");
                                        Console.WriteLine("\n\t\t\t\t\t\t\t\t\t\t\t\t\t > 8. Volver");
                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                        Console.WriteLine("\n\t\t\t\t\t\t\t\t\t\t\t\t\t====================================================================");
                                        Console.ForegroundColor = ConsoleColor.Yellow;
                                        Console.Write("\t\t\t\t\t\t\t\t\t\t\t\t\t > Elija una opción: ");
                                        opc = int.Parse(Console.ReadLine());

                                        switch (opc)
                                        {
                                            case 1:
                                                
                                                bool flag;
                                                string codigoC = " ", marca = " ", sistemaO = " ", ram = " ", almacenamiento = " ", tarjetaM = " ", salon = " ", piso = " ", edificio = " ";
                                                do
                                                {

                                                    Console.Clear();
                                                    Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t                  Registrando computadoras ");
                                                    Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t---------------------------------------------------------");
                                                    Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t Si desea salir y no registrar nada, \n\t\t\t\t\t\t\t\t\t\t\t\t\tingrese el numero 2 en cualquier parte del código  ");
                                                    Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t---------------------------------------------------------");
                                                    
                                                    Console.Write("\t\t\t\t\t\t\t\t\t\t\t\t\t Código de la computadora        : ");
                                                    codigoC = Console.ReadLine();
                                                    flag = validacion.ValidacionDeCadenaVaciaEIngresoNum2(codigoC);
                                                    if (codigoC == "2")
                                                    {
                                                        flag = false;
                                                        break;
                                                    }
                                                    else if (flag == false)
                                                    {
                                                        Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t El código de la computadora no puede quedar en blanco.");
                                                        Console.ReadLine();
                                                    }

                                                } while (flag == false);

                                                if (flag == true)
                                                {
                                                    do
                                                    {
                                                        Console.Write("\t\t\t\t\t\t\t\t\t\t\t\t\t Marca de la computadora         : ");
                                                        marca = Console.ReadLine();

                                                        flag = validacion.ValidacionDeCadenaVaciaEIngresoNum2(marca);

                                                        if (marca == "2")
                                                        {
                                                            flag = false;
                                                            break;
                                                        }
                                                        else if (flag == false)
                                                        {
                                                            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t La marca de la computadora no puede quedar en blanco.");
                                                            Console.ReadLine();
                                                        }
                                                    } while (flag == false);
                                                }
                                                if (flag == true)
                                                {
                                                    do
                                                    {
                                                        Console.Write("\t\t\t\t\t\t\t\t\t\t\t\t\t Sistema Operativo               : ");
                                                        sistemaO = Console.ReadLine();

                                                        flag = validacion.ValidacionDeCadenaVaciaEIngresoNum2(sistemaO);

                                                        if (sistemaO == "2")
                                                        {
                                                            flag = false;
                                                            break;
                                                        }
                                                        else if (flag == false)
                                                        {
                                                            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t El Sistema Operativo de la computadora no puede quedar en blanco.");
                                                            Console.ReadLine();
                                                        }

                                                    } while(flag == false);
                                                }
                                                if (flag == true)
                                                {
                                                    do
                                                    {

                                                        Console.Write("\t\t\t\t\t\t\t\t\t\t\t\t\t RAM (poner dos decimales .00)   : ");
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
                                                                Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\tLa ram no puede poseer caracteres no númericos");
                                                                Console.ReadLine();
                                                            }
                                                        }
                                                        else if (flag == false)
                                                        {
                                                            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\tLa ram no puede quedar vacia");
                                                            Console.ReadLine();
                                                        }

                                                    } while (flag != true);
                                                }

                                                if(flag == true)
                                                {
                                                    do { 
                                                        Console.Write("\t\t\t\t\t\t\t\t\t\t\t\t\t Almacenamiento de la computadora: ");
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
                                                                Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\tLa ram no puede poseer caracteres no númericos");
                                                                Console.ReadLine();
                                                            }
                                                        }
                                                        else if (flag == false)
                                                        {
                                                            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\tLa ram no puede quedar vacia");
                                                            Console.ReadLine();
                                                        }

                                                    } while (flag != true) ;
                                                }
                                                if (flag == true)
                                                {
                                                    do { 
                                                        Console.Write("\t\t\t\t\t\t\t\t\t\t\t\t\t Tarjeta madre: ");
                                                        tarjetaM = Console.ReadLine();

                                                        flag = validacion.ValidacionDeCadenaVaciaEIngresoNum2(tarjetaM);
                                                        if (tarjetaM == "2")
                                                        {
                                                            flag = false;
                                                            break;
                                                        }
                                                        else if (flag == false)
                                                        {
                                                            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t El código de la computadora no puede quedar en blanco.");
                                                            Console.ReadLine();
                                                        }

                                                        } while (flag == false) ;
                                                }
                                                
                                                if (flag == true)
                                                {
                                                    Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t            Ubicación de uso de la computadora ");
                                                    Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t===========================================================");
                                                    Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t ");
                                                }
                                                
                                                if(flag == true)
                                                {
                                                    do
                                                    {
                                                        Console.Write("\t\t\t\t\t\t\t\t\t\t\t\t\tSalón                            : ");
                                                         salon = Console.ReadLine();

                                                        flag = validacion.ValidacionDeCadenaVaciaEIngresoNum2(salon);
                                                        if (salon == "2")
                                                        {
                                                            flag = false;
                                                            break;
                                                        }
                                                        else if (flag == false)
                                                        {
                                                            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t El código de la computadora no puede quedar en blanco.");
                                                            Console.ReadLine();
                                                        }

                                                    } while (flag == false);

                                                } while (flag == false);

                                                if (flag == true)
                                                {
                                                    do
                                                    {
                                                        Console.Write("\t\t\t\t\t\t\t\t\t\t\t\t\tPiso                             : ");
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
                                                                Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\tEl piso no puede poseer caracteres no númericos");
                                                                Console.ReadLine();
                                                            }
                                                        }
                                                        else if (flag == false)
                                                        {
                                                            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\tEl piso no puede quedar vacia");
                                                            Console.ReadLine();
                                                        }

                                                    } while (flag == false);
                                                }
                                                if (flag == true)
                                                {
                                                    do
                                                    {
                                                        Console.Write("\t\t\t\t\t\t\t\t\t\t\t\t\tEdificio                         : ");
                                                        edificio = Console.ReadLine();
                                                        flag = validacion.ValidacionDeCadenaVaciaEIngresoNum2(edificio);
                                                        
                                                        if(edificio == "2")
                                                        {
                                                            flag = false;
                                                            break;
                                                        }
                                                        else if(flag == false)
                                                        {
                                                            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t Edificio no puede quedar en blanco.");
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
                                                Console.Write("\t\t\t\t\t\t\t\t\t\t\t\t\tIngrese el código de la computadora a buscar: ");
                                                string codigoBus = Console.ReadLine();
                                                ArbCom.buscarPorCompuPorCodigo(codigoBus);
                                                Console.ReadLine();

                                                opc = 0;
                                                break;

                                            case 3:

                                                do
                                                {

                                                    Console.Clear();
                                                    Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t               Modificación de datos de una computadora            ");
                                                    Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t-------------------------------------------------------------------");
                                                    Console.Write("\t\t\t\t\t\t\t\t\t\t\t\t\t >  Ingrese código de la computadora a modificar: ");
                                                    string codigoBusqueda = Console.ReadLine();

                                                    verificacion = ArbCom.SaberSiExisteCompu(ArbCom.arbolito, codigoBusqueda);

                                                    if (verificacion == true)
                                                    {
                                                        do
                                                        {
                                                            
                                                            Console.Clear();
                                                            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t        Modificación de datos de una computadora       ");
                                                            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t-------------------------------------------------------");
                                                            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t >  1. Modificar Salon");
                                                            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t >  2. Modificar Piso");
                                                            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t >  3. Modificar Edificio");
                                                            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t >  4. Modificar Sistema Operativo");
                                                            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t >  5. Modificar Ram");
                                                            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t >  6. Modificar Almacenamiento");
                                                            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t >  7. Modificar Marca");
                                                            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t >  8. Volver");
                                                            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t-------------------------------------------------------");
                                                            Console.Write("\t\t\t\t\t\t\t\t\t\t\t\t\t >  Elija una opción: ");
                                                            opc = int.Parse(Console.ReadLine());
                                                            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t-------------------------------------------------------");
                                                            switch (opc)
                                                            {
                                                                case 1:

                                                                    Console.Clear();
                                                                    Console.Write("\t\t\t\t\t\t\t\t\t\t\t\t\t  Ingrese el nuevo salon donde se encontrará la computadora:");
                                                                    string salonNew = Console.ReadLine();

                                                                    ArbCom.ModificarDatosCompu(salonNew, 0, 0, codigoBusqueda, opc, ArbCom.arbolito);

                                                                    Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t Data modificada con exito! ");
                                                                    Console.ReadLine();

                                                                    break;
                                                                case 2:

                                                                    Console.Clear();
                                                                    Console.Write("\t\t\t\t\t\t\t\t\t\t\t\t\t  Ingrese el nuevo piso donde se encontrará la computadora:");
                                                                    int pisoNew = int.Parse(Console.ReadLine());

                                                                    ArbCom.ModificarDatosCompu(" ", 0, pisoNew, codigoBusqueda, opc, ArbCom.arbolito);

                                                                    Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t Data modificada con exito! ");
                                                                    Console.ReadLine();

                                                                    break;
                                                                case 3:

                                                                    Console.Clear();
                                                                    Console.Write("\t\t\t\t\t\t\t\t\t\t\t\t\t  Ingrese el nuevo edificio donde se encontrará la computadora:");
                                                                    string edificioNew = Console.ReadLine();

                                                                    ArbCom.ModificarDatosCompu(edificioNew, 0, 0, codigoBusqueda, opc, ArbCom.arbolito);


                                                                    Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t Data modificada con exito! ");
                                                                    Console.ReadLine();

                                                                    break;
                                                                case 4:

                                                                    Console.Clear();
                                                                    Console.Write("\t\t\t\t\t\t\t\t\t\t\t\t\t  Ingrese el nuevo sistema operativo de la computadora:");
                                                                    string SistemaOpNew = Console.ReadLine();

                                                                    ArbCom.ModificarDatosCompu(SistemaOpNew, 0, 0, codigoBusqueda, opc, ArbCom.arbolito);

                                                                    Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t Data modificada con exito! ");
                                                                    Console.ReadLine();

                                                                    break;
                                                                case 5:

                                                                    Console.Clear();
                                                                    Console.Write("\t\t\t\t\t\t\t\t\t\t\t\t\t  Ingrese la nueva ram de la computadora:");
                                                                    double ramNew = double.Parse(Console.ReadLine());

                                                                    ArbCom.ModificarDatosCompu(" ", ramNew, 0, codigoBusqueda, opc, ArbCom.arbolito);

                                                                    Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t Data modificada con exito! ");
                                                                    Console.ReadLine();
                                                                    break;
                                                                case 6:

                                                                    Console.Clear();
                                                                    Console.Write("\t\t\t\t\t\t\t\t\t\t\t\t\t  Ingrese el nuevo almacenamiento de la computadora:");
                                                                    double almacenamientoNew = double.Parse(Console.ReadLine()); 

                                                                    ArbCom.ModificarDatosCompu(" ", almacenamientoNew, 0, codigoBusqueda, opc, ArbCom.arbolito);

                                                                    Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t Data modificada con exito! ");
                                                                    Console.ReadLine();

                                                                    break;
                                                                case 7:
                                                                    Console.Clear();
                                                                    Console.Write("\t\t\t\t\t\t\t\t\t\t\t\t\t  Ingrese la nueva marca de la computadora:");
                                                                    string marcaNew = Console.ReadLine();

                                                                    ArbCom.ModificarDatosCompu(marcaNew, 0, 0, codigoBusqueda, opc, ArbCom.arbolito);

                                                                    Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t Data modificada con exito! ");
                                                                    Console.ReadLine();

                                                                    break;
                                                                case 8:
                                                                    break;
                                                                default:
                                                                    Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t >  Ingrese una opción valida");
                                                                    break;
                                                            }
                                                        } while (opc != 8);
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t >.  Máquina no encontrada, por favor verifique el código.");
                                                    }

                                                } while (verificacion != true);
                                                opc = 0;
                                                break;
                                            case 4:
                                                Console.Clear();
                                                Console.Write("\t\t\t\t\t\t\t\t\t\t\t\t\t Ingrese el salon: ");
                                                string codigoBusSal = Console.ReadLine();
                                                ArbCom.MostrarArbolitoPorSalon(ArbCom.arbolito, codigoBusSal);
                                                Console.ReadLine();


                                                opc = 0;
                                                break;

                                            case 5:

                                                Console.Clear();

                                                Console.Write("\t\t\t\t\t\t\t\t\t\t\t\t\tIngrese la marca que desea buscar: ");
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
                                                //ARBOL VERTICAL
                                                Console.Clear();
                                                Console.WriteLine("Árbol de computadoras en formato vertical:");
                                                ArbCom.mostrarArbolitoVertical(ArbCom.arbolito, 0);
                                                Console.ReadLine();
                                                opc = 0;
                                                break;

                                            case 9:
                                                
                                                break;
                                            default:
                                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                                Console.WriteLine("\n\t\t\t\t\t\t\t\t\t\t\t\t\t... Ingrese una opción valida");
                                                Console.ReadLine();
                                                opc = 0;
                                                break;
                                        }
                                    }
                                    catch
                                    {
                                        Console.ForegroundColor = ConsoleColor.DarkRed;
                                        Console.WriteLine("\n\t\t\t\t\t\t\t\t\t\t\t\t\t.. < Ingrese una opción valida >");
                                        Console.ReadLine();
                                    }

                                }while(opc != 5);

                                break;
                            
                            case 4:
                                Console.Clear();
                                int codigoYea = LTra.ObtenerCodigoConDNI(dniTrabajador);
                                LTra.MarcarSalida(codigoYea);
                                break;

                            case 5://SALIDA DEL PROGRAMA
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
                        Console.WriteLine("\n\t\t\t\t\t\t\t\t\t\t\t\t\t.. < Ingrese una opción valida >");
                        Console.ReadLine();
                    }
                } while (opc != 5);
            }
         }
    }
}
