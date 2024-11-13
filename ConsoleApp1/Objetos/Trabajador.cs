using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Trabajador
    {
        public string nombres;
        public string apellidos;
        public int dni;
        public int numeroCel;
        public int codigoTrabajador;
        public int cantidadTicketsRespondidos = 0;
        public string contrasena;
        public string categoria = "Trabajador";
        public DateTime horaEntrada;
        public DateTime horaSalida;
        public string totalHorasTrabajadas;
        public Trabajador sgte;

        public Trabajador(string nombres, string apellidos, int dni, int numeroCel, int codigoTrabajador,  string contrasena, DateTime horaEntrada, DateTime horaSalida, string totalHorasTrabajadas)
        {
            this.nombres = nombres;
            this.apellidos = apellidos;
            this.dni = dni;
            this.numeroCel = numeroCel;
            this.codigoTrabajador = codigoTrabajador;
            this.contrasena = contrasena;
            cantidadTicketsRespondidos = 0;
            sgte = null;
            this.horaEntrada = horaEntrada;
            this.horaSalida = horaSalida;
            this.totalHorasTrabajadas = totalHorasTrabajadas;
        }



    }
}
