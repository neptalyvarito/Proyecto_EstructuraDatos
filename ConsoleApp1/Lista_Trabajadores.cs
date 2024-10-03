using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Lista_Trabajadores
    {
        public Trabajador listaTrabajadores;
        public int codigoTrabajador = 4300001;
        public static Validaciones validación = new Validaciones();

        public Lista_Trabajadores()
        {
            listaTrabajadores = null;
        }

        public void RegistrarTrabajador(string nombre, string apellido, int dni, int numeroCel, string contrasena)
        {

            Trabajador q = new Trabajador(nombre, apellido, dni, numeroCel, codigoTrabajador, contrasena);
            Trabajador t = listaTrabajadores;

            if (listaTrabajadores == null)
            {
                listaTrabajadores = q;
            }
            else
            {
                while (t.sgte != null)
                {
                    t = t.sgte;
                }
                t.sgte = q;
            }
            codigoTrabajador++;
        }
        public bool BuscarCuentaTrabajadores(int dni, string contrasena)
        {

            Trabajador q = listaTrabajadores;
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
        public string NombreCompletoTrabajador(int dni)
        {
            string nombreCompleto = " ";
            Trabajador q = listaTrabajadores;

            while (q != null)
            {
                if (dni  == q.dni)
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
        public void MostrarListaTrabajadores()
        {
            Trabajador q = listaTrabajadores;
            Console.WriteLine("| Código:".PadRight(30, ' ') + "  | Nombre:".PadRight(50, ' ') + "    | DNI:".PadRight(30, ' ') + "      | Número de celular:".PadRight(30, ' ') + " |Contraseña:".PadRight(20, ' '));
            Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
            while (q!= null)
            {
                Console.WriteLine("\n| " + q.codigoTrabajador.ToString().PadRight(30, ' ') + "| " + (q.nombres + " " + q.apellidos).PadRight(50, ' ') + "| " + q.dni.ToString().PadRight(30, ' ') + "| " + q.numeroCel.ToString().PadRight(20, ' ') + "   |" + q.contrasena.PadRight(20, ' '));

                q = q.sgte;
            }
        }
        public void EliminarTrabajador()
        {
        
       
            Trabajador q = listaTrabajadores;
            Trabajador t = listaTrabajadores;
            string codigo;
            bool flag = false;

            do
            { 

                Console.Clear();
                MostrarListaTrabajadores();
                Console.WriteLine("----------------------------------------------------------------");
                Console.WriteLine("| Para volver ingrese el número 2");
                Console.Write("Ingrese el código del trabajador que desea eliminar: ");
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
                        if (q.codigoTrabajador == int.Parse(codigo))
                        {
                            if (q == listaTrabajadores)
                            {
                                listaTrabajadores = listaTrabajadores.sgte;
                                Console.WriteLine("\n....Trabajador eliminado");
                                flag = true;
                                return;
                            }
                            else
                            {
                                t.sgte = q.sgte;
                                q = null;
                                Console.WriteLine("\n....Trabajador eliminado");
                                flag = true;
                                return;
                            }
                        }
                        t = q;
                        q = q.sgte;
                    }
                    if (flag == false)
                    {
                        Console.WriteLine("....Trabajador no encontrado. ");
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
        public void ModificarDatosTrabajadores(string modificable1, int modificable2, int codigo, int opc)
        {
            Trabajador q = listaTrabajadores;
            while (q != null)
            {
                if (codigo == q.codigoTrabajador)
                {
                    if (opc == 1) q.nombres = modificable1;
                    else if (opc == 2) q.apellidos = modificable1;
                    else if (opc == 3) q.numeroCel = modificable2;
                    else if (opc == 4) q.contrasena = modificable1;
                   
                    break;
                }

                q = q.sgte;
            }
        }
        public bool SaberSiExisteTrabajadorConCodigo(int codigoBusqueda)
        {
            Trabajador t = listaTrabajadores;
            bool flag = false;

            while (t != null)
            {

                if (codigoBusqueda == t.codigoTrabajador)
                {
                    flag = true;
                    break;
                }
                t = t.sgte;
            }
            return flag;
        }
        public bool SaberSiExisteTrabajadorConDni(int dniBusqueda)
        {
            Trabajador t = listaTrabajadores;
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
        public bool SaberSiExisteNumCelularTrabajador(int numCelular)
        {
            Trabajador t = listaTrabajadores;
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
        public bool SaberSiExisteContraTrabajador(string contrasena)
        {
            Trabajador t = listaTrabajadores;
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
