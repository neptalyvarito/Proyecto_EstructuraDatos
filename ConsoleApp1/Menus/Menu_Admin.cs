﻿using Microsoft.Win32;
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
        public static GenerarTicket generarTikcetsito = new GenerarTicket();
        public static string nombreCompleto;
        
        public void menuAdmin(int opc, Log_in inicioSesion, Lista_Alumnos Lu, Lista_Trabajadores LTra, Lista_Administrativos La, Lista_Tickets Ltick, Lista_Profes Lp, Cola_Solicitudes ColSol, ref Solicitudes q, Pila_Sugerencia PilSug, Registros registro, ref int dniUser, ref int dniTrabajador, ref int dniAdmin, ref int dniProfe, ColaPrio_Ticket colitaPrio)
        {
            bool verificacion = false;
            int opcMandar = 0;
            do
            {
                try
                {

                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("\n\n\t\t\t\t\t\t\t\t\t\t\t\t\t           Está iniciando sesión como administrador");
                    Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t===================================================================");
                    Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t  Llene los siguientes campos o ingrese el número 2 para volver");
                    Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t===================================================================");

                    verificacion = inicioSesion.InicioSesión(opc, Lu, LTra, La, Lp, ref dniUser, ref dniTrabajador, ref dniAdmin, ref dniProfe);

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
                        Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t... Número de DNI o contraseña incorrectos.");
                        Console.ReadLine();
                    }
                }
                catch 
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t Error.... Dni debe contener solo caracteres númericos");
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
                        Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t Bienvenido señor " + nombreCompleto);
                        Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t===============================================");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("\n\t\t\t\t\t\t\t\t\t\t\t\t\t >  1. Gestionar alumnos");
                        Console.WriteLine("\n\t\t\t\t\t\t\t\t\t\t\t\t\t >  2. Gestionar docentes");
                        Console.WriteLine("\n\t\t\t\t\t\t\t\t\t\t\t\t\t >  3. Gestionar trabajadores");
                        Console.WriteLine("\n\t\t\t\t\t\t\t\t\t\t\t\t\t >  4. Gestionar administrativos");
                        Console.WriteLine("\n\t\t\t\t\t\t\t\t\t\t\t\t\t >  5. Gestionar tickets");
                        Console.WriteLine("\n\t\t\t\t\t\t\t\t\t\t\t\t\t >  6. Gestionar solicitudes");
                        Console.WriteLine("\n\t\t\t\t\t\t\t\t\t\t\t\t\t >  7. Gestionar sugerencias");
                        Console.WriteLine("\n\t\t\t\t\t\t\t\t\t\t\t\t\t >  8. Generar Reporte");
                        Console.WriteLine("\n\t\t\t\t\t\t\t\t\t\t\t\t\t >  9. Volver");
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("\n\t\t\t\t\t\t\t\t\t\t\t\t\t===============================================");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("\n\t\t\t\t\t\t\t\t\t\t\t\t\t >  Ingrese opción: ");
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
                                        Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t           Gestionando Alumnos");
                                        Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t==============================================");
                                        Console.ForegroundColor = ConsoleColor.Yellow;
                                        Console.WriteLine("\n\t\t\t\t\t\t\t\t\t\t\t\t\t >  1. Crear alumnos\n\n\t\t\t\t\t\t\t\t\t\t\t\t\t >  2. Ver lista de alumnos\n\n\t\t\t\t\t\t\t\t\t\t\t\t\t >  3. Modificar datos del alumno \n\n\t\t\t\t\t\t\t\t\t\t\t\t\t >  4. Eliminar alumno\n\n\t\t\t\t\t\t\t\t\t\t\t\t\t >  5. Volver");
                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                        Console.WriteLine("\n\t\t\t\t\t\t\t\t\t\t\t\t\t==============================================");
                                        Console.ForegroundColor = ConsoleColor.Yellow;
                                        Console.Write("\n\t\t\t\t\t\t\t\t\t\t\t\t\t >  Ingrese opción: ");
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
                                                    
                                                    string aux;
                                                    Console.ForegroundColor = ConsoleColor.Cyan;
                                                    Console.Write("\n\t\t\t\t\t\t\t\t\t\t\t\t\t============================================================================");
                                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                                    Console.Write("\n\n\t\t\t\t\t\t\t\t\t\t\t\t\t >  Ingrese el código del alumno del cual desea modificar datos: ");
                                                    aux = Console.ReadLine();

                                                    verificacion = validacion.ValidacionIngresoSoloNum(aux);

                                                    if (aux == "2")
                                                    {
                                                        break;
                                                    }
                                                    else if (verificacion == true)
                                                    {
                                                        int codigo3 = int.Parse(aux);
                                                        verificacion = Lu.SaberSiExisteUsuarioConCodigo(codigo3);
                                                        if (verificacion == true)
                                                        {
                                                            program.ModificacionUsuariosTrabajsYAdmins(codigo3, opcMandar);
                                                        }
                                                        else
                                                        {
                                                            Console.ForegroundColor = ConsoleColor.DarkRed;
                                                            Console.WriteLine("\n\t\t\t\t\t\t\t\t\t\t\t\t\t... Alumno no econtrado.\n\t\t\t\t\t\t\t\t\t\t\t\t\t... Ingrese el código correcto o el ingrese el número 2 para volver.");
                                                            Console.ReadLine();
                                                        }
                                                    }
                                                    else if(verificacion == false)
                                                    {
                                                        Console.ForegroundColor = ConsoleColor.DarkRed;
                                                        Console.WriteLine("\n\t\t\t\t\t\t\t\t\t\t\t\t\t... El código debe contener solo caracteres númericos");
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
                                                Console.WriteLine("\n\t\t\t\t\t\t\t\t\t\t\t\t\t.. < Ingrese una opción valida >");
                                                Console.ReadLine();
                                                break;
                                        }
                                    }
                                    catch
                                    {
                                        Console.ForegroundColor = ConsoleColor.DarkRed;
                                        Console.WriteLine("\n\t\t\t\t\t\t\t\t\t\t\t\t\t.. < Ingrese un dato valido >");
                                        Console.ReadLine();
                                    }

                                } while (opc != 5);

                                opc = 0;
                                break;

                            case 2:
                                do
                                {
                                    Console.Clear();
                                    Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t======== Gestionando docentes =======");
                                    Console.WriteLine("\n\t\t\t\t\t\t\t\t\t\t\t\t\t >  1. Agregar docente");
                                    Console.WriteLine("\n\t\t\t\t\t\t\t\t\t\t\t\t\t >  2. Mostrar lista de docentes");
                                    Console.WriteLine("\n\t\t\t\t\t\t\t\t\t\t\t\t\t >  3. Volver");
                                    Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t=====================================");
                                    Console.Write("\n\t\t\t\t\t\t\t\t\t\t\t\t\t >  Ingrese opción: ");
                                    opc = int.Parse(Console.ReadLine());

                                    switch (opc)
                                    {
                                        case 1:
                                            Console.Clear();
                                            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t         Registrando nuevo profesor           ");
                                            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t----------------------------------------------");
                                            Console.Write("\n\t\t\t\t\t\t\t\t\t\t\t\t\t >  Nombres: ");
                                            string nombres = Console.ReadLine();
                                            Console.Write("\n\t\t\t\t\t\t\t\t\t\t\t\t\t >  Apellidos: ");
                                            string apellido = Console.ReadLine();
                                            Console.Write("\n\t\t\t\t\t\t\t\t\t\t\t\t\t >  Dni: ");
                                            int dni = int.Parse(Console.ReadLine());
                                            Console.Write("\n\t\t\t\t\t\t\t\t\t\t\t\t\t >  Número celular: ");
                                            int numeroCel = int.Parse(Console.ReadLine());
                                            Console.Write("\n\t\t\t\t\t\t\t\t\t\t\t\t\t >  Contraseña: ");
                                            string contrasena = Console.ReadLine();
                                            Lp.RegistrarProfe(nombres, apellido, dni, numeroCel, contrasena);
                                            break;
                                        case 2:
                                            Lp.MostrarListaProfes();
                                            Console.ReadLine();
                                            break;
                                        case 3:
                                            break;
                                        default:
                                            break;
                                    }

                                } while (opc != 3);
                                break;

                            case 3:

                                do
                                {
                                    try
                                    {
                                        Console.Clear();
                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                        Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t      Gestionando Trabajadores");
                                        Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t============================================");
                                        Console.ForegroundColor = ConsoleColor.Yellow;
                                        Console.WriteLine("\n\t\t\t\t\t\t\t\t\t\t\t\t\t >  1. Crear trabajador\n\n >  2. Ver lista de trabajadorres \n\n >  3. Modificar datos del trabajador \n\n >  4. Eliminar trabajador\n\n >  5. Volver");
                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                        Console.WriteLine("\n\t\t\t\t\t\t\t\t\t\t\t\t\t============================================");
                                        Console.ForegroundColor = ConsoleColor.Yellow;
                                        Console.Write("\t\t\t\t\t\t\t\t\t\t\t\t\t >  Ingrese opción: ");
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
                                                    int codigo2;
                                                    string aux;
                                                    Console.ForegroundColor = ConsoleColor.Cyan;
                                                    Console.Write("\n\t\t\t\t\t\t\t\t\t\t\t\t\t===============================================================================");
                                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                                    Console.Write("\n\t\t\t\t\t\t\t\t\t\t\t\t\t >  Ingrese el código del trabajador del cual desea modificar datos: ");
                                                    aux = Console.ReadLine();

                                                    verificacion = validacion.ValidacionIngresoSoloNum(aux);

                                                    if (aux == "2")
                                                    {
                                                        break;
                                                    }
                                                    else if (verificacion == true)
                                                    {
                                                        codigo2 = int.Parse(aux);
                                                        verificacion = LTra.SaberSiExisteTrabajadorConCodigo(codigo2);
                                                        if (verificacion == true)
                                                        {
                                                            program.ModificacionUsuariosTrabajsYAdmins(codigo2, opcMandar);
                                                        }
                                                        else
                                                        {
                                                            Console.ForegroundColor = ConsoleColor.DarkRed;
                                                            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t... Trabajador no econtrado. Ingrese el código correcto o el ingrese el número 2 para volver");
                                                            Console.ReadLine();
                                                        }
                                                    }
                                                    else if (verificacion == false)
                                                    {
                                                        Console.ForegroundColor = ConsoleColor.Yellow;
                                                        Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t... El código debe contener solo caracteres númericos");
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
                                                Console.WriteLine("\n\t\t\t\t\t\t\t\t\t\t\t\t\t.. < Ingrese una opción valida >");
                                                Console.ReadLine();

                                                break;
                                        }
                                    }
                                    catch
                                    {
                                        Console.WriteLine("\n\t\t\t\t\t\t\t\t\t\t\t\t\t.. < Ingrese un dato valido >");
                                        Console.ReadLine();
                                    }

                                } while (opc != 5);

                                opc = 0;
                                break;

                            case 4:
                                do
                                {
                                    try
                                    {
                                        Console.Clear();
                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                        Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t       Gestionando Administrativos");
                                        Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t===========================================");
                                        Console.ForegroundColor = ConsoleColor.Yellow;
                                        Console.WriteLine("\n\t\t\t\t\t\t\t\t\t\t\t\t\t >  1. Crear administrativo\n\n\t\t\t\t\t\t\t\t\t\t\t\t\t >  2. Ver lista de administrativos \n\n\t\t\t\t\t\t\t\t\t\t\t\t\t >  3. Modificar datos del administrativo \n\n\t\t\t\t\t\t\t\t\t\t\t\t\t >  4. Elimar administrativo \n\n\t\t\t\t\t\t\t\t\t\t\t\t\t >  5. Volver");
                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                        Console.WriteLine("\n\t\t\t\t\t\t\t\t\t\t\t\t\t===========================================");
                                        Console.ForegroundColor = ConsoleColor.Yellow;
                                        Console.Write("\t\t\t\t\t\t\t\t\t\t\t\t\t >  Ingrese opción: ");
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
                                                    int codigo1;
                                                    string aux;
                                                    Console.ForegroundColor = ConsoleColor.Cyan;
                                                    Console.Write("\n\n\t\t\t\t\t\t\t\t\t\t\t\t\t==================================================================================");
                                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                                    Console.Write("\n\t\t\t\t\t\t\t\t\t\t\t\t\t >  Ingrese el código del administrador del cual desea modificar datos: ");
                                                    aux = Console.ReadLine();

                                                    verificacion = validacion.ValidacionIngresoSoloNum(aux);

                                                    if (aux == "2")
                                                    {
                                                        break;
                                                    }
                                                    else if (verificacion == true)
                                                    {
                                                        codigo1 = int.Parse(aux);
                                                        verificacion = La.SaberSiExisteAdminConCodigo(codigo1);
                                                        if (verificacion == true)
                                                        {
                                                            program.ModificacionUsuariosTrabajsYAdmins(codigo1, opcMandar);
                                                        }
                                                        else
                                                        {
                                                            Console.ForegroundColor = ConsoleColor.DarkRed;
                                                            Console.WriteLine("\n\t\t\t\t\t\t\t\t\t\t\t\t\t... Administrador no econtrado.\n\t\t\t\t\t\t\t\t\t\t\t\t\t... Ingrese el código correcto o el ingrese el número 2 para volver");
                                                            Console.ReadLine();
                                                        }
                                                    }
                                                    else if (verificacion == false)
                                                    {
                                                        Console.ForegroundColor = ConsoleColor.DarkRed;
                                                        Console.WriteLine("\n\t\t\t\t\t\t\t\t\t\t\t\t\t... El código debe contener solo caracteres númericos");
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
                                                Console.WriteLine("\n\t\t\t\t\t\t\t\t\t\t\t\t\t.. < Ingrese un dato valido >");
                                                Console.ReadLine();
                                                break;

                                        }
                                    }
                                    catch
                                    {
                                        Console.ForegroundColor = ConsoleColor.DarkRed;
                                        Console.WriteLine("\n\t\t\t\t\t\t\t\t\t\t\t\t\t.. < Ingrese una opción valida > ");
                                        Console.ReadLine();
                                    }

                                } while (opc != 5);

                                opc = 0;
                                break;

                            case 5:

                                int codigo;
                                codigo = La.ObtenerCodigoAdmin(dniAdmin);
                                program.GestionTickets(4, nombreCompleto, codigo);

                                opc = 0;
                                break;

                            case 6:
                                do
                                {
                                    try
                                    {
                                        Console.Clear();
                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                        Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t        Gestionando solicitudes     ");
                                        Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t=======================================");
                                        Console.ForegroundColor = ConsoleColor.Yellow;
                                        Console.WriteLine("\n\t\t\t\t\t\t\t\t\t\t\t\t\t >  1. Ver todas las solicitudes");
                                        //Console.WriteLine(" 2. Confirmar o denegar solicitud");
                                        Console.WriteLine("\n\t\t\t\t\t\t\t\t\t\t\t\t\t >  2. Eliminar lista en orden");
                                        Console.WriteLine("\n\t\t\t\t\t\t\t\t\t\t\t\t\t >  3. Vaciar lista de solicitudes");
                                        Console.WriteLine("\n\t\t\t\t\t\t\t\t\t\t\t\t\t >  4. Volver");
                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                        Console.WriteLine("\n\t\t\t\t\t\t\t\t\t\t\t\t\t=======================================");
                                        Console.ForegroundColor = ConsoleColor.Yellow;
                                        Console.Write("\n\t\t\t\t\t\t\t\t\t\t\t\t\t >  Ingrese su opcion: ");
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

                                                    Console.WriteLine("\n\t\t\t\t\t\t\t\t\t\t\t\t\t Se ha eliminado la primera solicitud en espera");
                                                    Console.WriteLine("\n\t\t\t\t\t\t\t\t\t\t\t\t\t Caracteristicas de solicitud eliminada: ");
                                                    Console.Write("\n\n\t\t\t\t\t\t\t\t\t\t\t\t\t Solicitante: ");

                                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                                    Console.Write(muestra.Solicitante);

                                                    Console.ForegroundColor = ConsoleColor.Cyan;
                                                    Console.Write("\n\n\t\t\t\t\t\t\t\t\t\t\t\t\t Destinatarios: ");
                                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                                    Console.Write(muestra.Destinatario);

                                                    Console.ForegroundColor = ConsoleColor.Cyan;
                                                    Console.Write("\n\n\t\t\t\t\t\t\t\t\t\t\t\t\t Tipo de Solicitud: ");
                                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                                    Console.Write(muestra.TipoSolicitud);

                                                    Console.ForegroundColor = ConsoleColor.Cyan;
                                                    Console.Write("\n\n\t\t\t\t\t\t\t\t\t\t\t\t\t Condicion: ");
                                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                                    Console.Write(muestra.Condicion);

                                                    Console.ForegroundColor = ConsoleColor.Cyan;
                                                    Console.Write("\n\n\t\t\t\t\t\t\t\t\t\t\t\t\t Mensaje: ");
                                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                                    Console.Write(muestra.MensajeParaUsuario);

                                                    Console.ReadLine();
                                                }
                                                else
                                                {
                                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                                    Console.WriteLine("\n\t\t\t\t\t\t\t\t\t\t\t\t\t  ¡Cola de solicitudes está vacia!");
                                                }
                                                Console.ReadLine();
                                                break;
                                            case 3:
                                                ColSol.EliminarTodasSolicitudes(ref q);
                                                Console.ForegroundColor = ConsoleColor.Yellow;
                                                Console.WriteLine("\n\t\t\t\t\t\t\t\t\t\t\t\t\t ¡Todas las solicitudes han sido eliminadas!");
                                                Console.ReadLine();
                                                break;
                                            case 4:
                                                break;
                                        }
                                    }
                                    catch
                                    {
                                        Console.ForegroundColor = ConsoleColor.DarkRed;
                                        Console.WriteLine("\n\t\t\t\t\t\t\t\t\t\t\t\t\t.. < Ingrese una opcion valida >");
                                    }
                                }
                                while (opc != 4);
                                opc = 0;
                                break;

                            case 7:

                                do
                                {
                                    try
                                    {
                                        Console.Clear();
                                        Sugerencias mostrar;
                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                        Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t         Gestionando sugerencias");
                                        Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t============================================");
                                        Console.ForegroundColor = ConsoleColor.Yellow;
                                        Console.WriteLine("\n\t\t\t\t\t\t\t\t\t\t\t\t\t >  1. Visualizar sugerencias");
                                        Console.WriteLine("\n\t\t\t\t\t\t\t\t\t\t\t\t\t >  2. Eliminar ultima sugerencia hecha");
                                        Console.WriteLine("\n\t\t\t\t\t\t\t\t\t\t\t\t\t >  3. Volver");
                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                        Console.WriteLine("\n\t\t\t\t\t\t\t\t\t\t\t\t\t============================================");
                                        Console.ForegroundColor = ConsoleColor.Yellow;
                                        Console.Write("\n\t\t\t\t\t\t\t\t\t\t\t\t\t >  Ingrese opción: ");
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
                                                    Console.WriteLine("\n\n\t\t\t\t\t\t\t\t\t\t\t\t\t  ¡Se ha removido la ulima sugerencia que ha sido agregada!");
                                                    Console.WriteLine("\n\t\t\t\t\t\t\t\t\t\t\t\t\t Especificaciones de la sugerencia: ");

                                                    Console.Write("\n\n\t\t\t\t\t\t\t\t\t\t\t\t\t Sugerencia:  ");
                                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                                    Console.Write(mostrar.sugerencia);

                                                    Console.ForegroundColor = ConsoleColor.Cyan;
                                                    Console.Write("\n\n\t\t\t\t\t\t\t\t\t\t\t\t\t Fecha de creación: ");
                                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                                    Console.Write(mostrar.fechaCreacion);

                                                    Console.ForegroundColor = ConsoleColor.Cyan;
                                                    Console.WriteLine("\n\t\t\t\t\t\t\t\t\t\t\t\t\t Tabla actualizada: \n\n");
                                                    PilSug.MostrarSugerencia();
                                                    Console.ReadLine();
                                                }
                                                else
                                                {
                                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                                    Console.WriteLine("\n\t\t\t\t\t\t\t\t\t\t\t\t\t  ¡Lista de sugerencias vacia!");
                                                    Console.ReadLine();
                                                }
                                                break;
                                            case 3:
                                                break;
                                            default:
                                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                                Console.WriteLine("\n\t\t\t\t\t\t\t\t\t\t\t\t\t.. < Ingrese una opción valida >");
                                                break;
                                        }
                                    }
                                    catch 
                                    { 
                                        Console.ForegroundColor = ConsoleColor.DarkRed;
                                        Console.WriteLine("\n\t\t\t\t\t\t\t\t\t\t\t\t\t.. < Ingrese un dato valido >");
                                    }

                                } while (opc != 3);

                                opc = 0;
                                break;

                            case 8:
                                do
                                {
                                    try
                                    {
                                        Console.Clear();
                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                        Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t          Seleccione que reporte desea visualizar           ");
                                        Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t===============================================================");
                                        Console.ForegroundColor = ConsoleColor.Yellow;
                                        Console.WriteLine("\n\t\t\t\t\t\t\t\t\t\t\t\t\t >  1. Cantidad de tickets que ha creado cada usuario. ");
                                        Console.WriteLine("\n\t\t\t\t\t\t\t\t\t\t\t\t\t >  2. Cantidad de tickets que se hacreado de cada tipo. ");
                                        Console.WriteLine("\n\t\t\t\t\t\t\t\t\t\t\t\t\t >  3. Volver.");
                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                        Console.WriteLine("\n\t\t\t\t\t\t\t\t\t\t\t\t\t===============================================================");
                                        Console.ForegroundColor = ConsoleColor.Yellow;
                                        Console.Write("\n\t\t\t\t\t\t\t\t\t\t\t\t\t >  Ingrese una opción: ");
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
                                                Console.WriteLine("\n\t\t\t\t\t\t\t\t\t\t\t\t\t.. < Ingrese una opción valida >");
                                                break;
                                        }
                                    }
                                    catch
                                    {
                                        Console.ForegroundColor = ConsoleColor.DarkRed;
                                        Console.WriteLine("\n\t\t\t\t\t\t\t\t\t\t\t\t\t.. < Ingrese un dato valido >");
                                    }
                                } while (opc != 3);
                                opc = 0;
                                break;

                            case 9: //SALIDA
                                break;

                            default:
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.WriteLine("\n\t\t\t\t\t\t\t\t\t\t\t\t\t.. < Ingrese un dato valido >");
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

                } while (opcMandar != 9);
            }




        }
    }
}
