using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Administrativos
    {
        public string nombres;
        public string apellidos;
        public int numeroCel;
        public int dni;
        public string contrasena;
        public int cantidadTicketsRespondidos = 0;
        public int codigoAdmin;
        public Administrativos sgte;
        public Administrativos(string nombres, string apellidos, int numeroCel, int dni, string contrasena, int codigoAdmin)
        {
            this.nombres = nombres;
            this.apellidos = apellidos;
            this.numeroCel = numeroCel;
            this.dni = dni;
            cantidadTicketsRespondidos = 0;
            this.contrasena = contrasena;
            this.codigoAdmin = codigoAdmin;
            sgte = null;
        }


    }
}
