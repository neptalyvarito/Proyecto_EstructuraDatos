using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Profesor
    {
        public string nombres;
        public string apellidos;
        public string salondesignado;
        public int codigoProfe;
        public int dni;
        public string contrasena;
        public int numerocel;
        public string categoria = "Profesor";
        public Profesor sgte;

        public Profesor(string nombres, string apellidos, int codigoProfe, int dni, string contrasena, int numerocel, string salondesignado)
        {
            this.contrasena = contrasena;
            this.nombres = nombres;
            this.apellidos = apellidos;
            this.codigoProfe = codigoProfe;
            this.dni = dni;
            this.numerocel = numerocel;
            this.salondesignado = salondesignado;
            sgte = null;
        }


    }
}
