using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Ticket
    {
        public string dueño;
        public int codigoDueño;
        public int codigoTicket;
        public string descripcion;
        public string condicion;
        public string respuestaSolucion;
        public DateTime fechaCreacion;
        public Ticket sgte;

        public Ticket(string dueño, int codigoTicket, string condicion, string descripcion, DateTime fechaCreacion, string respuestaSolucion, int codigoDueño)
        {
            this.dueño = dueño;
            this.codigoTicket = codigoTicket;
            this.descripcion = descripcion;
            this.fechaCreacion = fechaCreacion;
            this.condicion = condicion;
            this.respuestaSolucion = respuestaSolucion;
            this.codigoDueño = codigoDueño;
        
            sgte = null;
           
        }
    }
}
