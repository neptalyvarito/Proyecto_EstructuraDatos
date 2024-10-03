using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Lista_Usuarios
    {
        public Usuario ListaUsuario;
        public static int codigoCliente = 4400001;
        public static Validaciones validación = new Validaciones();

        public Lista_Usuarios()
        {
            ListaUsuario = null;
        }
        public void RegistrarUsuarios(string nombre, string apellidos, int dni, int numeroCel, string contrasena)
        {

            Usuario q = new Usuario(nombre, apellidos, dni, numeroCel, codigoCliente, contrasena);
            Usuario t = ListaUsuario;

            if (ListaUsuario == null)
            {
                ListaUsuario = q;
            }
            else
            {
                while (t.sgte != null)
                {
                    t = t.sgte;
                }
                t.sgte = q;
            }
            codigoCliente++;
        }
        public void MostrarListaUsuarios()
        {
            Usuario q = ListaUsuario;
            Console.WriteLine("| Código:".PadRight(30, ' ') + "  | Nombre:".PadRight(50, ' ') + "    | DNI:".PadRight(30, ' ') + "      | Número de celular:".PadRight(30, ' ') + " |Contraseña:".PadRight(20, ' '));
            Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
            while (q != null)
            {

                Console.WriteLine("\n| " + q.codigoCliente.ToString().PadRight(30, ' ') + "| " + (q.nombres + " " + q.apellidos).PadRight(50, ' ') + "| " + q.dni.ToString().PadRight(30, ' ') + "| " + q.numeroCel.ToString().PadRight(20, ' ') + "   |" + q.contrasena.PadRight(20, ' '));
                q = q.sgte;
            }
        }
        public bool BuscarCuentaUsuario(int dni, string contrasena)
        {

            Usuario q = ListaUsuario;
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
        public string NombreCompletoUsuario(int dni)
        {
            string nombreCompleto = " ";
            Usuario q = ListaUsuario;

            while (q != null)
            {
                if (dni == q.dni)
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
        public int ObtenerCodigoUser(int dni)
        {
            Usuario q = ListaUsuario;
            int codigo = 0;
            while (q != null)
            {
                if (dni == q.dni)
                {
                    codigo = q.codigoCliente;
                    break;
                }
                else
                {
                    q = q.sgte;

                }
            }
            return codigo;
        }
        public void ModificarDatosUsers(string modificable1, int modificable2, int codigo, int opc)
        {
            Usuario q = ListaUsuario;

            while (q != null)
            {
                if (codigo == q.codigoCliente)
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
        public void EliminarUsuario()
        {

            Usuario q = ListaUsuario;
            Usuario t = ListaUsuario;
            string codigo;
            bool flag = false;
            do
            {
                Console.Clear();


                MostrarListaUsuarios();

                Console.WriteLine("\n------------------------------------------------------------------");
                Console.WriteLine("|--- Para volver ingrese el número 2");
                Console.Write(" Ingrese el código del alumno a eliminar: ");
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
                        if (q.codigoCliente == int.Parse(codigo))
                        {
                            if (q == ListaUsuario)
                            {
                                ListaUsuario = ListaUsuario.sgte;
                                Console.WriteLine("\n....Alumno eliminado");
                                flag = true;
                                return;
                            }
                            else
                            {
                                t.sgte = q.sgte;
                                q = null;
                                Console.WriteLine("\n....Alumno eliminado");
                                flag = true;
                                return;
                            }
                        }
                        t = q;
                        q = q.sgte;
                    }
                    if (flag == false)
                    {
                        Console.WriteLine("....Alumno no encontrado.");
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
        public bool SaberSiExisteUsuarioConCodigo(int codigoBusqueda)
        {
            Usuario t = ListaUsuario;
            bool flag = false;

            while (t != null)
            {

                if (codigoBusqueda == t.codigoCliente)
                {
                    flag = true;
                    break;
                }
                t = t.sgte;
            }
            return flag;
        }
        public bool SaberSiExisteUsuarioConDni(int dniBusqueda)
        {
            Usuario t = ListaUsuario;
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
        public bool SaberSiExisteNumCelularUsuario(int numCelular)
        {
            Usuario t = ListaUsuario;
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
        public bool SaberSiExisteContraUser(string contrasena)
        {
            Usuario t = ListaUsuario;
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
        public int ObtenerCodigoAleatorioUser(int detener)
        {
            int codigo = 0;
            Usuario t = ListaUsuario;
            int contador = 0;

            while (t != null)
            {
                if (detener == contador)
                {
                    codigo = t.codigoCliente;
                    break;
                }
                t = t.sgte;
                contador++;
            }
            return codigo;
        }
        public string ObtenerNombreCompletoUser(int codigoUser)
        {
            string nombreCompleto = " ";
            Usuario q = ListaUsuario;

            while (q != null)
            {
                if (codigoUser == q.codigoCliente)
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
        public int CantidadDeUsuarios()
        {
            Usuario t = ListaUsuario;
            int contador = 0;
      
            while(t != null)
            {
                contador++;
                t = t.sgte;
            }
            
            return contador;
        }
        public void CantidadTickets(int cantidad, int codigo)
        {
            Usuario t = ListaUsuario;
            while(t != null)
            {
               ;
                if(codigo == t.codigoCliente)
                {
                    t.cantidadTicketsCreados = cantidad;
                    break;
                }
                t = t.sgte;

            }
        }
        public void ImprimirReporte1()
        {
            Usuario t = ListaUsuario;
            Console.WriteLine("| Usuario".PadRight(48, ' ') + "| Cantidad de Tickets Generados");
            Console.WriteLine("--------------------------------------------------------------------------------------");
            while(t!= null)
            {
                Console.WriteLine(("| "+t.nombres + " " + t.apellidos).PadRight(50, ' ') + "| " + t.cantidadTicketsCreados);
                t = t.sgte;
            }
        }
    }
}
