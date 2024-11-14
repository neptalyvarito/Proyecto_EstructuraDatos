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
        public int codigoTrabajadorEncargado;
        public int codigoTicket;
        public string descripcion;
        public string categoria;
        public string condicion;
        public string respuestaSolucion;
        public int prioridadNum;
        public string prioridadDes;
        public DateTime fechaCreacion;
        public DateTime fechaRespuesta;
        public Ticket delante;
        public Ticket atras;
        public Ticket anterior;
        public Ticket sgte;

        public Ticket(string dueño, int codigoTicket, string condicion, string descripcion, DateTime fechaCreacion, string respuestaSolucion, int codigoDueño, string categoria, DateTime fechaRespuesta, int codigoTrabajadorEncargado, int prioridadNum, string prioridadDes)
        {
            this.dueño = dueño;
            this.codigoTicket = codigoTicket;
            this.descripcion = descripcion;
            this.fechaCreacion = fechaCreacion;
            this.condicion = condicion;
            this.respuestaSolucion = respuestaSolucion;
            this.codigoDueño = codigoDueño;
            this.categoria = categoria;
            this.fechaRespuesta = fechaRespuesta;
            this.codigoTrabajadorEncargado = codigoTrabajadorEncargado;
            this.prioridadNum = prioridadNum;
            this.prioridadDes = prioridadDes;
            anterior = null;
            sgte = null;
            delante = null;
            atras = null;
         
        }
    }
}
