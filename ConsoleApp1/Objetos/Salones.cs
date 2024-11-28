using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Objetos
{
    internal class Salones
    {
        public string codigoSalon, tipo, profesor, edificio;
        public int piso;
        public Salones izq;
        public Salones der;
        public Salones ant;
        public Salones sgte;

        public Salones(string codigoSalon, string tipo, string profesor, string edificio, int piso)
        {
            this.codigoSalon = codigoSalon;
            this.profesor = profesor;
            this.tipo = tipo;
            this.piso = piso;
            this.edificio = edificio;
            this.izq = null;
            this.der = null;
        }
    }
}
