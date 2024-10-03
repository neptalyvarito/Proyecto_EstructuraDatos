using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Usuario
    {
        public string nombres;
        public string apellidos;
        public int dni;
        public int numeroCel;
        public int codigoCliente;
        public string contrasena;
        public int cantidadTicketsCreados =0;
        public Usuario sgte;

        public Usuario(string nombres, string apellidos, int dni, int numeroCel, int codigoCliente,string contrasena)
        {
            this.nombres = nombres;
            this.apellidos = apellidos;
            this.dni = dni;
            this.numeroCel = numeroCel;
            this.codigoCliente = codigoCliente;
            this.contrasena = contrasena;
            cantidadTicketsCreados = 0;
            sgte = null;
        }
    }
}
