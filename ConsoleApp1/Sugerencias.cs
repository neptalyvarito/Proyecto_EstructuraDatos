using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Sugerencias
    {
        public string creador;
        public string sugerencia;
        public DateTime fechaCreacion;
        public Sugerencias sgte;

        public Sugerencias(string creador, string sugerencia, DateTime fechaCreacion)
        {
            this.creador = creador;
            this.sugerencia = sugerencia;
            this.fechaCreacion = fechaCreacion;
            this.sgte = null;
        }
    }
}
