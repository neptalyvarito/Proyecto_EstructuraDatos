﻿using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Log_in
    {

        public static Validaciones validacion = new Validaciones();
        public static string contrasena;
        public bool InicioSesión(int TipoIngresante, Lista_Alumnos Lu, Lista_Trabajadores LTra, Lista_Administrativos La, Lista_Profes Lp, ref int dniUser, ref int dniTrabajador, ref int dniAdmin, ref int dniProfe)
        {
            bool verificacion = false;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("\n\t\t\t\t\t\t\t\t\t\t\t\t\t >  Ingrese su dni: ");
            if (TipoIngresante == 1)
            {
                dniUser = int.Parse(Console.ReadLine());
                verificacion = validacion.ValidacionIngresoDni(dniUser);
            }
            else if (TipoIngresante == 2)
            {
                dniTrabajador = int.Parse(Console.ReadLine());
                verificacion = validacion.ValidacionIngresoDni(dniTrabajador);
            }
            else if (TipoIngresante == 3)
            {
                dniAdmin = int.Parse(Console.ReadLine());
                verificacion = validacion.ValidacionIngresoDni(dniAdmin);
            }
            else if (TipoIngresante == 4)
            {
                dniProfe = int.Parse(Console.ReadLine());
                verificacion = validacion.ValidacionIngresoDni(dniProfe);
            }
            if (verificacion == true)
            {
                if (dniUser != 2 && dniAdmin != 2 && dniTrabajador != 2)
                {

                    Console.Write("\n\t\t\t\t\t\t\t\t\t\t\t\t\t >  Ingrese su contraseña: ");
                    contrasena = Console.ReadLine();


                    if (TipoIngresante == 1)
                    {
                        verificacion = Lu.BuscarCuentaUsuario(dniUser, contrasena);
                    }
                    else if (TipoIngresante == 2)
                    {
                        verificacion = LTra.BuscarCuentaTrabajadores(dniTrabajador, contrasena);
                    }
                    else if (TipoIngresante == 3)
                    {
                        verificacion = La.BuscarCuentaAdmin(dniAdmin, contrasena);
                    }
                    else if (TipoIngresante == 5)
                    {
                        verificacion = Lp.BuscarCuentaProfes(dniAdmin, contrasena);
                    }
                }
            }
            else if(verificacion == false)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t... Longitud de Dni incorrecta");
            }
            return verificacion;
        }
    }
}
