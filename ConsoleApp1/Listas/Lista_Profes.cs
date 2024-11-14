using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Lista_Profes
    {
        public Profesor listaProfes;
        public int codigoProfe = 4500001;
        public Lista_Profes()
        {
            listaProfes = null;
        }

        public void RegistrarProfe(string nombres, string apellidos, int dni, int numerocel, string contrasena)
        {
            Profesor q = new Profesor(nombres, apellidos, codigoProfe, dni, contrasena, numerocel);
            Profesor t = listaProfes;
            
            if(listaProfes == null)
            {
                listaProfes = q;
            }
            else
            {
                while(t.sgte != null)
                {
                    t = t.sgte;
                }
                t.sgte = q;
            }
            codigoProfe++;
        }
        public void MostrarListaProfes()
        {
            Profesor q = listaProfes;
            Console.WriteLine("| Código:".PadRight(30, ' ') + "  | Nombre:".PadRight(50, ' ') + "    | DNI:".PadRight(30, ' ') + "      | Número de celular:".PadRight(30, ' ') + " |Contraseña:".PadRight(20, ' '));
            Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
            while (q != null)
            {
                Console.WriteLine("\n| " + q.codigoProfe.ToString().PadRight(30, ' ') + "| " + (q.nombres + " " + q.apellidos).PadRight(50, ' ') + "| " + q.dni.ToString().PadRight(30, ' ') + "| " + q.numerocel.ToString().PadRight(20, ' ') + "   |" + q.contrasena.PadRight(20, ' '));
                q = q.sgte;
            }
        }

        public bool SaberSiExisteProfeConDni(int dniBusqueda)
        {
            Profesor t = listaProfes;
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
        
        public bool SaberSiExisteNumCelularProfe(int numCelular)
        {
            Profesor t = listaProfes;
            bool flag = false;

            while (t != null)
            {
                if (numCelular == t.numerocel)
                {
                    flag = true;
                    break;
                }
                t = t.sgte;
            }
            return flag;
        }
        
        public bool SaberSiExisteContraProfe(string contrasena)
        {
            Profesor t = listaProfes;
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
        public int ObtenerCodigoAleatorioProfe(int detener)
        {
            int codigo = 0;
            Profesor t = listaProfes;
            int contador = 0;

            while (t != null)
            {
                if (detener == contador)
                {
                    codigo = t.codigoProfe;
                    break;
                }
                t = t.sgte;
                contador++;
            }
            return codigo;
        }
        public string ObtenerNombreCompletoProfe(int codigoUser)
        {
            string nombreCompleto = " ";
            Profesor q = listaProfes;

            while (q != null)
            {
                if (codigoUser == q.codigoProfe)
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
        public bool BuscarCuentaProfes(int dni, string contrasena)
        {

            Profesor q = listaProfes;

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
        public int ObtenerCodigoProfe(int dni)
        {
            Profesor q = listaProfes;
            int codigo = 0;
            while (q != null)
            {
                if (dni == q.dni)
                {
                    codigo = q.codigoProfe;
                    break;
                }
                else
                {
                    q = q.sgte;

                }
            }
            return codigo;
        }
    }
}
