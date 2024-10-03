using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Registros
    {
        public static Validaciones validacion = new Validaciones();
    
        public static string nombres, apellidos, contrasena;
        public static int dni, numeroCel;

        public void RegistroUsersTrabajadoresAdmins(Lista_Usuarios Lu, Lista_Trabajadores LTra, Lista_Administrativos La, int TipoAModificar)
        {
            bool flag = false, verificacion = false;
            

            string aux, tipoObjeto = " ", cabecera = " ";

            if (TipoAModificar == 1)
            {
                tipoObjeto = "alumno";
                cabecera = "Alumnos";
            }
            else if (TipoAModificar == 2)
            {
                tipoObjeto = "trabajador";
                cabecera = "Trabajadores";
            }
            else if (TipoAModificar == 3)
            {
                tipoObjeto = "administrador";
                cabecera = "Administradores";
            }
            do
            {
                Console.Clear();
                try
                {
                    flag = false;
                    do
                    {
                        Console.Clear();
                        Console.WriteLine("                  Registrando " + cabecera);
                        Console.WriteLine("---------------------------------------------------------");
                        Console.WriteLine(" Si desea salir y no registrar nada, \ningrese el numero 2 en cualquier parte del código  ");
                        Console.WriteLine("---------------------------------------------------------");
                        Console.Write(" Ingrese el número de DNI del " + tipoObjeto + ": ");
                        aux = Console.ReadLine();

                        flag = validacion.ValidacionIngresoSoloNum(aux);

                        if (flag == true)
                        {
                            dni = int.Parse(aux);
                            flag = validacion.ValidacionIngresoDni(dni);

                            if (TipoAModificar == 1) verificacion = Lu.SaberSiExisteUsuarioConDni(dni);
                            else if (TipoAModificar == 2) verificacion = LTra.SaberSiExisteTrabajadorConDni(dni);
                            else if (TipoAModificar == 3) verificacion = La.SaberSiExisteAdminConDni(dni);

                            if (verificacion != true)
                            {
                                if (aux == "2")
                                {
                                    flag = false;
                                    break;
                                }
                                else if (flag == false)
                                {
                                    Console.WriteLine("...La longitud del número de Dni debe ser de 8");
                                    Console.ReadLine();
                                }
                            }
                            else
                            {
                                Console.WriteLine(".....El Dni ingresado ya está asociado a un "+tipoObjeto+",\n.....por favor verifique el número");
                                flag = false;
                                Console.ReadLine();
                            }
                        }
                        else if (flag == false)
                        {
                            Console.WriteLine("...La cadena debe contener solo variables de tipo númerico");
                            Console.ReadLine();
                        }

                    } while (flag != true);

                    if (flag == true)
                    {
                        do
                        {

                            Console.Write(" Ingrese nombres del " + tipoObjeto + ": ");
                            nombres = Console.ReadLine();

                            flag = validacion.ValidacionDeCadenaSoloLetras(nombres);

                            if (nombres == "2")
                            {
                                flag = false;

                                break;
                            }
                            else if (flag == false)
                            {
                                Console.WriteLine("...Los nombres no pueden quedar vacios o poseer caracteres númericos");
                                Console.ReadLine();
                            }
                        } while (flag != true);
                    }

                    if (flag == true)
                    {
                        do
                        {

                            Console.Write(" Ingrese apellidos del " + tipoObjeto + ": ");
                            apellidos = Console.ReadLine();

                            flag = validacion.ValidacionDeCadenaSoloLetras(apellidos);

                            if (apellidos == "2")
                            {
                                flag = false;
                                break;
                            }
                            else if (flag == false)
                            {
                                Console.WriteLine("...Los apellidos no pueden quedar vacios o poseer caracteres númericos");
                                Console.ReadLine();
                            }

                        } while (flag != true);
                    }
                    if (flag == true)
                    {
                        do
                        {
                            Console.Write(" Ingrese el número del celular del " + tipoObjeto + ": ");

                            aux = Console.ReadLine();

                            flag = validacion.ValidacionIngresoSoloNum(aux);

                            if (flag == true)
                            {
                                numeroCel = int.Parse(aux);
                                flag = validacion.ValidacionIngresoNumeroCelular(numeroCel);
                                if (aux == "2")
                                {
                                    flag = false;
                                    break;
                                }
                                else if (flag == false)
                                {
                                    Console.WriteLine("...La longitud del número de celular debe ser de 9");
                                    Console.ReadLine();
                                }
                            }
                            else if (flag == false)
                            {
                                Console.WriteLine("...La cadena debe contener solo variables de tipo númerico");
                                Console.ReadLine();
                            }

                        } while (flag != true);
                    }
                    if (flag == true)
                    {
                        do
                        {
                            if (flag == true)
                            {
                                Console.Write(" Ingrese contraseña que usará el " + tipoObjeto + ": ");
                                contrasena = Console.ReadLine();
                                flag = validacion.ValidacionDeCadenaVaciaEIngresoNum2(contrasena);
                                if (contrasena == "2")
                                {
                                    flag = false;
                                    break;
                                }
                                else if (flag == false)
                                {
                                    Console.WriteLine("...La longitud del número de Dni debe ser de 8");
                                    Console.ReadLine();
                                }
                            }
                            else if (flag == false)
                            {
                                Console.WriteLine("...La cadena debe contener solo variables de tipo númerico");
                                Console.ReadLine();
                            }
                        } while (flag != true);
                    }
                    if (flag == true)
                    {
                            if (TipoAModificar == 1) Lu.RegistrarUsuarios(nombres, apellidos, dni, numeroCel, contrasena);
                            else if (TipoAModificar == 2) LTra.RegistrarTrabajador(nombres, apellidos, dni, numeroCel, contrasena);
                            else if (TipoAModificar == 3) La.AgregarAdmin(nombres, apellidos, numeroCel, dni, contrasena);
                    }
                    if(flag == false)
                    {
                        break;
                    }  
                }
                catch
                {
                    Console.WriteLine("\n....Datos como DNI o número de celular solo deben ser de caracter númerico");
                    Console.ReadLine();
                }
            } while (flag == false);
        }
    }
}
