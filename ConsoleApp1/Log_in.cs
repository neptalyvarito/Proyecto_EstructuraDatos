using Microsoft.Win32;
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
        public bool InicioSesión(int TipoIngresante, Lista_Usuarios Lu, Lista_Trabajadores LTra, Lista_Administrativos La, ref int dniUser, ref int dniTrabajador, ref int dniAdmin)
        {
            bool verificacion = false;
            Console.Write(" Ingrese su dni: ");

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
            if (verificacion == true)
            {
                if (dniUser != 2 && dniAdmin != 2 && dniTrabajador != 2)
                {

                    Console.Write(" Ingrese su contraseña: ");
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
                }
            }
            else if(verificacion == false)
            {
                Console.WriteLine("....Longitud de Dni incorrecta");
            }
            return verificacion;
        }
    }
}
