﻿using System;
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

                    Console.WriteLine(" Está iniciando sesión como alumno");
                    Console.WriteLine("-----------------------------------------------------");
                    Console.WriteLine(" Por favor, llene los siguientes campos \n (Si desea volver, por favor, ingrese el número 2):");
                    Console.WriteLine("-----------------------------------------------------");

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

                        codigoBusquedaUser = Lu.ObtenerCodigoUser(dniUser);
                        nombreCompleto = Lu.NombreCompletoUsuario(dniUser);

                        Console.WriteLine(" Bienvenido alumno(a) " + nombreCompleto);
                        Console.WriteLine("---------------------------------------------");
                        Console.WriteLine(" 1. Generar Ticket\n 2. Ver todos mis tickets \n 3. Ver mis tickets resueltos \n 4. Ver mis tickets en espera \n 5. Modificar mis datos \n 6. Realizar Solicitud \n 7. Ver mis solicitudes \n 8. Realizar Sugerencias a la empresa \n 9. Volver");
                        Console.WriteLine("---------------------------------------------");
                        Console.Write(" Ingrese opción: ");
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

                                        Console.WriteLine(" Indicanos el servicio que presenta fallas:");
                                        Console.WriteLine("------------------------------------------------");
                                        Console.WriteLine(" 1. VPN: Conexion, error en VPN.");
                                        Console.WriteLine(" 2. Equipos de computo y accesorios.");
                                        Console.WriteLine(" 3. Redes: Falla de conexión, lentitud, etc.");
                                        Console.WriteLine(" 4. Software: Teams, Windows, Office, etc. ");
                                        Console.WriteLine(" 5. Wifi: falla de conexión, etc.");
                                        Console.WriteLine(" 6. Internet: caida del servicio. ");
                                        Console.WriteLine(" 7. Correo: No envia ni recibe correo ");
                                        Console.WriteLine(" 8. Antivirus:AMP, Umbrell");
                                        Console.WriteLine(" 9. Volver");
                                        Console.WriteLine("------------------------------------------------");
                                        Console.Write(" Ingrese opción: ");
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
                                        Console.Write("\n........Ingrese un dato valido");
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
                                        Console.WriteLine("     Modificando mis datos     ");
                                        Console.WriteLine("----------------------------------");
                                        Console.WriteLine(" 1. Modificar mis nombres\n 2. Modificar mis apellidos \n 3. Modificar mi de número celular\n 4. Modificar mi contraseña \n 5. Volver");
                                        Console.WriteLine("----------------------------------");
                                        Console.Write(" Ingrese opción: ");
                                        opc = int.Parse(Console.ReadLine());
                                        string modificacion1 = " ";
                                        int modificacion2 = 0;

                                        switch (opc)
                                        {
                                            case 1:
                                                do
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine("         Modificando mis datos        ");
                                                    Console.WriteLine("--------------------------------------");
                                                    Console.WriteLine("|         Modificando nombres        |");
                                                    Console.WriteLine("|  Ingrese el número 2 para volver   |");
                                                    Console.WriteLine("--------------------------------------");
                                                    Console.Write(" Por favor ingrese los nuevos nombres: ");

                                                    modificacion1 = Console.ReadLine();

                                                    verificacion = validacion.ValidacionDeCadenaSoloLetras(modificacion1);
                                                    if (modificacion1 == "2") break;
                                                    else if (verificacion == true)
                                                    {
                                                        Lu.ModificarDatosUsers(modificacion1, modificacion2, codigoBusquedaUser, opc);
                                                        Console.WriteLine("\n....Nombres modificados con exito!");
                                                        Console.ReadLine();
                                                    }
                                                    else if (verificacion == false)
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
                                                    Console.Clear();
                                                    Console.WriteLine("         Modificando mis datos        ");
                                                    Console.WriteLine("--------------------------------------");
                                                    Console.WriteLine("|        Modificando apellidos       |");
                                                    Console.WriteLine("|  Ingrese el número 2 para volver   |");
                                                    Console.WriteLine("--------------------------------------");
                                                    Console.Write(" Por favor ingrese los nuevos apellidos: ");
                                                    modificacion1 = Console.ReadLine();

                                                    verificacion = validacion.ValidacionDeCadenaSoloLetras(modificacion1);

                                                    if (modificacion1 == "2") break;

                                                    else if (verificacion == true)
                                                    {
                                                        Lu.ModificarDatosUsers(modificacion1, modificacion2, codigoBusquedaUser, opc);
                                                        Console.WriteLine("\n....Apellidos modificados con exito!");
                                                        Console.ReadLine();
                                                    }

                                                    else if (verificacion == false)
                                                    {
                                                        Console.Write("....Los apellidos no pueden quedar vacios y no deben tener caracteres númericos. O ingrese el número 2 para salir.");
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
                                                    Console.WriteLine("          Modificando mis datos         ");
                                                    Console.WriteLine("----------------------------------------");
                                                    Console.WriteLine("|     Modificando número de celular    |");
                                                    Console.WriteLine("|    Ingrese el número 2 para volver   |");
                                                    Console.WriteLine("----------------------------------------");
                                                    Console.WriteLine("| Ingrese su nuevo número de celular: ");
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
                                                    Console.Clear();
                                                    Console.WriteLine("          Modificando mis datos         ");
                                                    Console.WriteLine("----------------------------------------");
                                                    Console.WriteLine("|        Modificando contraseña        |");
                                                    Console.WriteLine("|    Ingrese el número 2 para volver   |");
                                                    Console.WriteLine("----------------------------------------");
                                                    Console.Write(" Ingrese nueva contraseña: ");
                                                    modificacion1 = Console.ReadLine();

                                                    verificacion = validacion.ValidacionDeCadenaVaciaEIngresoNum2(modificacion1);

                                                    if (modificacion1 == "2") break;

                                                    else if (verificacion == true)
                                                    {
                                                        Lu.ModificarDatosUsers(modificacion1, modificacion2, codigoBusquedaUser, opc);
                                                        Console.WriteLine("\n....Contraseña modificada con exito!");
                                                        Console.ReadLine();
                                                    }
                                                    else if (verificacion == false)
                                                    {

                                                        Console.Write("....La contraseña no debe estar vacia");
                                                        Console.ReadLine();
                                                    }
                                                } while (verificacion != true);

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

                                opc = 0;
                                break;

                            case 6:

                               
                                do
                                {
                                    try
                                    {
                                        Console.Clear();
                                        Console.WriteLine(" Realiza una solicitud ");
                                        Console.WriteLine("---------------------------------------------------------------");
                                        Console.WriteLine(" ¿ El usuario destinatario es usted ?");
                                        Console.WriteLine(" 1. Si");
                                        Console.WriteLine(" 2. No");
                                        Console.WriteLine(" 3. Volver");
                                        Console.WriteLine("---------------------------------------------------------------");
                                        Console.Write(" Ingrese opcion : ");
                                        opc = int.Parse(Console.ReadLine());

                                        switch (opc)
                                        {
                                            case 1:
                                                do
                                                {
                                                    Console.WriteLine("----------------------------------------------");
                                                    Console.WriteLine(" Listo! ");
                                                    Console.Write(" Por favor ingresa tu solicitud:  ");
                                                    string descripcion = Console.ReadLine();

                                                    verificacion = validacion.ValidacionDeCadenaVaciaEIngresoNum2(descripcion);
                                                    if (descripcion == "2")
                                                    {
                                                        break;
                                                    }
                                                    else if (verificacion == true)
                                                    {
                                                        ColSol.AgregarSolicitud(ref q, nombreCompleto,descripcion, nombreCompleto, codigoBusquedaUser);

                                                        Console.WriteLine("----------------------------------------------------");
                                                        Console.WriteLine(" Tu solicitud ha sido enviada con exito");
                                                        Console.ReadLine();
                                                    }
                                                    else if (verificacion == false)
                                                    {
                                                        Console.WriteLine("La solicitud no puede estar en blanco");
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
                                                    Console.WriteLine(" ");
                                                    int codigo;
                                                    Console.WriteLine(" ");
                                                    Console.WriteLine("----------------------------------------------");
                                                    Console.Write("Ingrese el codigo del destinatario:");
                                                    codigo = int.Parse(Console.ReadLine());
                                                    flag = Lu.SaberSiExisteUsuarioConCodigo(codigo);
                                                    if (flag == true)
                                                    {

                                                        Console.WriteLine("----------------------------------------------");

                                                        Console.WriteLine(" Listo! ");
                                                        Console.Write(" Por favor ingresa tu solicitud:  ");
                                                        string descripcion = Console.ReadLine();

                                                        verificacion = validacion.ValidacionDeCadenaVaciaEIngresoNum2(descripcion);
                                                        if (descripcion == "2")
                                                        {
                                                            break;
                                                        }
                                                        else if (verificacion == true)
                                                        {
                                                            ColSol.AgregarSolicitud(ref q, nombreCompleto, descripcion, Lu.ObtenerNombreCompletoUser(codigo), codigoBusquedaUser);

                                                            Console.WriteLine("----------------------------------------------------");
                                                            Console.WriteLine(" Tu solicitud ha sido enviada con exito");
                                                            Console.ReadLine();
                                                        }
                                                        else if (verificacion == false)
                                                        {
                                                            Console.WriteLine("La solicitud no puede estar en blanco");
                                                            Console.ReadLine();
                                                        }
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine(" Usuario no encontrado!");
                                                        Console.WriteLine(" Por favor, ingrese de forma correcta el codigo del usuario destinatario");
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
                                        Console.WriteLine("....Ingrese una opción valida");
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
                                    Console.WriteLine(" Realizando sugerencia a la empresa");
                                    Console.WriteLine("---------------------------------------------------------------");
                                    Console.WriteLine(" Sientase libre de expresar lo que guste, sugerencia es anonima ");
                                    Console.WriteLine(" (Para volver ingrese elnúmero 2) ");
                                    Console.WriteLine("---------------------------------------------------------------");
                                    Console.Write(" Ingrese su sugerencia : ");

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
                                        Console.WriteLine(" Su sugerencia ha sido mandada con exito!");
                                        Console.ReadLine();
                                    }
                                    else if (verificacion == false)
                                    {
                                        Console.WriteLine("La sugerencia no debe quedar en blanco");
                                        Console.ReadLine();
                                    }

                                } while (verificacion != true);

                                break;
                            
                            case 9:
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

                } while (opc != 9);
            }
        }
        public static void GeneraTicketUser(Lista_Tickets Ltick, string categoria)
        {
            bool verificacion;
            do
            {

                Console.Clear();
                Console.WriteLine(" Categoria Seleccionada:  " + categoria);
                Console.WriteLine("---------------------------------------------------------------");
                Console.WriteLine(" Proporciona una breve descripción de tu incidente : ");
                Console.WriteLine(" (Para volver ingrese elnúmero 2) ");
                Console.WriteLine("---------------------------------------------------------------");
                Console.Write(" Por favor, ingrese qué problemas está teniendo : ");

                string descripcion = Console.ReadLine();

                verificacion = validacion.ValidacionDeCadenaVaciaEIngresoNum2(descripcion);
                if (descripcion == "2")
                {
                    break;
                }
                else if (verificacion == true)
                {
                    Ltick.AgregarTicket(nombreCompleto, descripcion, codigoBusquedaUser, categoria);

                    Console.WriteLine("----------------------------------------------------");
                    Console.WriteLine(" Su ticket ha sido creado con exito!");
                    Console.ReadLine();
                }
                else if (verificacion == false)
                {
                    Console.WriteLine("El ingreso de descripcón del ticket no puede estar en blanco");
                    Console.ReadLine();
                }

            } while (verificacion != true);

        }
    }
}            