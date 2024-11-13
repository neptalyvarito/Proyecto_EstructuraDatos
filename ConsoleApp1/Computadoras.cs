using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Computadoras
    {
        public string codigoCompu;
        public double ram;
        public double almacenamiento;
        public string marca;
        public string sistemaOperativo;
        public string salon;
        public int piso;
        public string edificio;
        public string tarjetaMadre;
        public Computadoras izquierda;
        public Computadoras derecha;

        public Computadoras(string codigoCompu, double ram, double almacenamiento, string marca, string sistemaOperativo, string salon, int piso, string edificio, string tarjetaMadre)
        {
            this.tarjetaMadre = tarjetaMadre;
            this.codigoCompu = codigoCompu;
            this.ram = ram;
            this.almacenamiento = almacenamiento;
            this.marca = marca; 
            this.sistemaOperativo = sistemaOperativo;
            this.salon = salon;
            this.piso = piso;
            this.edificio = edificio;
            izquierda = null;
            derecha = null;
        }

    }
}
