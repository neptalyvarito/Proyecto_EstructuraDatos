using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Lista_Administrativos
    {
        public Administrativos listaAdmins;
        public int codigoAdmin = 42000001;
        public static Validaciones validación = new Validaciones();
        public Lista_Administrativos()
        {
            listaAdmins = null;
        }

        public void AgregarAdmin(string nombres, string apellidos, int numeroCel, int dni,  string contrasena)
        {
            
            Administrativos q = new Administrativos(nombres, apellidos, numeroCel, dni,  contrasena, codigoAdmin);
            Administrativos t = listaAdmins;

            if (listaAdmins == null)
            {
                listaAdmins = q;
            }
            else
            {
                while (t.sgte != null)
                {
                    t = t.sgte;
                }
                t.sgte = q;
            }
            codigoAdmin++;
        }

        public bool BuscarCuentaAdmin(int dni, string contrasena)
        {

            Administrativos q = listaAdmins;

            bool verificación = false;
            
            while (q != null)
            {
                if (dni == q.dni && contrasena == q.contrasena)
                {
                    verificación = true;
                    break;
                }
                else
                {
                    q = q.sgte;
                }
            }
            return verificación;

        }

        public string NombreCompletoAmdin(int dni)
        {
            string nombreCompleto=" ";
            Administrativos q= listaAdmins;

            while (q != null)
            {
                if(dni == q.dni)
                {
                    nombreCompleto = q.nombres + " " + q.apellidos;
                    break;
                }
                else
                {
                    q = q.sgte;
                }
            }

            return nombreCompleto;
        }
        public void MostrarListaAdministrativos()
        {
            Administrativos q = listaAdmins;
            Console.WriteLine("| Código:".PadRight(30, ' ') + "  | Nombre:".PadRight(50, ' ') + "    | DNI:".PadRight(30, ' ') + "      | Número de celular:".PadRight(30, ' ') + " |Contraseña:".PadRight(20, ' '));
            Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
            while (q != null)
            {
                Console.WriteLine("\n| " + q.codigoAdmin.ToString().PadRight(30, ' ') + "| " + (q.nombres + " " + q.apellidos).PadRight(50, ' ') + "| " + q.dni.ToString().PadRight(30, ' ') + "| " + q.numeroCel.ToString().PadRight(20, ' ') + "   |" + q.contrasena.PadRight(20, ' '));
                q = q.sgte;
            }
        }
        public void ModificarDatosAdmins(string modificable1, int modificable2, int codigo, int opc)
        {

            
            Administrativos q = listaAdmins;
            while (q != null)
            {
                if (codigo == q.codigoAdmin)
                {
                    if (opc == 1) q.nombres = modificable1;
                    else if (opc == 2) q.apellidos = modificable1;
                    else if (opc == 3) q.numeroCel = modificable2;
                    else if (opc == 4) q.contrasena = modificable1;
                    else if (opc == 5) q.dni = modificable2;
                    break;
                }

                q = q.sgte;
            }
        }
        public void EliminarAdministrativos()
        {
            MostrarListaAdministrativos();

            Administrativos q = listaAdmins;
            Administrativos t = listaAdmins;
            string codigo;
            bool flag = false;

            do 
            { 
                Console.Clear();
                MostrarListaAdministrativos();
                Console.WriteLine("----------------------------------------------------------------");
                Console.WriteLine("| Para volver ingrese el número 2");
                Console.WriteLine("Ingrese el código del administrador que desea eliminar: ");
                codigo = Console.ReadLine();
                flag = validación.ValidacionIngresoSoloNum(codigo);
                if (codigo == "2")
                {
                    break;
                }
                else if (flag == true)
                {
                    flag = false;
                    while (q != null)
                    {
                        if (q.codigoAdmin == int.Parse(codigo))
                        {
                            if (q == listaAdmins)
                            {
                                listaAdmins = listaAdmins.sgte;
                                Console.WriteLine("\n....Administrador eliminado");
                                flag = true;
                                return;
                            }
                            else
                            {
                                t.sgte = q.sgte;
                                q = null;
                                Console.WriteLine("\n....Administrador eliminado");
                                flag = true;
                                return;
                            }
                        }
                        t = q;
                        q = q.sgte;
                    }
                    if (flag == false)
                    {
                        Console.WriteLine("....Administrador no encontrado. ");
                        Console.WriteLine("....Vuelva a ingresar el codigo o ingrese el número 2 para volver");
                        Console.ReadLine();
                    }
                }
                else if (flag == false)
                {
                    Console.WriteLine("...Ingrese solo un valor númerico\n");
                    Console.ReadLine();
                }
            } while (flag != true);
        }
        public bool SaberSiExisteAdminConCodigo(int codigoBusqueda)
        {
            Administrativos t= listaAdmins;
            bool flag = false;

            while (t != null)
            {

                if (codigoBusqueda == t.codigoAdmin)
                {
                    flag = true;
                    break;
                }
                t = t.sgte;
            }
            return flag;
        }
        public bool SaberSiExisteAdminConDni(int dniBusqueda)
        {
            Administrativos t = listaAdmins;
            bool flag = false;

            while (t != null)
            {

                if (dniBusqueda == t.dni)
                {
                    flag = true;
                    break;
                }
                t = t.sgte;
            }
            return flag;
        }
        public bool SaberSiExisteNumCelularAdmin(int numCelular)
        {
            Administrativos t = listaAdmins;
            bool flag = false;

            while (t != null)
            {
                if (numCelular == t.numeroCel)
                {
                    flag = true;
                    break;
                }
                t = t.sgte;
            }
            return flag;
        }
        public bool SaberSiExisteContraAdmin(string contrasena)
        {
            Administrativos t = listaAdmins;
            bool flag = false;

            while (t != null)
            {
                if (contrasena == t.contrasena)
                {
                    flag = true;
                    break;
                }
                t = t.sgte;
            }
            return flag;
        }
    }
}
