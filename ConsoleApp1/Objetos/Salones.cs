using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Objetos
{
    //Nodo del árbol "Salón"
    internal class Salones
    {
        public string codigoSalon, tipo, horarios, profesor, equipos, estado, edificio, codigoCompu;
        public int alumnos, piso;
        public Salones izq;
        public Salones der;

        public Salones(string codigoSalon, string tipo, string horarios, string profesor, string equipos, string estado, string edificio, int alumnos, int piso, string codigoCompu)
        {
            this.codigoSalon = codigoSalon;
            this.tipo = tipo;
            this.horarios = horarios;
            this.profesor = profesor;
            this.equipos = equipos;
            this.estado = estado;
            this.alumnos = alumnos;
            this.piso = piso;
            this.edificio = edificio;
            this.codigoCompu = codigoCompu;
            this.izq = null;
            this.der = null;
        }
    }
}
